using Premium.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premium.Data.interfaces
{
     public interface ICarsCategory
    {
        IEnumerable<Category> ALLCategories { get; }
    }
}
