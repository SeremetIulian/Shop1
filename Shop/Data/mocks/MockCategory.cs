using Premium.Data.interfaces;
using Premium.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> ALLCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { categoryName = "Masini hibrid", desc = "Cel mai actual tip de transport"},
                    new Category { categoryName = "Masini clasice", desc = "Masini cu motor cu ardere interna"}
                };
            }
        }
    }
}
