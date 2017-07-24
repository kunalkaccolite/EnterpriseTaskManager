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
                arrSqlParam[7] = new SqlParameter("@PlanExpirationDate", insurance.PlanExpirationDate);
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

        public bool UpdateInsuranceDetails(Insurance insurance)
        {
            try
            {
                SqlParameter[] arrSqlParam = new SqlParameter[12];

                arrSqlParam[0] = new SqlParameter("@PatientId", insurance.PatientId);
                arrSqlParam[1] = new SqlParameter("@InsurancePlanId", insurance.InsurancePlanId);
                arrSqlParam[2] = new SqlParameter("@InsuranceCompanyId", insurance.InsuranceCompanyId);
                arrSqlParam[3] = new SqlParameter("@InsuranceCompanyName", insurance.InsuranceCompanyName);
                arrSqlParam[4] = new SqlParameter("@InsuredSGroupEmpId", insurance.InsuredSGroupEmpId);
                arrSqlParam[5] = new SqlParameter("@InsuredSGroupEmpName", insurance.InsuredSGroupEmpName);
                arrSqlParam[6] = new SqlParameter("@PlanEffectiveDate", insurance.PlanEffectiveDate);
                arrSqlParam[7] = new SqlParameter("@PlanExpirationDate", insurance.PlanExpirationDate);
                arrSqlParam[8] = new SqlParameter("@PlanType", insurance.PlanType);
                arrSqlParam[9] = new SqlParameter("@CreatedBy", insurance.CreatedBy);
                arrSqlParam[10] = new SqlParameter("@CreateDate", insurance.CreateDate);
                arrSqlParam[11] = new SqlParameter("@ModifiedDate", insurance.ModifiedDate);
                SqlHelper sqlHelper = new SqlHelper();

                sqlHelper.ExecuteNonQuery(DataAccess.SQLQueriesConstants.sp_UpdateInsuranceDetails, arrSqlParam);
                return true;
            }
            catch (Exception e)
            {
                //log exception
                return false;
            }

        }

        public Insurance GetInsuranceDetails(string PatientId)
        {
            try
            {
                SqlParameter[] SqlParamArray = new SqlParameter[1];
                SqlParamArray[0] = new SqlParameter("@PatientId", PatientId);
                var insurance = new Insurance();
                SqlHelper sqlHelper = new SqlHelper();
                using (SqlDataReader rdr = sqlHelper.ExecuteDataReader(SQLQueriesConstants.sp_GetInsuranceDetails, SqlParamArray))
                {
                    while (rdr.Read())
                    {
                        int index = rdr.GetOrdinal("ID");
                        insurance.ID = !rdr.IsDBNull(index) ? rdr.GetInt64(index) : 0;
                        index = rdr.GetOrdinal("PatientId");
                        insurance.PatientId = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        index = rdr.GetOrdinal("InsurancePlanId");
                        insurance.InsurancePlanId = insurance.PatientId = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        index = rdr.GetOrdinal("InsuranceCompanyId");
                        insurance.InsuranceCompanyId = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        index = rdr.GetOrdinal("InsuranceCompanyName");
                        insurance.InsuranceCompanyName = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        index = rdr.GetOrdinal("InsuredSGroupEmpId");
                        insurance.InsuredSGroupEmpId = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        index = rdr.GetOrdinal("InsuredSGroupEmpName");
                        insurance.InsuredSGroupEmpName = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        index = rdr.GetOrdinal("PlanEffectiveDate");
                        insurance.PlanEffectiveDate = !rdr.IsDBNull(index) ? rdr.GetDateTime(index) : DateTime.MinValue;
                        index = rdr.GetOrdinal("PlanExpirationDate");
                        insurance.PlanExpirationDate = !rdr.IsDBNull(index) ? rdr.GetDateTime(index) : DateTime.MinValue;
                        index = rdr.GetOrdinal("PlanType");
                        insurance.PlanType = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        index = rdr.GetOrdinal("CreatedBy");
                        insurance.CreatedBy = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        index = rdr.GetOrdinal("CreateDate");
                        insurance.CreateDate = !rdr.IsDBNull(index) ? rdr.GetDateTime(index) : DateTime.MinValue;
                        index = rdr.GetOrdinal("ModifiedBy");
                        insurance.ModifiedBy = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                        index = rdr.GetOrdinal("ModifiedDate");
                        insurance.ModifiedDate = !rdr.IsDBNull(index) ? rdr.GetDateTime(index) : DateTime.MinValue;

                    }
                    return insurance;
                }
            }
            catch (Exception e)
            {
                //log exception
                return null;
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


        public PatientEncounter GetPatientDetails(string PatientId)
        {
            try
            {
                SqlParameter[] SqlParamArray = new SqlParameter[1];
                SqlParamArray[0] = new SqlParameter("@PatientId", PatientId);
                var patient = new PatientEncounter();
                SqlHelper sqlHelper = new SqlHelper();
                SqlDataReader rdr = sqlHelper.ExecuteDataReader(SQLQueriesConstants.sp_GetPatientDetails, SqlParamArray);
                while (rdr.Read())
                {
                    int index = rdr.GetOrdinal("Name");
                    patient.Name = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                    index = rdr.GetOrdinal("PhoneNo");
                    patient.PhoneNo = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                    index = rdr.GetOrdinal("Sex");
                    patient.Sex = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                    index = rdr.GetOrdinal("Address");
                    patient.Address = !rdr.IsDBNull(index) ? rdr.GetString(index) : null;
                    index = rdr.GetOrdinal("DOB");
                    patient.DOB = !rdr.IsDBNull(index) ? rdr.GetDateTime(index) : DateTime.MinValue;
                }
                return patient;
            }
            catch (Exception e)
            {

                return null;
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

