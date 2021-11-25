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

        public EntryModel LoadEntry()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<EntryModel, dynamic>("dbo.sp_Entry_GetAll", new { }, "WTData").First();
            return output;
                
        }
    }
}
