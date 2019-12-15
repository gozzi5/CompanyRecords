using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.ViewModels
{
    public class CompanyViewModel
    {

        public int Id { get; set; }
        
        public string Name { get; set; }
       
        public string Ticker { get; set; }
        
        public string ISIN { get; set; }

        public string Exchange { get; set; }
        

        public string WebSite { get; set; }
    }
}
