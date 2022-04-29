using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAzure.Models
{
    public class PaginationParams
    {
        private const int _maxItemPerPage = 1000;
        private int itemsPerPage;

        public int Page { get; set; } = 1;
        public int ItemsPerPage
        {
            get => itemsPerPage;
            set => itemsPerPage = value > _maxItemPerPage ? _maxItemPerPage : value;
        }
    }
}
