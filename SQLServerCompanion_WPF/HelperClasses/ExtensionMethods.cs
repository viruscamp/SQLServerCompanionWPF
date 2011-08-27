using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SQLServerCompanion.HelperClasses
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Extension method to trim off the set_, get_ from the front of the method name for a property
        /// </summary>
        /// <param name="methodBase"></param>
        /// <returns></returns>
        public static string GetPropertyName(this MethodBase methodBase)
        {
            return methodBase.Name.Substring(4);
        }
    }
}
