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

        public EntryModel LoadEntry(string Date)
        {
            SqlDataAccess sql = new SqlDataAccess();

            string[] split = Date.Split('-');
            string convDate = split[2] + "-" + split[0] + "-" + split[1];

            var p = new { JobDate = convDate };
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
    }
}
