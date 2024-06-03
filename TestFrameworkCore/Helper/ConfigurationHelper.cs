using System.Configuration;

namespace TestFrameworkCore.Helper
{
    public class ConfigurationHelper
    {
        //Doc du lieu tu file Config
        public static T? GetConfig<T>(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (value is null)
            {
                return default(T);
            }
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
