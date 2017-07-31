using System;
using System.IO;
using System.Reflection;
using System.Security.Principal;
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
        private const string REGISTRY_BRANCH = @"Software\AppName";         // Registry place: HKLM\Software\WOW6432Node\AppName
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
            if (branch == null)
            {
                Registry.LocalMachine.CreateSubKey(REGISTRY_BRANCH);
                branch = Registry.LocalMachine.OpenSubKey(REGISTRY_BRANCH, true);
            }
            branch.SetValue(key.ToString(), newValue);
            branch.Close();
        }



        #endregion

        #region :: Windows User
        public static bool AdminRights
        {
            get
            {
                WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }
        public static string CurrentUserIdentity => WindowsIdentity.GetCurrent().Name;

        #endregion

        #region :: Release Version
        public static string GetRelease(TimeZoneInfo target = null)
        {
            var assemblyDate = GetAssemblyDateTime(target);
            var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
            return $"{assemblyVersion.Major}.{assemblyVersion.Minor}.{assemblyDate:yyyyMMdd}";
        }
        public static DateTime GetAssemblyDateTime(TimeZoneInfo target = null)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var filePath = assembly.Location;
            const int cPeHeaderOffset = 60;
            const int cLinkerTimestampOffset = 8;
            var buffer = new byte[2048];
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                stream.Read(buffer, 0, 2048);
            var offset = BitConverter.ToInt32(buffer, cPeHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(buffer, offset + cLinkerTimestampOffset);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var linkTimeUtc = epoch.AddSeconds(secondsSince1970);
            var tz = target ?? TimeZoneInfo.Local;
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);
            return localTime;
        }
        #endregion
    }

}
