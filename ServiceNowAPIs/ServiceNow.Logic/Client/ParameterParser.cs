using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ServiceNow.Logic.Client
{
    public static class ParameterParser
    {
        public static string Parse<T>(T obj) where T : class
        {
            //var instance = Activator.CreateInstance(typeof(T));
            PropertyInfo[] InputProperties = obj.GetType().GetProperties();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in InputProperties)
            {
                var value = item.GetValue(obj).ToString();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    stringBuilder.Append($"{ item.Name}={item.GetValue(obj).ToString()}^");
                }
            }

            var result = stringBuilder.ToString();
            return result.Length > 0 ? result.Substring(0, stringBuilder.Length - 1) : string.Empty;
        }
    }
}
