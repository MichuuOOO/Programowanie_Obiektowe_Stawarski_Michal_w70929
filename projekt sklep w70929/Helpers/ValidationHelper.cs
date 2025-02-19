using System.Text.RegularExpressions;

namespace Sklep.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsEmailValid(string email) 
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        public static bool IsPositiveDecimal(decimal value) 
        {
            return value >= 0;
        }
    }
}
