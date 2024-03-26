using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Mocking
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetActiveBookings(int? excludedId);
    }

    internal class BookingRepository : IBookingRepository
    {
        public IQueryable<Booking> GetActiveBookings(int? excludedId = null)
        {
            var unitOfWork = new UnitOfWork();
            var bookings =
                unitOfWork.Query<Booking>()
                    .Where(
                        b => b.Status != "Cancelled");

            if (excludedId != null)
                bookings = bookings.Where(b => b.Id != excludedId);

            return bookings;
        }
    }
}
