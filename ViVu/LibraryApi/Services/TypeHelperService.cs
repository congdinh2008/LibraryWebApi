using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public class TypeHelperService : ITypeHelperService
    {
        public bool TypeHasProperties<T>(string fields)
        {
            if (string.IsNullOrWhiteSpace(fields))
                return true;

            // The field are separated by ",", so we split it.
            var fieldsAfterSplit = fields.Split(',');

            // Check if the requested fields exist on source.
            foreach (var field in fieldsAfterSplit)
            {
                // Trim each field, as it might contain leading 
                // Or trailing spaces. Can't trim the var in foreach,
                // So use another var.
                var propertyName = field.Trim();

                // Use reflection to check if the property can be
                // Found on T. 
                var propertyInfo = typeof(T)
                    .GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                // It can't be found, return false
                if (propertyInfo == null)
                {
                    return false;
                }
            }

            // All checks out, return true
            return true;
        }
    }
}
