using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.DataAccess
{
    public class EntryData
    {
        public void SaveEntry(EntryModel newEntry)
        {
            SqlDataAccess sql = new SqlDataAccess();

            try
            {
                sql.StartTransaction("WTData");
                sql.SaveDataInTransaction("dbo.spNewEntry_Insert", newEntry);
                sql.CommitTransaction();
            }
            catch
            {
                sql.RollbackTransaction();
                throw;
            }
        }

        public EntryModel LoadEntry(string Date, string UserId)
        {
            SqlDataAccess sql = new SqlDataAccess();


            var p = new { JobDate = Date, UserId = UserId };
            try
            {
                var output = sql.LoadData<EntryModel, dynamic>("dbo.spGetEntryByDate", p, "WTData").First();
                return output;
            }
            catch
            {
                return null;
            }
            
        }

        public List<EntryModel> LoadEntries(string UserId)
        {
            SqlDataAccess sql = new SqlDataAccess();


            var p = new { UserId = UserId };
            try
            {
                var output = sql.LoadData<EntryModel, dynamic>("dbo.spGetEntriesByUserId", p, "WTData");
                return output;
            }
            catch
            {
                return null;
            }
        }
    }
}
