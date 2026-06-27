using BeautyBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautyBooking.Domain.Models;
using BeautyBooking.SharedKernel.Helpers;
using BeautyBooking.SharedKernel.Parameters;

namespace BeautyBooking.Domain.Contracts
{
    public interface IServiceRepository : IRepository<Service>
    {
        PagedList<Service> GetServices(ServiceParameters parameters);
    }
}
