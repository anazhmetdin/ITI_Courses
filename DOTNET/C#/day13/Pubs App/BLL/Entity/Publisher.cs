using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class Publisher: EntityBase
    {

        public string PubID { get; init; }

        string? name;
        public string? Name
        {
            get => name;
            set
            {
                if (value == null || (value.Length <= 40 && value != name))
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;
                    name = value;
                }
            }
        }

        string? city;
        public string? City
        {
            get => city;
            set
            {
                if (value == null || (value.Length <= 20 && value != city))
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;
                    city = value;
                }
            }
        }

        string? pubState;
        public string? PubState
        {
            get => pubState;
            set
            {
                if (value == null || (value.Length <= 2 && value != pubState))
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;
                    pubState = value;
                }
            }
        }

        string? country;
        public string? Country
        {
            get => country;
            set
            {
                if (value == null || (value.Length <= 30 && value != country))
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;
                    country = value;
                }
            }
        }

        private Publisher(string pubID)
        {
            PubID = pubID;
        }

        public static bool TryCreatePublisher(out Publisher? publisher, string pubID)
        {
            if (pubID.Length <= 4)
            {
                publisher = new (pubID);
                return true;
            }
            else
            {
                publisher = null;
                return false;
            }
        }
    }
}
