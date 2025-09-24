using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OfficeCelebr8.Application.Features.Login
{
    public record LoginQuery(LoginDto dto): IRequest<string>;//returns jwt token 
    
}
