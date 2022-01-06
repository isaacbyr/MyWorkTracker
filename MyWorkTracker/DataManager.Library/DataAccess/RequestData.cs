using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.DataAccess
{
    public class RequestData
    {
        public List<UserRequestModel> GetRequests(int companyId)
        {
            var sql = new SqlDataAccess();

            var p = new { CompanyId = companyId };

            try
            {
                var output = sql.LoadData<UserRequestModel, dynamic>("dbo.spGetRequests", p, "WTData");
                return output;
            }
            catch
            {
                return null;
            }
        }


        public void PostRequest(ApprovalRequestModel approvalReq)
        {
            var sql = new SqlDataAccess();

            try
            {
                sql.StartTransaction("WTData");
                sql.SaveDataInTransaction("dbo.spInsertRequest", approvalReq);
                sql.CommitTransaction();
            }
            catch (Exception e)
            {
                sql.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
        
        public void DeleteRequest(string id)
        {
            var sql = new SqlDataAccess();

            var p = new { UserId = id };

            try
            {
                var output = sql.LoadData<UserRequestModel, dynamic>("dbo.spDeleteRequestByUserId", p, "WTData");
                return;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
