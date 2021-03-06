﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Dto.Request;
using Contracts.Dto.Response;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Helpers
{
    public static class PaginationHelpers
    {
        public static async Task<PagedDto<TDest>> GetPagedResultOf<TSource, TDest>(this IQueryable<TSource> query, GetPagedItemsDto paginationSettings, IMapper mapper, CancellationToken cancellationToken)
        {
            var result = new PagedDto<TDest>()
            {
                Page = paginationSettings.Page,
                PageSize = paginationSettings.PageSize,
                TotalItems = await query.CountAsync(cancellationToken)
            };
            
            var skip = (result.Page - 1) * result.PageSize;     
            var itemsOfPage = await query.Skip(skip).Take(result.PageSize).ToListAsync(cancellationToken);

            result.Items = mapper.Map<List<TDest>>(itemsOfPage);

            return result;
        }
    }
}