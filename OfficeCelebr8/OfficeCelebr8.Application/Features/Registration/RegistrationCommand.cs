using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;


namespace OfficeCelebr8.Application.Features.Registration
{
    public record RegistrationCommand( RegistrationDto Dto) :IRequest<int>;
    
}
