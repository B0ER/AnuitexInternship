using System.Linq;
using System.Threading.Tasks;
using Store.BusinessLogic.Model.Authors.Request;
using Store.BusinessLogic.Model.Authors.Response;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;

namespace Store.BusinessLogic.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<AuthorModel> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            var authorResponse = new AuthorModel
            {
                Authors = authors.Select(a => new AuthorItemModel { Id = a.Id, Name = a.Name })
            };
            return authorResponse;
        }

        public async Task<AuthorItemModel> FindByIdAsync(long id)
        {
            var author = await _authorRepository.FindByIdAsync(id);
            var authorResponse = new AuthorItemModel { Id = author.Id, Name = author.Name };
            return authorResponse;
        }

        public async Task CreateAsync(AuthorCreateRequest author)
        {
            var newAuthor = new Author { Name = author.Name };
            await _authorRepository.AddAsync(newAuthor);
        }

        public async Task UpdateAsync(AuthorUpdateRequest author)
        {
            var authorEntity = new Author { Id = author.Id, Name = author.Name };
            await _authorRepository.UpdateAsync(authorEntity);
        }

        public async Task DeleteAsync(long id)
        {
            await _authorRepository.DeleteByIdAsync(id);
        }
    }
}