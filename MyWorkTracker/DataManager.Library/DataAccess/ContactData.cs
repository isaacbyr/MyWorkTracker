using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.DataAccess
{
    public class ContactData
    {
        public void PostContact(ContactModel contact)
        {
            var sql = new SqlDataAccess();
            var p = new
            {
                CompanyId = contact.CompanyId,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Address = contact.Address
            };

            try
            {
                sql.StartTransaction("WTData");
                sql.SaveDataInTransaction("dbo.spInsertContact", p);
                sql.CommitTransaction();
            }
            catch(Exception ex)
            {
                sql.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }

        public List<ContactModel> LoadContacts(int companyId)
        {
            var sql = new SqlDataAccess();

            var p = new { CompanyId = companyId };

            try
            {
                var output = sql.LoadData<ContactModel, dynamic>("dbo.spGetContacts", p, "WTData");
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
