using System.Text.Json.Serialization;

namespace GridOrganizerBackend.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusEnum
    {
        None = 0,
        Ok = 1,
        Warning = 2,
        Error = 3
    }
}