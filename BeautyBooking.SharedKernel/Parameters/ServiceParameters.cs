using BeautyBooking.SharedKernel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyBooking.SharedKernel.Parameters
{
    public class ServiceParameters : QueryStringParameters
    {
        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public string? Name { get; set; }
    }
}
