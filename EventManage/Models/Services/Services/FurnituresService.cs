using EventManage.Models.IRepositorry;
using EventManage.Models.Services.IServices;

namespace EventManage.Models.Services.Services
{
    public class FurnituresService: IRepositoryService<Furniture>
    {
        private readonly IRepository<Furniture> _repository;

        public FurnituresService(IRepository<Furniture> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Furniture>> GetAllAsync()
        {
            return (List<Furniture>)await _repository.GetAllAsync();
        }

        public async Task<Furniture> GetByIdAsync(int id)
        {
            return (Furniture)await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Furniture entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Furniture entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
