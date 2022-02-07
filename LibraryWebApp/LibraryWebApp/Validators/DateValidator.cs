using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Validators
{
    public class DateValidator : ValidationAttribute
    {
        DateTime dateToday = DateTime.Today;
        public override bool IsValid(object value)
        {
            DateTime date = Convert.ToDateTime(value);
            try
            {
                return date < dateToday;
            }
            catch
            {
                return false;
            }
        }
    }
}
