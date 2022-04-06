// JSON utils
using System.Text.Json;

namespace AvatarConnect
{
    public static class JsonManager
    {
        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}