using Newtonsoft.Json;

namespace buildxact_supplies.Extensions
{
    public static class JsonSerialzerExtension
    {

        public static T Deserialize<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
        public static string Serialize<T>(this T value)
        {
            return JsonConvert.SerializeObject(
                value,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        public static string SerializeWithSetting<T>(this T value, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(value, settings);
        }
    }
}
