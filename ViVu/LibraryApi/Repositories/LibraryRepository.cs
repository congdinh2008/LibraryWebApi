using LibraryApi.Data;
using LibraryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApi.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly ApplicationDbContext _context;

        public LibraryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(Author author)
        {
            author.Id = Guid.NewGuid();
            _context.Authors.Add(author);

            if (author.Books.Any())
            {
                foreach (var book in author.Books)
                {
                    book.Id = Guid.NewGuid();
                }
            }
        }

        public void AddBookForAuthor(Guid authorId, Book book)
        {
            var author = GetAuthor(authorId);

            if (author != null)
            {
                if (book.Id == Guid.Empty)
                    book.Id = Guid.NewGuid();

                author.Books.Add(book);
            }
        }

        public bool AuthorExists(Guid authorId)
        {
            return _context.Authors.Any(a => a.Id == authorId);
        }

        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
        }

        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName).
                ToList();
        }

        public IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds)
        {
            return _context.Authors
                .Where(a => authorIds.Contains(a.Id))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName).
                ToList();
        }

        public Author GetAuthor(Guid authorId)
        {
            return _context.Authors
                .FirstOrDefault(a => a.Id == authorId);
        }

        public Book GetBookForAuthor(Guid bookId, Guid authorId)
        {
            return _context.Books
                .Where(b => b.AuthorId == authorId && b.Id == bookId)
                .FirstOrDefault();
        }

        public IEnumerable<Book> GetBooksForAuthor(Guid authorId)
        {
            return _context.Books
                .Where(b => b.AuthorId == authorId)
                .OrderBy(b => b.Title)
                .ToList();
        }

        public void UpdateAuthor(Author author)
        {

        }

        public void UpdateBookForAuthor(Book book)
        {

        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}