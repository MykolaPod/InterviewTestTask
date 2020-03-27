using System;
using AutoMapper;
using Data;

namespace PhoneBook.Services.CQRSES
{
    public abstract class BaseHandler
    {
        public ApplicationDbContext Context { get; }
        public IMapper Mapper { get; }

        public BaseHandler(ApplicationDbContext context, IMapper mapper)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}