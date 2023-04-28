using EventManage.Models.IRepositorry;
using EventManage.Models.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace EventManage.Models.Services.Services
{
    public class StatusService : IRepositoryService<Status>
    {
        private readonly IRepository<Status> _repository;

        public StatusService(IRepository<Status> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Status>> GetAllAsync()
        {
            return (List<Status>)await _repository.GetAllAsync();
        }

        public async Task<Status> GetByIdAsync(int id)
        {
            return (Status)await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Status entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Status entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
