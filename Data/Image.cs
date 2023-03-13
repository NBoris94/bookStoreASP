using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Image : BaseEntity
    {
        public string Path { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
