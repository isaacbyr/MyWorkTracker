using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.DataAccess
{
    public class UserData
    {
        public List<LoggedInUserModel> GetUserById(string Id)
        {
            var sql = new SqlDataAccess();

            var p = new { Id = Id };

            var output = sql.LoadData<LoggedInUserModel, dynamic>("dbo.spUserLookup", p, "WTData");

            return output;
        }

        public void PostNewUser(LoggedInUserModel user)
        {
            var sql = new SqlDataAccess();

            try
            {
                sql.StartTransaction("WTData");
                sql.SaveDataInTransaction("dbo.spInsertNewUser", user);
                sql.CommitTransaction();
            }
            catch (Exception e)
            {
                sql.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }

        public IsAdminUserModel LoadAdminStatus(string id)
        {
            var sql = new SqlDataAccess();

            var p = new { Id = id };

            var output = sql.LoadData<IsAdminUserModel, dynamic>("dbo.spIsUserAdmin", p, "WTData").First();

            return output;
        }

        public void ApproveUser(string id)
        {
            var sql = new SqlDataAccess();

            var p = new { Id = id };

            try
            {
                sql.StartTransaction("WTData");
                sql.SaveDataInTransaction("dbo.spApproveUser", p);
                sql.CommitTransaction();
            }
            catch (Exception e)
            {
                sql.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
    }
}
