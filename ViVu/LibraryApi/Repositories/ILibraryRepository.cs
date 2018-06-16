using System;
using System.Collections.Generic;
using LibraryApi.Extensions;
using LibraryApi.Models;

namespace LibraryApi.Repositories
{
    public interface ILibraryRepository
    {
        void AddAuthor(Author author);
        void AddBookForAuthor(Guid authorId, Book book);
        bool AuthorExists(Guid authorId);
        void DeleteAuthor(Author author);
        void DeleteBook(Book book);
        Author GetAuthor(Guid authorId);
        PagedList<Author> GetAuthors(AuthorsResourceParameters authorsResourceParameters);
        IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds);
        Book GetBookForAuthor(Guid bookId, Guid authorId);
        IEnumerable<Book> GetBooksForAuthor(Guid authorId);
        bool Save();
        void UpdateAuthor(Author author);
        void UpdateBookForAuthor(Book book);
    }
}