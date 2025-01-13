using System;

namespace phr.Config
{
    public static class Helper
    {
        public static string GetValueOrDefault<T>(T value)
        {
            if (value == null)
            {
                return "-";
            }
            if (value is int || value is double || value is float)
            {
                return value.ToString();
            }
            if (value is string strValue)
            {
                return string.IsNullOrEmpty(strValue) ? "-" : strValue;
            }
            return value.ToString();
        }
    }
}
