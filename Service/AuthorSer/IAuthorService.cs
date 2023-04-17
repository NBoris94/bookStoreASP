using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AuthorSer
{
    public interface IAuthorService
    {
        List<Author> GetAuthors();
        Author GetAuthorById(int id);
        void CreateAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int id);
    }
}
