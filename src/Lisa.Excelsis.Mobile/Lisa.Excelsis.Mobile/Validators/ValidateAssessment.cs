using System;
using System.Text.RegularExpressions;

namespace Lisa.Excelsis.Mobile
{
    partial class Validate
    {
        public static bool StudentNumberIsValid (string studentNumber)
        {
            return !(studentNumber != null && !Regex.IsMatch(studentNumber, @"^$|^\d{8}$"));
        }
        public static bool AssessorIsValid (int index)
        {
            return (index != -1);
        }
    }
}

