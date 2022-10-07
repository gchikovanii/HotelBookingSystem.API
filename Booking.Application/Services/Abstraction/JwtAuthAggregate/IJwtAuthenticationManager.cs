using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Services.Abstraction.JwtAuthAggregate
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(bool status, string email, List<string> roles);
    }
}
