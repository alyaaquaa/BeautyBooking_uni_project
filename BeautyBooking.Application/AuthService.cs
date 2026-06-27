using BeautyBooking.Domain.Contracts;
using BeautyBooking.Domain.Models;
using BeautyBooking.SharedKernel.Dto;

namespace BeautyBooking.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IBeautyBookingUnitOfWork _unitOfWork;

        public AuthService(IBeautyBookingUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LoggedUserDto> RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _unitOfWork.Users.GetByEmailAsync(dto.Email);

            if (existingUser != null)
                throw new Exception("Użytkownik o podanym adresie email już istnieje.");

            var user = new User
            {
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role
            };

            if (dto.Role == "Client")
            {
                var client = new Client
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber ?? ""
                };

                await _unitOfWork.Clients.AddAsync(client);
                await _unitOfWork.SaveChangesAsync();

                user.ClientId = client.Id;

                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.SaveChangesAsync();

                return new LoggedUserDto
                {
                    UserId = user.Id,
                    Email = user.Email,
                    Role = user.Role,
                    ClientId = client.Id,
                    EmployeeId = null,
                    FullName = $"{client.FirstName} {client.LastName}"
                };
            }

            if (dto.Role == "Employee")
            {
                var employee = new Employee
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    Position = dto.Position ?? "Pracownik"
                };

                await _unitOfWork.Employees.AddAsync(employee);
                await _unitOfWork.SaveChangesAsync();

                user.EmployeeId = employee.Id;

                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.SaveChangesAsync();

                return new LoggedUserDto
                {
                    UserId = user.Id,
                    Email = user.Email,
                    Role = user.Role,
                    ClientId = null,
                    EmployeeId = employee.Id,
                    FullName = $"{employee.FirstName} {employee.LastName}"
                };
            }

            throw new Exception("Nieprawidłowa rola użytkownika.");
        }

        public async Task<LoggedUserDto?> LoginAsync(LoginDto dto)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(dto.Email);

            if (user == null)
                return null;

            if (user.Password != dto.Password)
                return null;

            return new LoggedUserDto
            {
                UserId = user.Id,
                Email = user.Email,
                Role = user.Role,
                ClientId = user.ClientId,
                EmployeeId = user.EmployeeId,
                FullName = user.Client != null
                    ? $"{user.Client.FirstName} {user.Client.LastName}"
                    : user.Employee != null
                        ? $"{user.Employee.FirstName} {user.Employee.LastName}"
                        : user.Email
            };
        }
    }
}