using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Data
{
    public class Company
    {


        public Company() { 
        
        
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Exchange { get; set; }

        public string Ticker { get; set; }

        public string ISIN { get; set; }

        public string WebSite { get; set; }



    }
}
