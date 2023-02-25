using BLL.Entity;
using BLL.EntityList;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityManager
{
    public class PublisherManager
    {
        static DBManager manager = new();

        public static PublisherList SelectAllPublishers()
        {
            try
            {
                return DataTableToPublisherList(manager.ExecuteDataTable("SelectAllPublishers"));
            }
            catch
            {
                return new PublisherList();
            }
        }

        #region Mapping

        internal static PublisherList DataTableToPublisherList(DataTable Dt)
        {
            PublisherList publisherList = new();
            try
            {
                Publisher? publisher;
                foreach (DataRow row in Dt.Rows)
                    if ((publisher = DataRowToPublisher(row)) != null)
                        publisherList.Add(publisher);
            }
            catch
            {

            }
            return publisherList;
        }

        internal static Publisher? DataRowToPublisher(DataRow Dr)
        {
            Publisher? publisher = null;
            try
            {
                Publisher.TryCreatePublisher(out publisher, Dr["pub_id"].ToString());

                if (publisher != null)
                {
                    publisher.Name = Dr["pub_name"]?.ToString();
                    publisher.City = Dr["city"]?.ToString();
                    publisher.PubState = Dr["state"]?.ToString();
                    publisher.Country = Dr["country"]?.ToString();

                    publisher.State = EntityState.UnChanged;
                }
            }
            catch
            {

            }

            return publisher;
        }

        #endregion
    }
}
