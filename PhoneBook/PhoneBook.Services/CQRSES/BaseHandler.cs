using System;
using AutoMapper;
using Data;
using MediatR;

namespace PhoneBook.Services.CQRSES
{
    public abstract class BaseHandler
    {
        public ApplicationDbContext Context { get; }
        public IMapper Mapper { get; }

        public IMediator Mediator { get; }

        public BaseHandler(ApplicationDbContext context, IMapper mapper, IMediator mediator)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }
}