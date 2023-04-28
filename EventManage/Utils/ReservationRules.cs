using EventManage.Models;
using EventManage.Models.IRepositorry;

namespace EventManage.Utils
{
    public class ReservationRules
    {
        public async void runReservationRules(Reservation entity, IRepository<Reservation> _repository, IRepository<Client> _clientRepository, 
            IRepository<ReservationsFurniture> _reservationsFurniture) 
        {
            var Client = await _clientRepository.GetByIdAsync(entity.Id);
            if (Client.Age < 21)
                throw new InvalidOperationException("Reservations are only allowed for clients over 21 years of age.");


            // Check if client is not in DUE or CANCELED status
            if (Client.StatusId != 1)
                throw new InvalidOperationException("It should not be allowed to create reservations for clients who are in status DUE or CANCELED.");


            // Check if maximum of 10 furniture items are allowed
            var reservationsById = await _reservationsFurniture.GetAllAsync();
            var reservationsDone = reservationsById.Where(x => x.ReservationId == entity.Id).ToList();
            if (reservationsDone.Count > 10)
                throw new InvalidOperationException("Only a maximum of 10 pieces of furniture are allowed to enter.");


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
