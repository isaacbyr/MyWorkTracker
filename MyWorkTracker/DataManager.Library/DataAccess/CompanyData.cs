using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.DataAccess
{
    public class CompanyData
    {
        public void PostCompany(CompanyModel company)
        {
            var sql = new SqlDataAccess();

            try
            {
                sql.StartTransaction("WTData");
                sql.SaveDataInTransaction("dbo.spInsertCompany", company);
                sql.CommitTransaction();
            }
            catch (Exception e)
            {
                sql.RollbackTransaction();
                throw new Exception(e.Message);
            }

        }

        public CompanyModel GetCompanyInfo(string id)
        {
            var sql = new SqlDataAccess();
            var p = new { OwnerId = id };

            try
            {
                var output = sql.LoadData<CompanyModel, dynamic>("dbo.spGetCompanyInfo", p, "WTData").First();
                return output;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void PostEmployee(EmployeeModel employee)
        {
            var sql = new SqlDataAccess();

            try
            {
                sql.StartTransaction("WTData");
                sql.SaveDataInTransaction("dbo.spInsertEmployee", employee);
                sql.CommitTransaction();
            }
            catch (Exception e)
            {
                sql.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }

        public List<EmployeeUserModel> GetEmployees(int companyId)
        {
            var sql = new SqlDataAccess();
            var p = new { CompanyId = companyId };
            try
            {
                var output = sql.LoadData<EmployeeUserModel, dynamic>("dbo.spGetEmployees", p, "WTData");
                return output;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<EmployeeDataModel> GetEmployeeEntries(DateTime date, int companyId)
        {
            var sql = new SqlDataAccess();
            // TODO: Change CompanyId to Parameter
            var p = new { JobDate = date, CompanyId = companyId };

            try
            {
                var output = sql.LoadData<EmployeeDataModel, dynamic>("dbo.spGetEmployeeEntries", p, "WTData");
                return output;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int LoadCompanyId(string id)
        {
            var sql = new SqlDataAccess();

            var p = new { UserId = id };

            try
            {
                var output = sql.LoadData<int, dynamic>("dbo.spGetCompanyId", p, "WTData").First();
                return output;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public EmployeeUserModel LoadOwnerInfo(int companyId)
        {
            var sql = new SqlDataAccess();

            var p = new { CompanyId = companyId };

            try
            {
                var output = sql.LoadData<EmployeeUserModel, dynamic>("dbo.spLoadOwnerInfo", p, "WTData").First();
                return output;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
