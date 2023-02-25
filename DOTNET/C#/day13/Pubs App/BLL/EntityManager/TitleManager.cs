using BLL.Entity;
using BLL.EntityList;
using DAL;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace BLL.EntityManager
{
    public class TitleManager
    {
        static DBManager manager = new();

        public static bool UpdateTitle(Title title)
        {
            try
            {
                Dictionary<string, object> ParamDic = new() {
                    ["@titleID"] = title.TitleID,
                    ["@bookTitle"] = title.BookTitle,
                    ["@type"] = title.Type,
                    ["@pubID"] = title.PubID,
                    ["@price"] = title.Price,
                    ["@advance"] = title.Advance,
                    ["@royalty"] = title.Royalty,
                    ["@sales"] = title.Sales,
                    ["@notes"] = title.Notes,
                    ["@pubDate"] = title.PubDate
                };

                return manager.ExecuteNonQuery("UpdateTitleByTitleID", ParamDic) > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return false;
        }

        public static bool UpdateTitles(TitleList titles)
        {
            try
            {
                for (int i = titles.Count - 1; i >= 0; i--)
                {
                    if (titles[i].State == EntityState.Changed)
                    {
                        if (!UpdateTitle(titles[i]))
                            return false;

                        titles[i].State = EntityState.UnChanged;
                    }
                    else if (titles[i].State == EntityState.Added)
                    {
                        if (!InsertTitle(titles[i]))
                            return false;

                        titles[i].State = EntityState.UnChanged;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static TitleList SelectAllTitles()
        {
            try
            {
                return DataTableToTitleList(manager.ExecuteDataTable("SelectAllTitles"));
            }
            catch
            {
                return new TitleList();
            }
        }

        public static bool InsertTitle(Title title)
        {
            try
            {
                Dictionary<string, object> ParamDic = new()
                {
                    ["@titleID"] = title.TitleID,
                    ["@bookTitle"] = title.BookTitle,
                    ["@type"] = title.Type,
                    ["@pubID"] = title.PubID,
                    ["@price"] = title.Price,
                    ["@advance"] = title.Advance,
                    ["@royalty"] = title.Royalty,
                    ["@sales"] = title.Sales,
                    ["@notes"] = title.Notes,
                    ["@pubDate"] = title.PubDate
                };

                return manager.ExecuteNonQuery("InsertTitle", ParamDic) > 0;
            }
            catch
            {
            }
            
            return false;
        }

        public static void DeleteTitle(Title title)
        {
            if (title.State != EntityState.Added)
                title.State = EntityState.Deleted;
        }
        public static bool DeleteTitleByTitleID(string titleID)
        {
            try
            {
                Dictionary<string, object> ParamDic = new()
                {
                    ["@titleID"] = titleID
                };

                return manager.ExecuteNonQuery("DeleteTitleByTitleID", ParamDic) > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return false;
        }

        public static Title? AddTitle(string id, string bookTitle, DateTime pubDate)
        {
            Title? title = null;
            
            Title.TryCreateTitle(out title, id, bookTitle, pubDate);

            if (title != null)
                title.State = EntityState.Added;

            return title;
        }


        #region Mapping

        internal static TitleList DataTableToTitleList(DataTable Dt)
        {
            TitleList titleLst = new();
            try
            {
                Title? title;
                foreach (DataRow row in Dt.Rows)
                    if ((title = DataRowToTitle(row)) != null)
                        titleLst.Add(title);
            }
            catch
            {

            }
            return titleLst;
        }

        internal static Title? DataRowToTitle(DataRow Dr)
        {
            Title? title = null;
            try
            {
                Title.TryCreateTitle(out title, Dr["title_id"].ToString(), Dr["title"].ToString(), (DateTime)Dr["pubdate"] ,Dr["type"].ToString());

                if (title != null)
                {
                    decimal.TryParse(Dr["price"]?.ToString(), out decimal TempDecimal);
                    title.Price = TempDecimal;

                    title.PubID = Dr["pub_id"]?.ToString();

                    decimal.TryParse(Dr["advance"]?.ToString(), out TempDecimal);
                    title.Advance = TempDecimal;

                    int.TryParse(Dr["royalty"]?.ToString(), out int TempInt);
                    title.Royalty = TempInt;

                    int.TryParse(Dr["ytd_sales"]?.ToString(), out TempInt);
                    title.Sales = TempInt;

                    title.Notes = Dr["notes"]?.ToString();

                    title.State = EntityState.UnChanged;
                }
            }
            catch
            {

            }

            return title;
        }

        public static bool DeleteTitles(TitleList titles)
        {
            try
            {
                for (int i = titles.Count - 1; i >= 0; i--)
                {
                    if (titles[i].State == EntityState.Deleted)
                    {
                        if (!DeleteTitleByTitleID(titles[i].TitleID))
                            return false;
                    }
                    
                    titles.Remove(titles[i]);
                }

                return true;
            }
            catch { return false; }

        }
        #endregion

    }
}
