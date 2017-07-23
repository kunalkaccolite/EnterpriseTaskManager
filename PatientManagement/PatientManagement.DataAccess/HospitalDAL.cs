using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagement.Common;
using System.Data.SqlClient;

namespace PatientManagement.DataAccess
{
    public class HospitalDAL : IHospitalDAL
    {
        public bool CheckInsuranceDetails(string PatientId)
        {
            try
            {

                SqlParameter[] SqlParamArray = new SqlParameter[1];
                SqlParamArray[0] = new SqlParameter("@PatientId", PatientId);

                SqlHelper sqlHelper = new SqlHelper();
                int DoesInsuranceExists = (int)sqlHelper.ExecuteScalar(DataAccess.SQLQueriesConstants.sp_checkInsuranceDetails, SqlParamArray);
                return Convert.ToBoolean(DoesInsuranceExists);

            }
            catch (Exception e)
            {
                //log exception;
                return false;

            }
        }

        public bool InsertInsuranceDetails(Insurance insurance)
        {
            try
            {
                SqlParameter[] arrSqlParam = new SqlParameter[10];

                arrSqlParam[0] = new SqlParameter("@PatientId", insurance.PatientId);
                arrSqlParam[1] = new SqlParameter("@InsurancePlanId", insurance.InsurancePlanId);
                arrSqlParam[2] = new SqlParameter("@InsuranceCompanyId", insurance.InsuranceCompanyId);
                arrSqlParam[3] = new SqlParameter("@InsuranceCompanyName", insurance.InsuranceCompanyName);
                arrSqlParam[4] = new SqlParameter("@InsuredSGroupEmpId", insurance.InsuredSGroupEmpId);
                arrSqlParam[5] = new SqlParameter("@InsuredSGroupEmpName", insurance.InsuredSGroupEmpName);
                
                arrSqlParam[6] = new SqlParameter("@PlanEffectiveDate", insurance.PlanEffectiveDate);
                arrSqlParam[6].DbType = System.Data.DbType.DateTime;
                arrSqlParam[7] = new SqlParameter("@PlanExpirationDate", insurance.PlanExpirationDate);
                arrSqlParam[7].DbType = System.Data.DbType.DateTime;
                arrSqlParam[8] = new SqlParameter("@PlanType", insurance.PlanType);
                arrSqlParam[9] = new SqlParameter("@CreatedBy", insurance.CreatedBy);
                SqlHelper sqlHelper = new SqlHelper();

                sqlHelper.ExecuteNonQuery(DataAccess.SQLQueriesConstants.sp_InsertInsurance, arrSqlParam);
                return true;
            }
            catch (Exception ex)
            {

                //log exception
                return false;
            }
        }

        public bool InsertPatientEncounterDetails(PatientEncounter patient)
        {
            try
            {
                SqlParameter[] SqlParamArray = new SqlParameter[10];

                SqlParamArray[0] = new SqlParameter("@PatientId", patient.PatientId);
                SqlParamArray[1] = new SqlParameter("@PatientName", patient.Name);
                SqlParamArray[2] = new SqlParameter("@Sex", patient.Sex);
                SqlParamArray[3] = new SqlParameter("@DOB", patient.DOB);
                SqlParamArray[3].DbType = System.Data.DbType.Date;
                SqlParamArray[4] = new SqlParameter("@Address", patient.Address);
                SqlParamArray[5] = new SqlParameter("@PhoneNo", patient.PhoneNo);
                SqlParamArray[6] = new SqlParameter("@DoctorId", patient.DoctorId);
                SqlParamArray[7] = new SqlParameter("@ProcedureCode", patient.ProcedureCode);
                SqlParamArray[8] = new SqlParameter("@Status", patient.Status);
                SqlParamArray[9] = new SqlParameter("@CreatedBy", patient.CreatedBy);
                SqlHelper sqlHelper = new SqlHelper();

                sqlHelper.ExecuteNonQuery(DataAccess.SQLQueriesConstants.sp_InsertPatientEncounterDetails, SqlParamArray);
                return true;
            }
            catch (Exception ex)
            {

                //log exception
                return false;
            }
        }


        public bool UpdateEncounter(UpdateEncounter encounter)
        {
            try
            {
                SqlParameter[] SqlParamArray = new SqlParameter[3];

                SqlParamArray[0] = new SqlParameter("@EncounterID", encounter.EncounterId);
                SqlParamArray[1] = new SqlParameter("@Status", encounter.Status);
                SqlParamArray[2] = new SqlParameter("@UpdatedBy", encounter.UpdatedBy);
                SqlHelper sqlHelper = new SqlHelper();

                sqlHelper.ExecuteNonQuery(DataAccess.SQLQueriesConstants.sp_UpdateEncounter, SqlParamArray);
                return true;
            }
            catch (Exception ex)
            {

                //log exception
                return false;
            }
        }
    }
}

