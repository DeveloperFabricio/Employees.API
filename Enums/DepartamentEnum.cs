using System.Text.Json.Serialization;

namespace Employees.API.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentEnum
    {
        RH,
        Financial,
        Shopping,
        Service,
        Janitorial
    }
}
