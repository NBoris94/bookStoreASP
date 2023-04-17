using Data;
using Repository.AuthorRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AuthorSer
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public List<Author> GetAuthors()
        {
            return _repository.GetAll();
        }

        public Author GetAuthorById(int id)
        {
            return _repository.Get(id);
        }

        public void CreateAuthor(Author author)
        {
            _repository.Create(author);
        }

        public void UpdateAuthor(Author author)
        {
            _repository.Update(author);
        }

        public void DeleteAuthor(int id)
        {
            _repository.Delete(id);
        }
    }
}
