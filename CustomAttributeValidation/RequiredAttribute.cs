using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributeValidation
{
    public class RequiredAttribute : Attribute
    {
        public static void CheckFields(Object obj, List<string> missingFields)
        {
            if (obj is null)
                return;

            Type type = obj.GetType();
            var props = type.GetProperties().Where(p => Attribute.IsDefined(p, typeof(RequiredAttribute)));
            foreach (var prop in props)
            {
                if (prop.PropertyType.Name != "String")
                {

                    PropertyInfo pi = obj.GetType().GetProperty(prop.Name);
                    Object newObj = pi.GetValue(obj, null);

                    if (newObj == null)
                        missingFields.Add(prop.DeclaringType.Name + " " + prop.Name);

                    CheckFields(newObj, missingFields);
                }
                else
                {
                    if (prop.GetValue(obj) == string.Empty || prop.GetValue(obj) is null)
                    {
                        missingFields.Add(prop.DeclaringType.Name + " " + prop.Name);
                    }
                }
            }
        }
    }
}
