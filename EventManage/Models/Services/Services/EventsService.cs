using EventManage.Models.IRepositorry;
using EventManage.Models.Services.IServices;

namespace EventManage.Models.Services.Services
{
    public class EventsService: IRepositoryService<Event>
    {
        private readonly IRepository<Event> _repository;

        public EventsService(IRepository<Event> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return (List<Event>)await _repository.GetAllAsync();
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return (Event)await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Event entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Event entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
