using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Services.Util
{
    public static  class CompanyValidation
    {


        public static Validation ValidationForCompany(CompanyViewModel companyViewModel) {

            Validation validation = new Validation();

            
            if (!IsFieldsValid(companyViewModel)) {

                validation.Valid = false;
                validation.Message = "missing required fields";

                return validation;
            }
            if (!IsIsinValid(companyViewModel.ISIN))
            {

                validation.Valid = false;
                validation.Message = "isin is not valid";

                return validation;
            }


            validation.Valid = true;

            return validation;
        }
        public static bool IsFieldsValid(CompanyViewModel companyViewModel)
        {
          

            if (String.IsNullOrEmpty(companyViewModel.ISIN))
            {
              return false;
                          
            }
            if (String.IsNullOrEmpty(companyViewModel.Ticker))
            {
                return false;
            }
            if (String.IsNullOrEmpty(companyViewModel.Name))
            {
                return false;
            }

            return true;
        }
        public static bool IsIsinValid(string isin) {

            var regex = "([A-Z]{2})([A-Z0-9]{9})([0-9]{1})";
            var match = Regex.Match(isin, regex, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                return false;
                // does not match
            }
            return true;

        }
    }
}
