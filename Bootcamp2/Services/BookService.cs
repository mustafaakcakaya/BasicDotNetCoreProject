using Bootcamp2.Context;
using Bootcamp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Bootcamp2.Services
{
    public class BookService
    {
        private readonly BookContext _bookContext;

        public BookService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }
        public List<BookEntity> GetBooks()
        {
            return _bookContext.Books;
        }
        public BookEntity Get(int id)
        {
            return _bookContext.Books.FirstOrDefault(x=>x.Id == id);
        }
        public void Edit(BookEntity bookEntity)
        {
            var entity = _bookContext.Books.FirstOrDefault(x=>x.Id==bookEntity.Id);
            _bookContext.Books.Remove(entity);
            _bookContext.Books.Add(bookEntity);
        }
        public void Delete(BookEntity bookEntity)
        {
            var entity = _bookContext.Books.FirstOrDefault(x => x.Id == bookEntity.Id);
            _bookContext.Books.Remove(entity);
        }
    }
}
