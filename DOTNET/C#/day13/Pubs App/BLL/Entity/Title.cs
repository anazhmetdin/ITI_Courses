using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class Title: EntityBase
    {
        public string TitleID { get; init; }

        string bookTitle;
        public string BookTitle
        {
            get => bookTitle;
            set
            {
                if (value.Length <= 80 && value != bookTitle)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;
                    bookTitle = value;
                }
            }
        }

        string type;
        public string Type
        {
            get => type;
            set
            {
                if (value.Length <= 12 && value != type)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;
                    type = value;
                }
            }
        }

        string? pubID;
        public string? PubID
        {
            get => pubID;
            set
            {
                if (value == "") value = null;

                if (value == null || (value.Length <= 4 && value != pubID))
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;
                    pubID = value;
                }
            }
        }

        decimal? price { get; set; }
        public decimal? Price
        {
            get => price;
            set
            {
                if (value != price)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;
                    price = value;
                }
            }
        }

        decimal? advance { get; set; }
        public decimal? Advance
        {
            get => advance;
            set
            {
                if (value != advance)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;
                    advance = value;
                }
            }
        }

        int? royalty { get; set; }
        public int? Royalty
        {
            get => royalty;
            set
            {
                if (value != royalty)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;
                    royalty = value;
                }
            }
        }

        int? sales { get; set; }
        public int? Sales
        {
            get => sales;
            set
            {
                if (value != sales)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;
                    sales = value;
                }
            }
        }

        string? notes;
        public string? Notes
        {
            get => notes;
            set
            {
                if (value == null || (value.Length <= 200 && value != notes))
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;
                    notes = value;
                }
            }
        }

        DateTime pubDate;
        public DateTime PubDate
        {
            get => pubDate;
            set
            {
                if (value != pubDate)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;
                    pubDate = value;
                }
            }
        }

        private Title(string titleID, string title, DateTime pubDate, string type = "UNDECIDED") 
        {
            TitleID = titleID;
            bookTitle = title;
            this.pubDate = pubDate;
            this.type = type;
        }

        public static bool TryCreateTitle(out Title? title, string titleID, string bookTitle, DateTime pubDate, string type = "UNDECIDED")
        {
            if (titleID.Length <= 6 && bookTitle.Length <= 80 && type.Length <= 12)
            {
                title =  new (titleID, bookTitle, pubDate, type);
                return true;
            }
            else
            {
                title = null;
                return false;
            }
        }
    }
}
