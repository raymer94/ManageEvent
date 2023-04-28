using EventManage.Models.IRepositorry;
using EventManage.Models.Services.IServices;
using System.Collections.Generic;

namespace EventManage.Models.Services.Services
{
    public class ReservationsService: IRepositoryService<Reservation>
    {
        private readonly IRepository<Reservation> _repository;
        private readonly IRepository<Client> _clientRepository;

        public ReservationsService(IRepository<Reservation> repository, IRepository<Client> clientRepository)
        {
            _repository = repository;
            _clientRepository = clientRepository;        
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return (List<Reservation>)await _repository.GetAllAsync();
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            return (Reservation)await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Reservation entity)
        {
            var Client = await _clientRepository.GetByIdAsync(entity.Id);
            if (Client.Age < 21)
                throw new InvalidOperationException("Reservations are only allowed for clients over 21 years of age.");


            // Check if client is not in DUE or CANCELED status
            if (Client.StatusId != 1)
                throw new InvalidOperationException("It should not be allowed to create reservations for clients who are in status DUE or CANCELED.");


            // Check if reservation type is specified
            if (entity.EventId == null)
                throw new InvalidOperationException("Reservation event must be specified.");


            // Check if reservation start and end times are valid
            if (IsValidReservationTime(entity))
                throw new InvalidOperationException("Reservation is not allowed during these hours.");


            // Check if reservation already exists for the specified time period
            var reservations = await _repository.GetAllAsync();
            if (reservations.Any(r =>
                r.StartTime <= entity.StartTime && r.EndTime > entity.StartTime ||
                r.StartTime < entity.EndTime && r.EndTime >= entity.EndTime))
            {
                throw new InvalidOperationException("Reservation already exists for the specified time period.");
            }

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Reservation entity)
        {
            var Client = await _clientRepository.GetByIdAsync(entity.Id);
            if (Client.Age < 21)
                throw new InvalidOperationException("Reservations are only allowed for clients over 21 years of age.");


            // Check if client is not in DUE or CANCELED status
            if (Client.StatusId != 1)
                throw new InvalidOperationException("It should not be allowed to create reservations for clients who are in status DUE or CANCELED.");


            // Check if reservation type is specified
            if (entity.EventId == null)
                throw new InvalidOperationException("Reservation event must be specified.");


            // Check if reservation start and end times are valid
            if (IsValidReservationTime(entity))
                throw new InvalidOperationException("Reservation is not allowed during these hours.");


            // Check if reservation already exists for the specified time period
            var reservations = await _repository.GetAllAsync();
            if (reservations.Any(r =>
                r.StartTime <= entity.StartTime && r.EndTime > entity.StartTime ||
                r.StartTime < entity.EndTime && r.EndTime >= entity.EndTime))
            {
                throw new InvalidOperationException("Reservation already exists for the specified time period.");
            }

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public bool IsValidReservationTime(Reservation entity)
        {
            if ((entity.StartTime.DayOfWeek == DayOfWeek.Monday ||
                entity.StartTime.DayOfWeek == DayOfWeek.Tuesday ||
                entity.StartTime.DayOfWeek == DayOfWeek.Wednesday ||
                entity.StartTime.DayOfWeek == DayOfWeek.Thursday) &&
               (entity.StartTime.TimeOfDay < new TimeSpan(7, 30, 0) || entity.EndTime.TimeOfDay > new TimeSpan(21, 0, 0)))
            {
                return false;
            }

            if ((entity.StartTime.DayOfWeek == DayOfWeek.Friday ||
                entity.StartTime.DayOfWeek == DayOfWeek.Saturday) &&
               (entity.StartTime.TimeOfDay < new TimeSpan(15, 0, 0) || entity.EndTime.TimeOfDay > new TimeSpan(23, 0, 0)))
            {
                return false;
            }

            if (entity.StartTime.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }
            return true;
        }
    }
}
