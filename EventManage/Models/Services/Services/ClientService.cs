using EventManage.Models.IRepositorry;
using EventManage.Models.Services.IServices;

namespace EventManage.Models.Services.Services
{
    public class ClientService: IRepositoryService<Client>
    {
        private readonly IRepository<Client> _repository;

        public ClientService(IRepository<Client> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return (List<Client>)await _repository.GetAllAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return (Client)await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Client entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Client entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
