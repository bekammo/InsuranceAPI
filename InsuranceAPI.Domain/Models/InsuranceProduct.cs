using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InsuranceAPI.Domain.Models
{
    public class InsuranceProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Premium { get; set; }
        public decimal CoverageAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int InsuredId { get; set; }

        [JsonIgnore] 
        public Insured Insured { get; set; } = default!;
    }

}
