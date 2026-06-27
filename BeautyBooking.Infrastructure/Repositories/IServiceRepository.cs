using BeautyBooking.Domain.Contracts;
using BeautyBooking.Domain.Models;
using BeautyBooking.SharedKernel.Helpers;
using BeautyBooking.SharedKernel.Parameters;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BeautyBooking.Infrastructure.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private readonly BeautyBookingDbContext _context;

        public ServiceRepository(BeautyBookingDbContext context)
            : base(context)
        {
            _context = context;
        }

        public PagedList<Service> GetServices(ServiceParameters sp)
        {
            var query = _context.Services
                .AsNoTracking();

            // FILTROWANIE

            if (!string.IsNullOrWhiteSpace(sp.Name))
            {
                query = query.Where(s =>
                    s.Name.Contains(sp.Name));
            }

            if (sp.MinPrice.HasValue)
            {
                query = query.Where(s =>
                    s.Price >= sp.MinPrice.Value);
            }

            if (sp.MaxPrice.HasValue)
            {
                query = query.Where(s =>
                    s.Price <= sp.MaxPrice.Value);
            }

            // SORTOWANIE

            if (!string.IsNullOrEmpty(sp.SortColumn))
            {
                var columnSelector =
                    new Dictionary<string, Expression<Func<Service, object>>>
                    {
                        { nameof(Service.Id), s => s.Id },
                        { nameof(Service.Name), s => s.Name },
                        { nameof(Service.Price), s => s.Price },
                        { nameof(Service.DurationMinutes), s => s.DurationMinutes }
                    };

                if (columnSelector.ContainsKey(sp.SortColumn))
                {
                    var selectedColumn =
                        columnSelector[sp.SortColumn];

                    query =
                        sp.SortDirection == SortDirection.ASC
                        ? query.OrderBy(selectedColumn)
                        : query.OrderByDescending(selectedColumn);
                }
            }

            // STRONICOWANIE

            return query.AsPagedList(
                sp.PageNumber,
                sp.PageSize);
        }
    }
}