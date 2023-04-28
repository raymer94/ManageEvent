using EventManage.Models.IRepositorry;
using EventManage.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManage.Models.Services.Services;

namespace UnitTest
{
    [TestClass]
    internal class ReservationFurnitureServicesTest
    {
        private Mock<IRepository<ReservationsFurniture>> _repositoryMock;
        private ReservationsFurnituresService _service;

        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<IRepository<ReservationsFurniture>>();
            _service = new ReservationsFurnituresService(_repositoryMock.Object);
        }


        [TestMethod]
        public async Task AddAsync_MaximumFurnitureItemsExceeded_ThrowsInvalidOperationException()
        {
            var reservations = new List<ReservationsFurniture>();
            var reservation = new ReservationsFurniture
            {
                Id = 1,
                ReservationId = 1,
                FurnitureId = 1
            };
            for (int i = 0; i < 11; i++)
            {
                reservations.Add(new ReservationsFurniture
                {
                    Id = i + 1,
                    ReservationId = 1,
                    FurnitureId = i + 1
                });
            }
            _repositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(reservations);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => _service.AddAsync(reservation));
        }
    }
}
