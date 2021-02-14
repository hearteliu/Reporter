using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Verifies that the date year is between lowerLimit and upperLimit
        /// </summary>
        /// <param name="date">The date</param>
        /// <param name="lowerLimit">Lower limit</param>
        /// <param name="upperLimit">Upper limit</param>
        /// <returns>true if date year is between lower and upper limit</returns>
        public static bool IsBetweenYearsOld(this DateTime date, int lowerLimit, int upperLimit)
        {
            var now = DateTime.Now;

            var yearsDifference = now.Year - date.Year;

            return yearsDifference >= lowerLimit && yearsDifference <= upperLimit;
        }

        /// <summary>
        /// Checks that the date is older than the date represented by year, month, day
        /// </summary>
        /// <param name="date">The date</param>
        /// <param name="year">The year</param>
        /// <param name="month">The month</param>
        /// <param name="day">The day</param>
        /// <returns>true if the date represented by year, month, day is older than the date</returns>
        public static bool IsOlderThan(this DateTime date, int year, int month, int day)
        {
            var comparisonDate = new DateTime(year, month, day);

            return date < comparisonDate;
        }
    }
}
