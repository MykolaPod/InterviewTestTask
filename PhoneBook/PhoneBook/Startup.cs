using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Contracts.Dto.Request.Validators.Contact;
using Data;
using Data.Migrations;
using FluentValidation.AspNetCore;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PhoneBook.Controllers;
using PhoneBook.Services;
using PhoneBook.Services.Abstract;
using PhoneBook.Services.Hubs;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace PhoneBook
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterDependencies(services);
            services.AddMvc(options => { options.EnableEndpointRouting = false; })
                .AddFluentValidation(config =>
                {
                    config.RegisterValidatorsFromAssemblyContaining<ContactCreateDtoValidator>();
                    config.ImplicitlyValidateChildProperties = true;
                    config.RunDefaultMvcValidationAfterFluentValidationExecutes = true;
                })
                .AddNewtonsoftJson()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            ConfigureApiVersion(services);
            ConfigureSwaggerService(services);
            ConfigureCors(services);
            ConfigureDbContext(services);
            ConfigureSignalR(services);
            services.AddAutoMapperClasses();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider versionDescriptionProvider)
            
        {
            ConfigureSwaggerUi(app, versionDescriptionProvider);
          
            ConfigureFilters(app);

            app.UsePathBase("/api");
            app.UseRouting();
            app.UseCors("AllowSpecificOrigins");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ContactHub>($"/Hubs/{nameof(ContactHub)}");
                endpoints.MapControllers();
            });
        }

        private void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ISignalRTransmitterService, SignalRTransmitterService>();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }

        private void ConfigureApiVersion(IServiceCollection services)
        {
            services
                .AddVersionedApiExplorer(options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                })
                .AddApiVersioning(options =>
                {
                    options.ReportApiVersions = true;
                    AddApiVersionConventions(options.Conventions);
                });
        }

        private void AddApiVersionConventions(IApiVersionConventionBuilder builder)
        {
            // Version 1.0 controllers
            builder.Controller<ContactsController>().HasApiVersion(ApiVersion.Default);

            // No version controllers
        }

        private void ConfigureSwaggerService(IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                var sp = services.BuildServiceProvider();
                var versionDescriptionProvider = sp.GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in versionDescriptionProvider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                        description.GroupName,
                        new OpenApiInfo()
                        {
                            Title = $"PhoneBook",
                            Version = description.ApiVersion.ToString()
                        });
                }
                
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "PhoneBook.xml"));
                options.DescribeAllParametersInCamelCase();
                options.MapType<Guid>(() => new OpenApiSchema {Type = "string", Format = "uuid"});
                options.OrderActionsBy((description) => $"{description.HttpMethod}");
            });
        }

        private void ConfigureCors(IServiceCollection services)
        {
            string[] corsDomains = Configuration.GetSection("CorsDomains")
                .Get<string>()
                .Split(',');

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", builder =>
                {
                    builder
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .WithOrigins(corsDomains)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .Build();
                });
            });
        }

        private void ConfigureDbContext(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Initial).GetTypeInfo().Assembly.GetName().Name);
                        sqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(20), errorCodesToAdd: new List<string>());
                    });
                });
        }

        private void ConfigureSignalR(IServiceCollection services)
        {
            services.AddSignalR()
                .AddNewtonsoftJsonProtocol();
        }
        
        private void ConfigureSwaggerUi(IApplicationBuilder app, IApiVersionDescriptionProvider versionDescriptionProvider)
        {
           
            app.UseSwagger(options => { options.RouteTemplate = "swagger/{documentname}/swagger.json"; });

            app.UseSwaggerUI(options =>
            {
                foreach (var versionDescription in versionDescriptionProvider.ApiVersionDescriptions)
                {
                    var description = $"Version {versionDescription.ApiVersion}";

                    if (versionDescription.IsDeprecated)
                    {
                        description += " (Deprecated)";
                    }

                    options.SwaggerEndpoint($"/swagger/{versionDescription.GroupName}/swagger.json", description);
                    options.RoutePrefix = string.Empty;
                }

                options.DocExpansion(DocExpansion.None);
            });
        }

        private void ConfigureFilters(IApplicationBuilder app)
        {
            app.UseExceptionHandler(
                options => { options.ApplyExceptionHandlingOptions(); }
            );
        }
    }
}