using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double? SalePrice { get; set; }
        public int Count { get; set; }
        public int PurchasedCount { get; set; }
        public int PagesCount { get; set; }

        public Image Image { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
