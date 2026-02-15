using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class clsValidator
    {
        public static bool IsValidEmail(string Email)
        {
            return Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        public static bool IsValidPhone(string Phone)
        {
            return Regex.IsMatch(Phone, @"(\+?|00)?[0-9]{8,15}$");
        }
        public static bool IsWithinRange(int Value, int Min, int Max)
        {
            return Value >= Min && Value <= Max;
        }
        public static bool IsWithinLength(string Value, int Min, int Max)
        {
            return !string.IsNullOrEmpty(Value) && Value.Length >= Min 
                && Value.Length <= Max;
        }
        public static bool IsEmptyOrWithinLength(string Value, int Min, int Max)
        {
            return string.IsNullOrEmpty(Value) || IsWithinLength(Value, Min, Max);
        }
        public static bool IsPositiveNumber(int Value)
        {
            return Value > 0;
        }
        public static bool IsValidDateOfBirth(DateTime? DateOfBirth)
        {
            return DateOfBirth.HasValue && DateOfBirth <= DateTime.Now.Date &&
                DateOfBirth >= DateTime.Now.Date.AddYears(-120);
        }
    }
}
