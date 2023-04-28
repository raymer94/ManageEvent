using EventManage.Models.IRepositorry;
using EventManage.Models.Services.IServices;

namespace EventManage.Models.Services.Services
{
    public class ReservationsFurnituresService: IRepositoryService<ReservationsFurniture>
    {
        private readonly IRepository<ReservationsFurniture> _repository;

        public ReservationsFurnituresService(IRepository<ReservationsFurniture> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReservationsFurniture>> GetAllAsync()
        {
            return (List<ReservationsFurniture>)await _repository.GetAllAsync();
        }

        public async Task<ReservationsFurniture> GetByIdAsync(int id)
        {
            return (ReservationsFurniture)await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(ReservationsFurniture entity)
        {
            // Check if maximum of 10 furniture items are allowed
            var reservationsById = await _repository.GetAllAsync();
            var reservationsDone = reservationsById.Where(x => x.ReservationId == entity.Id).ToList();
            if (reservationsDone.Count > 10)
                throw new InvalidOperationException("Only a maximum of 10 pieces of furniture are allowed to enter.");

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(ReservationsFurniture entity)
        {
            // Check if maximum of 10 furniture items are allowed
            var reservationsById = await _repository.GetAllAsync();
            var reservationsDone = reservationsById.Where(x => x.ReservationId == entity.Id).ToList();
            if (reservationsDone.Count > 10)
                throw new InvalidOperationException("Only a maximum of 10 pieces of furniture are allowed to enter.");

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
