using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Mocking;

namespace TestApp.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests_GetOverlappingBookings
    {
        private Mock<IBookingRepository> _bookingRepositoryMock;
        private Booking _existingBooking;

        [SetUp]
        public void Setup()
        {
            _bookingRepositoryMock = new Mock<IBookingRepository>();
            _existingBooking = new Booking
            {
                Id = 2,
                ArrivalDate = new DateTime(2024, 3, 20, 18, 0, 0),
                DepartureDate = new DateTime(2024, 3, 25, 10, 0, 0),
                Reference = "a"
            };

            _bookingRepositoryMock.Setup((bkr) => bkr.GetActiveBookings(1)).Returns(new List<Booking>
            {
                _existingBooking
            }.AsQueryable());
        }

        [Test]
        public void StartsAndFinishesBeforeExistingBooking_ReturnsEmptyString()
        {
            // Arrange


            // Act
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = new DateTime(2024, 3, 15, 18, 0, 0),
                DepartureDate = new DateTime(2024, 3, 19, 10, 0, 0),
                Reference = "b"
            }, _bookingRepositoryMock.Object);

            // Assert
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void StartsBeforeExistingBookingAndEndsInMiddleOfExistingBooking_ReturnsExistingBookingReference()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = new DateTime(2024, 3, 14, 18, 0, 0),
                DepartureDate = new DateTime(2024, 3, 23, 10, 0, 0),
            }, _bookingRepositoryMock.Object);

            // Assert
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }

        [Test]
        public void BookingStartsAndFinishesInTheMiddle0fAnExistingBooking_ReturnExistingBooking()
        {

        }

        [Test]
        public void BookingStartsInTheMiddle0fAnExistingBookingButFinishesAfter_ReturnExistingBooking()
        {

        }

        [Test]
        public void BookingStartsAndFinishesAfterAnExistingBooking_ReturnEmptyString()
        {

        }
    }
}
