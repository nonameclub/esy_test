using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
namespace ESY.TEST.Helper
{
    public class Helper
    {
        public static double GetTotalPrice(double amount, double price)
        {
            double vat = Convert.ToDouble(ConfigurationManager.AppSettings["VAT"]);

            return (amount * price) * (1 + vat);
        }
    }
}