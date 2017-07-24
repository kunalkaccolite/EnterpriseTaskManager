using PatientManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.DataAccess
{
	public interface IHospitalDAL
	{
        bool CheckInsuranceDetails(string patientId);


        bool InsertInsuranceDetails(Insurance insurance);


        bool InsertPatientEncounterDetails(PatientEncounter patient);


        bool UpdateEncounter(UpdateEncounter encounter);

        PatientEncounter GetPatientDetails(string PatientId);

        Insurance GetInsuranceDetails(string PatientId);

        bool UpdateInsuranceDetails(Insurance insurance);

    }
}
