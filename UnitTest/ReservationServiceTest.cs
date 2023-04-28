using EventManage.Models;
using EventManage.Models.IRepositorry;
using EventManage.Models.Services.IServices;
using EventManage.Models.Services.Services;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class ReservationServiceTest
    {
        private ReservationsService _reservationsService;
        private Mock<IRepository<Reservation>> _reservationRepositoryMock;
        private Mock<IRepository<Client>> _clientRepositoryMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _reservationRepositoryMock = new Mock<IRepository<Reservation>>();
            _clientRepositoryMock = new Mock<IRepository<Client>>();
            _reservationsService = new ReservationsService(_reservationRepositoryMock.Object, 
                _clientRepositoryMock.Object); ;
        }

        [TestMethod]
        public async Task AddAsync_ClientIsUnder21_ThrowsInvalidOperationException()
        {
            var entity = new Reservation { Id = 1 };
            var client = new Client { Id = 1, Age = 20 };
            _clientRepositoryMock.Setup(x => x.GetByIdAsync(entity.Id)).ReturnsAsync(client);

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => _reservationsService.AddAsync(entity));
        }

        [TestMethod]
        public async Task AddAsync_ClientIsInDueStatus_ThrowsInvalidOperationException()
        {
            var entity = new Reservation { Id = 1 };
            var client = new Client { Id = 1, Age = 22, StatusId = 2 };
            _clientRepositoryMock.Setup(x => x.GetByIdAsync(entity.Id)).ReturnsAsync(client);

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => _reservationsService.AddAsync(entity));
        }

        [TestMethod]
        public async Task AddAsync_WhenReservationAlreadyExistsForTheSpecifiedTimePeriod_ShouldThrowInvalidOperationException()
        {
            var client = new Client { Id = 1, StatusId = 1, Age = 25 };
            var existingReservation = new Reservation { Id = 2, ClientId = 1, EventId = 1, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2) };
            var reservation = new Reservation { Id = 1, ClientId = 1, EventId = 1, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2) };

            _clientRepositoryMock.Setup(x => x.GetByIdAsync(client.Id)).ReturnsAsync(client);
            _reservationRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<Reservation> { existingReservation });

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => _reservationsService.AddAsync(reservation));
        }
        [TestMethod]
        public async Task AddAsync_WhenReservationStartTimeAndEndTimeOverlapWithExistingReservation_ShouldThrowException()
        {
            var existingReservation = new Reservation
            {
                Id = 1,
                StartTime = new DateTime(2023, 5, 1, 12, 0, 0),
                EndTime = new DateTime(2023, 5, 1, 14, 0, 0),
                ClientId = 1
            };
            _reservationRepositoryMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(new List<Reservation> { existingReservation });

            var reservation = new Reservation
            {
                StartTime = new DateTime(2023, 5, 1, 13, 0, 0),
                EndTime = new DateTime(2023, 5, 1, 15, 0, 0),
                ClientId = 2
            };

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () => await _reservationsService.AddAsync(reservation));
        }

    }
}
