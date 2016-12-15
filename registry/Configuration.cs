using System;
using Microsoft.Win32;

/* ///////////////////////////////////////////////////////////////////////////

    - [ ] Update Namespace
    - [ ] Configure constants / keys
     
*/ ///////////////////////////////////////////////////////////////////////////


namespace DarkToolz
{
    /// <summary>
    /// Configuration abstraction Class
    /// </summary>
    public static class Configuration
    {
        #region -- Base Configuration --
        private const string REGISTRY_BRANCH = @"Software\Santander-igsf";  // Registry place: HKLM\Software\AppName
        private const string DEFAULT_STRING = @"";                          // If Key/Value is not found
        public enum ConfigurationKeys                                       // Constrain Key/Value pairs to this enum
        {
            eventsQueue,
            sqlConnection
        }
        #endregion    
            
        #region Methods

        /// <summary>
        /// Return the selected configuration value
        /// </summary>
        /// <param name="key">key to be retrieved || Constrained to enum</param>
        /// <param name="defaultValue"></param>
        /// <returns>key value or empty string</returns>
        public static string GetValue(ConfigurationKeys key, string defaultValue = DEFAULT_STRING)
        {
            try
            {
                return Registry.LocalMachine
                    .OpenSubKey(REGISTRY_BRANCH, false)
                    .GetValue(key.ToString(), defaultValue).ToString();
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// WARNING: Elevated priviledges are required!! (Use within try-catch block)
        /// </summary>
        /// <param name="key">key to be retrieved || Constrained to enum</param>
        /// <param name="newValue"></param>
        public static void UpdateValue(ConfigurationKeys key, string newValue)
        {
            var branch = Registry.LocalMachine.OpenSubKey(REGISTRY_BRANCH, true);
            branch.SetValue(key.ToString(), newValue);
            branch.Close();
        }


        #endregion
    }

}
