using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BeautyBooking.SharedKernel.Dto;

namespace BeautyBooking.Application.Services
{
    public interface IAuthService
    {
        Task<LoggedUserDto> RegisterAsync(RegisterDto dto);

        Task<LoggedUserDto?> LoginAsync(LoginDto dto);
    }
}
