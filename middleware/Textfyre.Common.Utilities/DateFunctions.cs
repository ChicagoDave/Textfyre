﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Textfyre.Common.Utilities {

    public enum Quarter {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4
    }

    public enum Month {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    public class DateFunctions {

        #region Quarters

        public static DateTime GetStartOfQuarter(int Year, Quarter Qtr) {
            if (Qtr == Quarter.First)    // 1st Quarter = January 1 to March 31

                return new DateTime(Year, 1, 1, 0, 0, 0, 0);
            else if (Qtr == Quarter.Second) // 2nd Quarter = April 1 to June 30

                return new DateTime(Year, 4, 1, 0, 0, 0, 0);
            else if (Qtr == Quarter.Third) // 3rd Quarter = July 1 to September 30

                return new DateTime(Year, 7, 1, 0, 0, 0, 0);
            else // 4th Quarter = October 1 to December 31

                return new DateTime(Year, 10, 1, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfQuarter(int Year, Quarter Qtr) {
            if (Qtr == Quarter.First)    // 1st Quarter = January 1 to March 31

                return new DateTime(Year, 3,
                       DateTime.DaysInMonth(Year, 3), 23, 59, 59, 999);
            else if (Qtr == Quarter.Second) // 2nd Quarter = April 1 to June 30

                return new DateTime(Year, 6,
                       DateTime.DaysInMonth(Year, 6), 23, 59, 59, 999);
            else if (Qtr == Quarter.Third) // 3rd Quarter = July 1 to September 30

                return new DateTime(Year, 9,
                       DateTime.DaysInMonth(Year, 9), 23, 59, 59, 999);
            else // 4th Quarter = October 1 to December 31

                return new DateTime(Year, 12,
                       DateTime.DaysInMonth(Year, 12), 23, 59, 59, 999);
        }

        public static Quarter GetQuarter(Month Month) {
            if (Month <= Month.March)
                // 1st Quarter = January 1 to March 31

                return Quarter.First;
            else if ((Month >= Month.April) && (Month <= Month.June))
                // 2nd Quarter = April 1 to June 30

                return Quarter.Second;
            else if ((Month >= Month.July) && (Month <= Month.September))
                // 3rd Quarter = July 1 to September 30

                return Quarter.Third;
            else // 4th Quarter = October 1 to December 31

                return Quarter.Fourth;
        }

        public static DateTime GetEndOfLastQuarter() {

            Month Month = ((Month)DateTime.Now.Month);

            if (Month <= Month.March)
                return GetEndOfQuarter(DateTime.Now.Year - 1, Quarter.Fourth);
            else if ((Month >= Month.April) && (Month <= Month.June))
                return GetEndOfQuarter(DateTime.Now.Year, Quarter.First);
            else if ((Month >= Month.July) && (Month <= Month.September))
                return GetEndOfQuarter(DateTime.Now.Year, Quarter.Second);
            else 
                return GetEndOfQuarter(DateTime.Now.Year, Quarter.Third);

        }

        public static DateTime GetStartOfLastQuarter() {
            Month Month = ((Month)DateTime.Now.Month);

            if (Month <= Month.March)
                return GetStartOfQuarter(DateTime.Now.Year - 1, Quarter.Fourth);
            else if ((Month >= Month.April) && (Month <= Month.June))
                return GetStartOfQuarter(DateTime.Now.Year, Quarter.First);
            else if ((Month >= Month.July) && (Month <= Month.September))
                return GetStartOfQuarter(DateTime.Now.Year, Quarter.Second);
            else 
                return GetStartOfQuarter(DateTime.Now.Year, Quarter.Third);
        }

        public static DateTime GetStartOfCurrentQuarter() {
            return GetStartOfQuarter(DateTime.Now.Year,
                   GetQuarter((Month)DateTime.Now.Month));
        }

        public static DateTime GetEndOfCurrentQuarter() {
            return GetEndOfQuarter(DateTime.Now.Year,
                   GetQuarter((Month)DateTime.Now.Month));
        }
        #endregion

        #region Weeks
        public static DateTime GetStartOfLastWeek() {
            int DaysToSubtract = (int)DateTime.Now.DayOfWeek + 7;
            DateTime dt = DateTime.Now.Subtract(System.TimeSpan.FromDays(DaysToSubtract));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfLastWeek() {
            DateTime dt = GetStartOfLastWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }

        public static DateTime GetStartOfCurrentWeek() {
            int DaysToSubtract = (int)DateTime.Now.DayOfWeek;
            DateTime dt = DateTime.Now.Subtract(System.TimeSpan.FromDays(DaysToSubtract));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfCurrentWeek() {
            DateTime dt = GetStartOfCurrentWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }
        #endregion

        #region Months

        public static DateTime GetStartOfMonth(int Month, int Year) {
            return new DateTime(Year, (int)Month, 1, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfMonth(int Month, int Year) {
            return new DateTime(Year, (int)Month,
               DateTime.DaysInMonth(Year, (int)Month), 23, 59, 59, 999);
        }

        public static DateTime GetStartOfLastMonth() {
            if (DateTime.Now.Month == 1)
                return GetStartOfMonth(12, DateTime.Now.Year - 1);
            else
                return GetStartOfMonth(DateTime.Now.Month - 1, DateTime.Now.Year);
        }

        public static DateTime GetEndOfLastMonth() {
            if (DateTime.Now.Month == 1)
                return GetEndOfMonth(12, DateTime.Now.Year - 1);
            else
                return GetEndOfMonth(DateTime.Now.Month - 1, DateTime.Now.Year);
        }

        public static DateTime GetStartOfCurrentMonth() {
            return GetStartOfMonth(DateTime.Now.Month, DateTime.Now.Year);
        }

        public static DateTime GetEndOfCurrentMonth() {
            return GetEndOfMonth(DateTime.Now.Month, DateTime.Now.Year);
        }
        #endregion

        #region Years
        public static DateTime GetStartOfYear(int Year) {
            return new DateTime(Year, 1, 1, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfYear(int Year) {
            return new DateTime(Year, 12,
              DateTime.DaysInMonth(Year, 12), 23, 59, 59, 999);
        }

        public static DateTime GetStartOfLastYear() {
            return GetStartOfYear(DateTime.Now.Year - 1);
        }

        public static DateTime GetEndOfLastYear() {
            return GetEndOfYear(DateTime.Now.Year - 1);
        }

        public static DateTime GetStartOfCurrentYear() {
            return GetStartOfYear(DateTime.Now.Year);
        }

        public static DateTime GetEndOfCurrentYear() {
            return GetEndOfYear(DateTime.Now.Year);
        }
        #endregion

        #region Days
        public static DateTime GetStartOfDay(DateTime date) {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfDay(DateTime date) {
            return new DateTime(date.Year, date.Month,
                                 date.Day, 23, 59, 59, 999);
        }
        #endregion
    }
}
