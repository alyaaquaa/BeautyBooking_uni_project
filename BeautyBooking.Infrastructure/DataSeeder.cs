using BeautyBooking.Domain.Models;

namespace BeautyBooking.Infrastructure
{
    public class DataSeeder
    {
        private readonly BeautyBookingDbContext _context;

        public DataSeeder(BeautyBookingDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (!_context.Clients.Any())
            {
                _context.Clients.AddRange(
                    new Client { FirstName = "Anna", LastName = "Kowalska", Email = "anna.kowalska@example.com", PhoneNumber = "500100200" },
                    new Client { FirstName = "Maria", LastName = "Nowak", Email = "maria.nowak@example.com", PhoneNumber = "600300400" },
                    new Client { FirstName = "Karolina", LastName = "Wiśniewska", Email = "karolina.wisniewska@example.com", PhoneNumber = "501222333" },
                    new Client { FirstName = "Natalia", LastName = "Zielińska", Email = "natalia.zielinska@example.com", PhoneNumber = "502333444" },
                    new Client { FirstName = "Julia", LastName = "Wójcik", Email = "julia.wojcik@example.com", PhoneNumber = "503444555" },
                    new Client { FirstName = "Magdalena", LastName = "Kamińska", Email = "magdalena.kaminska@example.com", PhoneNumber = "504555666" },
                    new Client { FirstName = "Aleksandra", LastName = "Lewandowska", Email = "aleksandra.lewandowska@example.com", PhoneNumber = "505666777" },
                    new Client { FirstName = "Paulina", LastName = "Dąbrowska", Email = "paulina.dabrowska@example.com", PhoneNumber = "506777888" },
                    new Client { FirstName = "Klaudia", LastName = "Kozłowska", Email = "klaudia.kozlowska@example.com", PhoneNumber = "507888999" },
                    new Client { FirstName = "Wiktoria", LastName = "Mazur", Email = "wiktoria.mazur@example.com", PhoneNumber = "508999000" }
                );
            }

            if (!_context.Employees.Any())
            {
                _context.Employees.AddRange(
                    new Employee { FirstName = "Katarzyna", LastName = "Wisniewska", Email = "katarzyna.wisniewska@beautybooking.pl", Position = "Kosmetyczka" },
                    new Employee { FirstName = "Olga", LastName = "Zielinska", Email = "olga.zielinska@beautybooking.pl", Position = "Stylistka paznokci" },
                    new Employee { FirstName = "Monika", LastName = "Nowicka", Email = "monika.nowicka@beautybooking.pl", Position = "Specjalistka brwi" },
                    new Employee { FirstName = "Ewa", LastName = "Kaczmarek", Email = "ewa.kaczmarek@beautybooking.pl", Position = "Makijażystka" },
                    new Employee { FirstName = "Agnieszka", LastName = "Pawlak", Email = "agnieszka.pawlak@beautybooking.pl", Position = "Kosmetolog" },
                    new Employee { FirstName = "Joanna", LastName = "Krol", Email = "joanna.krol@beautybooking.pl", Position = "Masażystka" },
                    new Employee { FirstName = "Marta", LastName = "Sikora", Email = "marta.sikora@beautybooking.pl", Position = "Stylistka rzęs" },
                    new Employee { FirstName = "Patrycja", LastName = "Baran", Email = "patrycja.baran@beautybooking.pl", Position = "Recepcjonistka" },
                    new Employee { FirstName = "Dorota", LastName = "Lis", Email = "dorota.lis@beautybooking.pl", Position = "Specjalistka SPA" },
                    new Employee { FirstName = "Izabela", LastName = "Wrobel", Email = "izabela.wrobel@beautybooking.pl", Position = "Podolog" }
                );
            }

            if (!_context.Services.Any())
            {
                _context.Services.AddRange(
                    new Service { Name = "Manicure hybrydowy", Description = "Stylizacja paznokci metodą hybrydową.", Price = 120, DurationMinutes = 90 },
                    new Service { Name = "Pedicure kosmetyczny", Description = "Podstawowy zabieg pielęgnacyjny stóp.", Price = 140, DurationMinutes = 75 },
                    new Service { Name = "Laminacja brwi", Description = "Stylizacja i utrwalenie kształtu brwi.", Price = 100, DurationMinutes = 60 },
                    new Service { Name = "Regulacja brwi", Description = "Nadanie odpowiedniego kształtu brwiom.", Price = 50, DurationMinutes = 30 },
                    new Service { Name = "Henna brwi i rzęs", Description = "Koloryzacja brwi i rzęs.", Price = 70, DurationMinutes = 45 },
                    new Service { Name = "Przedłużanie rzęs", Description = "Profesjonalne przedłużanie rzęs.", Price = 220, DurationMinutes = 120 },
                    new Service { Name = "Makijaż okolicznościowy", Description = "Makijaż na specjalne okazje.", Price = 180, DurationMinutes = 90 },
                    new Service { Name = "Masaż relaksacyjny", Description = "Masaż całego ciała.", Price = 160, DurationMinutes = 60 },
                    new Service { Name = "Zabieg oczyszczający twarz", Description = "Oczyszczanie i pielęgnacja twarzy.", Price = 200, DurationMinutes = 90 },
                    new Service { Name = "Depilacja woskiem", Description = "Usuwanie owłosienia metodą woskową.", Price = 90, DurationMinutes = 45 }
                );
            }

            await _context.SaveChangesAsync();

            if (!_context.Users.Any())
            {
                var clients = _context.Clients.ToList();
                var employees = _context.Employees.ToList();

                foreach (var client in clients)
                {
                    _context.Users.Add(new User
                    {
                        Email = client.Email,
                        Password = "client123",
                        Role = "Client",
                        ClientId = client.Id
                    });
                }

                foreach (var employee in employees)
                {
                    _context.Users.Add(new User
                    {
                        Email = employee.Email,
                        Password = "employee123",
                        Role = "Employee",
                        EmployeeId = employee.Id
                    });
                }

                await _context.SaveChangesAsync();
            }

            if (!_context.Reservations.Any())
            {
                var clients = _context.Clients.ToList();
                var employees = _context.Employees.ToList();
                var services = _context.Services.ToList();

                var reservationNumber = 1;

                foreach (var client in clients)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        var employee = employees[(reservationNumber + i) % employees.Count];

                        var firstService = services[(reservationNumber + i) % services.Count];
                        var secondService = services[(reservationNumber + i + 2) % services.Count];

                        var reservation = new Reservation
                        {
                            ClientId = client.Id,
                            EmployeeId = employee.Id,
                            ReservationDate = DateTime.Now.AddDays(reservationNumber + i),
                            Status = "Zaplanowana",
                            Notes = i == 0 ? "Pierwsza rezerwacja klienta." : "Druga rezerwacja klienta."
                        };

                        _context.Reservations.Add(reservation);
                        await _context.SaveChangesAsync();

                        _context.ReservationItems.AddRange(
                            new ReservationItem { ReservationId = reservation.Id, ServiceId = firstService.Id },
                            new ReservationItem { ReservationId = reservation.Id, ServiceId = secondService.Id }
                        );

                        await _context.SaveChangesAsync();

                        reservationNumber++;
                    }
                }
            }

            if (!_context.Payments.Any())
            {
                var reservations = _context.Reservations.ToList();
                var reservationItems = _context.ReservationItems.ToList();
                var services = _context.Services.ToList();

                foreach (var reservation in reservations)
                {
                    var serviceIds = reservationItems
                        .Where(x => x.ReservationId == reservation.Id)
                        .Select(x => x.ServiceId)
                        .ToList();

                    var amount = services
                        .Where(s => serviceIds.Contains(s.Id))
                        .Sum(s => s.Price);

                    _context.Payments.Add(
                        new Payment
                        {
                            ReservationId = reservation.Id,
                            Amount = amount,
                            PaymentDate = DateTime.Now,
                            PaymentMethod = "Gotówka",
                            IsPaid = true
                        }
                    );
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}