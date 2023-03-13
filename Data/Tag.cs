using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        List<Book> Books { get; set; }
    }
}
