using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Fundamentals
{
    public class Reservation
    {
        public User MadeBy { get; set; }

        public bool CanBeCancelledBy(User user)
        {
            return (user.IsAdmin || MadeBy == user);
        }

        // public Func<User, bool> CanBeCancelledBy => (User user) => (user.IsAdmin || MadeBy == user);
    }

    public class User
    {
        public bool IsAdmin { get; set; }
    }
}
