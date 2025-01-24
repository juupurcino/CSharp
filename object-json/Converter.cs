using System.Collections;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;

public static class Converter
{
    public static string ToJson<T>(this T obj)
    {
        var sb = new StringBuilder();
        toJson(obj, sb);
        return sb.ToString();

    }

    public static void toJson<T>(this T obj, StringBuilder sb)
    {
        sb.Append("{ ");

        Type tipo = obj.GetType();

        PropertyInfo[] propriedades = tipo.GetProperties();

        foreach (var pi in propriedades)
        {
            if (!pi.PropertyType.IsAssignableTo(typeof(IEnumerable)) || pi.PropertyType == typeof(string))
            {
                sb.AppendLine(pi.Name + " : " + pi.GetValue(obj));
            }

            if (pi.PropertyType.IsAssignableTo(typeof(IEnumerable)) && pi.PropertyType != typeof(string))
            {
                var listNotas = (IEnumerable)pi.GetValue(obj);

                sb.Append($"{pi.Name}: ");
                foreach (var item in listNotas)
                {
                    sb.Append(item + ", ");
                }
            }

            if (pi.PropertyType.IsClass)
            {
                
            }

        }

        sb.AppendLine("}");

        
    }
}