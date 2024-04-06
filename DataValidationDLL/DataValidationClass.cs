/* Title:           Data Validation Class
 * Date:            3-13-16
 * Author:          Terry Holmes
 *
 * Author:          This class provides data validation */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateSearchDLL;
using System.Text.RegularExpressions;

namespace DataValidationDLL
{
    public class DataValidationClass
    {
        DateSearchClass TheDateSearchClass = new DateSearchClass();

        public bool VerifyTimeSpanInfo(string strValueForValidation)
        {
            bool blnFatalError = false;
            TimeSpan timParsedTime;

            blnFatalError = !(TimeSpan.TryParse(strValueForValidation, out timParsedTime));


            return blnFatalError;
        }
        public bool VerifyTime(string strValueForValidation)
        {
            bool blnFatalError = false;

            bool blnStringMatches;

            string strMyTestPattern = @"^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$";

            blnStringMatches = Regex.IsMatch(strValueForValidation, strMyTestPattern);

            blnFatalError = !blnStringMatches;

            return blnFatalError;
        }
        public bool VerifyEmailAddress(string strValueForValidation)
        {
            bool blnFatalError = false;
            bool blnStringMatches;

            string strMyTestPattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            blnStringMatches = Regex.IsMatch(strValueForValidation, strMyTestPattern);

            blnFatalError = !blnStringMatches;

            return blnFatalError;
        }
        public bool VerifyPhoneNumberFormat(string strValueForValidation)
        {
            bool blnFatalError = false;
            bool blnStringMatches;            

            string strMyTestPattern = @"^(\([0-9]{3}\)|[0-9]{3})[ -\.]?[0-9]{3}[ -\.]?[0-9]{4}$";

            blnStringMatches = Regex.IsMatch(strValueForValidation, strMyTestPattern);

            blnFatalError = !blnStringMatches;

            return blnFatalError;
        }
        public bool VerifyTextData(string strValueForValidation)
        {
            bool blnFatalError = false;

            if (strValueForValidation == "")
                blnFatalError = true;

            return blnFatalError;
        }
        public Boolean VerifyIntegerData(string strValueForValidation)
        {
            //setting local variables
            bool blnFatalError = false;
            int intOutPutNumber;

            //Checking input
            blnFatalError = !int.TryParse(strValueForValidation, out intOutPutNumber);


            //Returning value to calling sub routine
            return blnFatalError;
        }
        public Boolean VerifyIntegerRange(string strValueForValidation)
        {
            bool blnFatalError = false;
            int intValueForValidation;

            try
            {
                //Getting value
                intValueForValidation = Convert.ToInt32(strValueForValidation);

                //Returning value to calling routine
                return blnFatalError;
            }
            catch (Exception)
            {
                //returning value to calling routine
                blnFatalError = true;
                return blnFatalError;
            }
        }
        public Boolean VerifyDoubleData(string strValueForValidation)
        {
            //Setting local variables
            bool blnFatalError = false;
            double douNumberOutput;

            //checking to see if the number
            blnFatalError = !double.TryParse(strValueForValidation, out douNumberOutput);

            //returning back to calling sub-routine
            return blnFatalError;
        }
        public Boolean VerifyYesNoData(string strValueForValidation)
        {
            //Setting local variables
            bool blnFatalError = false;

            strValueForValidation = strValueForValidation.ToUpper();

            //checking value of string
            if (strValueForValidation != "YES" && strValueForValidation != "NO")
            {
                blnFatalError = true;
            }

            //returning value to calling sub routine
            return blnFatalError;
        }
        public Boolean VerifyDateData(string strValueForValidation)
        {
            //Setting Local Variables
            bool blnFatalError = false;
            DateTime datTestDate;

            //checking the date
            blnFatalError = !DateTime.TryParse(strValueForValidation, out datTestDate);

            //Returning to calling sub routine
            return blnFatalError;
        }
        public Boolean verifyDateRange(DateTime datStaringDate, DateTime datEndingDate)
        {
            //Setting local variables
            bool blnFatalError = false;

            //Removing time
            datStaringDate = TheDateSearchClass.RemoveTime(datStaringDate);
            datEndingDate = TheDateSearchClass.RemoveTime(datEndingDate);

            //Verifying the Starting Date is less than the ending date
            if (datStaringDate > datEndingDate)
            {
                blnFatalError = true;
            }

            //Returning value to main
            return blnFatalError;
        }
    }
}
