using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Common
{
    public class Insurance
    {
        public long ID { get; set; }
        public string PatientId { get; set; }
        public string InsurancePlanId { get; set; }
        public string InsuranceCompanyId { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string InsuredSGroupEmpId { get; set; }
        public string InsuredSGroupEmpName { get; set; }
        public string PlanType { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime PlanEffectiveDate { get; set; }
        public DateTime PlanExpirationDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
