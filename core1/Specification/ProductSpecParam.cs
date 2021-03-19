using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetarSkinet.core1.Specification
{
    public class ProductSpecParam
    {
        private const int MaxPageSize = 50;

        public int pageIndex { get; set; } = 1;

        private int _pageSize = 1;

        public int PageSize
        {
            get => _pageSize;
            set=> _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? Brandid { get; set; }
        public int? Typeid { get; set; }
        public string Sort { get; set; }

    }
}
