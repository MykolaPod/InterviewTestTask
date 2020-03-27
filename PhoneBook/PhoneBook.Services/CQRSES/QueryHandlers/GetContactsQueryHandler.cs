using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DomainEntities;
using Contracts.Dto.Response;
using Contracts.Dto.Response.Contact;
using Data;
using Infrastructure.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Services.CQRSES.Queries;

namespace PhoneBook.Services.CQRSES.QueryHandlers
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, PagedDto<ContactDetailsDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetContactsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<PagedDto<ContactDetailsDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.Contacts
                .Include(c => c.ContactNumbers)
                .GetPagedResultOf<Contact,ContactDetailsDto>(request.Dto, _mapper);

            return result;

        }
    }
}