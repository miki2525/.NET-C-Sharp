using Employees.Model;
using System.Text.Json;

namespace Employees.utils
{
    public class TypeProspector
    {


        public static Employee ConvertJSONtoEmployee(String json)
        {
            String typeOfObj = GetType(json);
            if (typeOfObj.Equals(""))
            {
                throw new InvalidCastException("Can't convert the object");
            }
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            switch (typeOfObj)
            {
                case EmployeeConstants.OFFICE_EMPL:
                    return JsonSerializer.Deserialize<OfficeEmployee>(json, options);
                    break;
                case EmployeeConstants.WORKMAN:
                    return JsonSerializer.Deserialize<Workman>(json, options);

                    break;
                case EmployeeConstants.TRADER:
                    return JsonSerializer.Deserialize<Trader>(json, options);
                    break;
                default:
                    throw new InvalidCastException("Can't convert the object");
                    break;
            }
        }

        private static readonly string[] fields = { EmployeeConstants.INTELLECT_FIELD, EmployeeConstants.EFFECTIVENESS_FIELD, EmployeeConstants.PHYSICAL_STRENGTH_FIELD };
        private static String GetType(String json)
        {
            int occurances = 0;

            foreach (String field in fields)
            {
                if (json.Contains(field))
                {
                    occurances++;
                }
            }
            if (occurances == 0 || occurances > 1)
            {
                return "";
            }

            else if (json.Contains(EmployeeConstants.INTELLECT_FIELD))
            {
                return EmployeeConstants.OFFICE_EMPL;
            }
            else if (json.Contains(EmployeeConstants.EFFECTIVENESS_FIELD))
            {
                return EmployeeConstants.TRADER;
            }
            else
            {
                return EmployeeConstants.WORKMAN;
            }
        }

    }
}
