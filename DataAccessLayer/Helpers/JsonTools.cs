using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers;
public static class JsonTools
{
    public static T FromJson<T>(this string jsonString)
    {
        if (string.IsNullOrWhiteSpace(jsonString))
            return default;
        return JsonSerializer.Deserialize<T>(jsonString);
    }

    public static string ToJson(this object obj)
    {
        return JsonSerializer.Serialize(obj);
    }
}