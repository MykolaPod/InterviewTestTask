using System.Collections.Generic;

namespace Contracts.Dto.Response
{
    public class PagedDto<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public List<T> Items { get; set; }
    }
}