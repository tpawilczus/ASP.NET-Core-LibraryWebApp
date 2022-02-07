using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryWebApp.Validators
{
    public class ISBNValidator : ValidationAttribute
    {
        static Regex ISBNRegex = new Regex("^(?=(?:\\D*\\d){10}(?:(?:\\D*\\d){3})?$)[\\d-]+$");
        public override bool IsValid(object value)
        {
            string isbn = (string)value;
            try
            {
                return ISBNRegex.IsMatch(isbn);
            }
            catch
            {
                return false;
            }
        }
    }
}
