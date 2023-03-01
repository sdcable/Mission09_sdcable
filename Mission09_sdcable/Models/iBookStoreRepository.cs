using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_sdcable.Models
{
    //Basically the outline of what the corrosponding EF file has to do.
    public interface iBookStoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
