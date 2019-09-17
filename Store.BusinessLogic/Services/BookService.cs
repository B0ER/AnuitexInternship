using Store.BusinessLogic.Model.Book.Request;
using Store.BusinessLogic.Model.Book.Response;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services
{
    public class BookService : IBookService
    {
        private readonly IPrintingEditionRepository _bookRepository;
        private readonly IAuthorInBookRepository _authorInBookRepository;

        public BookService(IPrintingEditionRepository bookRepository, IAuthorInBookRepository authorInBookRepository)
        {
            _bookRepository = bookRepository;
            _authorInBookRepository = authorInBookRepository;
        }

        public async Task<BookModel> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            var bookItems = books.Select(book =>
            {
                var bookItem = new BookItemModel { Id = book.Id, Title = book.Name, Description = book.Description };
                bookItem.Authors = _authorInBookRepository.GetAuthorsByBookIdAsync(book.Id).Result;
                return bookItem;
            });

            var bookResponse = new BookModel { Books = bookItems };
            return bookResponse;
        }

        public async Task<BookItemModel> FindByIdAsync(long id)
        {
            var book = await _bookRepository.FindByIdAsync(id);
            if (book == null)
            {
                throw new InvalidOperationException("Book isn't found");
            }

            var bookAuthors = await _authorInBookRepository.GetAuthorsByBookIdAsync(book.Id);

            var bookItemResponse = new BookItemModel
            {
                Id = book.Id,
                Title = book.Name,
                Description = book.Description,
                Authors = bookAuthors
            };

            return bookItemResponse;
        }

        public async Task DeleteByIdAsync(long id)
        {
            var book = await _bookRepository.FindByIdAsync(id);
            if (book == null)
            {
                throw new InvalidOperationException("Book isn't found");
            }
            await _bookRepository.DeleteByIdAsync(id);
        }

        public async Task UpdateAsync(BookUpdateRequest book)
        {
            var bookUpdate = await _bookRepository.FindByIdAsync(book.BookId);
            if (bookUpdate == null)
            {
                throw new InvalidOperationException("Book isn't found");
            }

            book.ChangePrintingEdition(bookUpdate);
            await _bookRepository.UpdateAsync(bookUpdate);
        }
    }
}
