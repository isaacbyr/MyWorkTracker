using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public EntryModel LoadEntry(DateTime Date, string UserId)
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

        public List<EntryModel> LoadEntries(string UserId, DateTime firstDate, DateTime lastDate)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { UserId = UserId, FirstDate = firstDate, LastDate = lastDate };
            try
            {
                var output = sql.LoadData<EntryModel, dynamic>("dbo.spGetEntriesByUserAndDates", p, "WTData");
                return output;
            }
            catch
            {
                return null;
            }
        }

        public List<SearchResultsModel> LoadSearchResults(string userId, string keyword, string category, string orderBy)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { UserId = userId, Keyword = keyword};

            if (category.Equals("Job") && orderBy.Equals("Date (Oldest)"))
            {

                try
                {
                    var output = sql.LoadData<SearchResultsModel, dynamic>("dbo.spGetSearchByJobOrderDate", p, "WTData");
                    return output;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            if (category.Equals("Job") && orderBy.Equals("Date (Newest)"))
            {

                try
                {
                    var output = sql.LoadData<SearchResultsModel, dynamic>("dbo.spGetSearchByJobOrderDateDesc", p, "WTData");
                    return output;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else if(category.Equals("Job") && orderBy.Equals("Total (Asc)"))
            {
                try
                {
                    var output = sql.LoadData<SearchResultsModel, dynamic>("dbo.spGetSearchByJobOrderTotalAsc", p, "WTData");
                    return output;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else if (category.Equals("Job") && orderBy.Equals("Total (Desc)"))
            {
                try
                {
                    var output = sql.LoadData<SearchResultsModel, dynamic>("dbo.spGetSearchByJobOrderTotalDesc", p, "WTData");
                    return output;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else if(category.Equals("Location") && orderBy.Equals("Date (Oldest)"))
            {
                try
                {
                    var output = sql.LoadData<SearchResultsModel, dynamic>("dbo.spGetSearchByLocationOrderDate", p, "WTData");
                    return output;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else if (category.Equals("Location") && orderBy.Equals("Date (Newest)"))
            {
                try
                {
                    var output = sql.LoadData<SearchResultsModel, dynamic>("dbo.spGetSearchByLocationOrderDateDesc", p, "WTData");
                    return output;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else if(category.Equals("Location") && orderBy.Equals("Total (Asc)"))
            {
                try
                {
                    var output = sql.LoadData<SearchResultsModel, dynamic>("dbo.spGetSearchByLocationOrderTotal", p, "WTData");
                    return output;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else if (category.Equals("Location") && orderBy.Equals("Total (Desc)"))
            {
                try
                {
                    var output = sql.LoadData<SearchResultsModel, dynamic>("dbo.spGetSearchByLocationOrderTotalDesc", p, "WTData");
                    return output;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                return null;
            }

        }

        public List<SearchResultsEmployeeModel> LoadAdminSearchResults(int companyId, string keyword, string category, string orderBy)
        {
            var sql = new SqlDataAccess();

            var p = new { CompanyId = companyId, Keyword = keyword };

            if (category.Equals("Job") && orderBy.Equals("Date (Oldest)"))
            {
                try
                {
                    var output = sql.LoadData<SearchResultsEmployeeModel, dynamic>("dbo.spAdminSearchByJobOrderDateAsc", p, "WTData");
                    return output;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else if (category.Equals("Job") && orderBy.Equals("Date (Newest)"))
            {
                try
                {
                    var output = sql.LoadData<SearchResultsEmployeeModel, dynamic>("dbo.spAdminSearchByJobOrderDateDesc", p, "WTData");
                    return output;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else if (category.Equals("Location") && orderBy.Equals("Date (Newest)"))
            {
                try
                {
                    var output = sql.LoadData<SearchResultsEmployeeModel, dynamic>("dbo.spAdminSearchByLocationOrderDateDesc", p, "WTData");
                    return output;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else if (category.Equals("Location") && orderBy.Equals("Date (Oldest)"))
            {
                try
                {
                    var output = sql.LoadData<SearchResultsEmployeeModel, dynamic>("dbo.spAdminSearchByLocationOrderDateAsc", p, "WTData");
                    return output;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else if (category.Equals("Location") && (orderBy.Equals("Total (Asc)") || orderBy.Equals("Total (Desc)")))
            {
                var param = new { CompanyId = companyId, Keyword = keyword, OrderBy = orderBy };

                try
                {
                    var output = sql.LoadData<SearchResultsEmployeeModel, dynamic>("dbo.spAdminSearchByLocationOrderTotal", param, "WTData");
                    return output;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else if (category.Equals("Job") && (orderBy.Equals("Total (Asc)") || orderBy.Equals("Total (Desc)")))
            {
                var param = new { CompanyId = companyId, Keyword = keyword, OrderBy = orderBy };

                try
                {
                    var output = sql.LoadData<SearchResultsEmployeeModel, dynamic>("dbo.spAdminSearchByJobOrderTotal", param, "WTData");
                    return output;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else if (category.Equals("Employee") && (orderBy.Equals("Total (Asc)") || orderBy.Equals("Total (Desc)")))
            {
                var param = new { CompanyId = companyId, Keyword = keyword, OrderBy = orderBy };

                try
                {
                    var output = sql.LoadData<SearchResultsEmployeeModel, dynamic>("dbo.spAdminSearchByEmployeeOrderTotal", param, "WTData");
                    return output;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else if (category.Equals("Employee") && (orderBy.Equals("Date (Newest)") || orderBy.Equals("Date (Oldest)")))
            {
                var param = new { CompanyId = companyId, Keyword = keyword, OrderBy = orderBy };

                try
                {
                    var output = sql.LoadData<SearchResultsEmployeeModel, dynamic>("dbo.spAdminSearchByEmployeeOrderDate", param, "WTData");
                    return output;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                return null;
            }

        }
    }
}
