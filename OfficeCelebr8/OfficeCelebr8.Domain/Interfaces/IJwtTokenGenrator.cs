using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeCelebr8.Domain.Entities;

namespace OfficeCelebr8.Domain.Interfaces
{
    public interface IJwtTokenGenrator
    {
        string GenrateToken(User user);
    }
}
