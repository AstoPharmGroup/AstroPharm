using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Domain.Configurations.Pagination
{
    public class PaginationParams
    {
        public const int maxPageSize = 20;
        private int pageSize;

        public int PageSize
        {
            get => pageSize == 0 ? 10 : pageSize; // Use `pageSize` instead of `PageSize'
            set => pageSize = value > maxPageSize ? maxPageSize : value;
        }

        public int PageIndex { get; set; }
    }

}
