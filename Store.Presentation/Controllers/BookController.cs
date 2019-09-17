using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Model.Book.Request;
using Store.BusinessLogic.Model.Book.Response;
using Store.BusinessLogic.Services.Interfaces;
using Store.Presentation.Controllers.Base;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class BookController : BaseController
    {
        private readonly IBookService _bookRepository;
        public BookController(IBookService bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookModel> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<BookItemModel> FindByIdAsync([FromRoute] long id)
        {
            return await _bookRepository.FindByIdAsync(id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteById([FromRoute] long id)
        {
            await _bookRepository.DeleteByIdAsync(id);
        }

        [HttpPatch]
        public async Task Update([FromBody] BookUpdateRequest book)
        {
            await _bookRepository.UpdateAsync(book);

        }
    }
}