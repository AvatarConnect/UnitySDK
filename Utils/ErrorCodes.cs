
namespace AvatarConnect
{
    // Common failure codes
    public static class AvatarConnectError
    {
        // Internal Avatar Connect
        public static string SERVICE_CONNECT_ERROR = "service.connect.error";
        public static string SERVICE_JSON_FAIL = "service.json.fail";
        public static string INVALID_URL = "invalid.url";

        // Module errors
        public static string MODULE_NOT_FOUND = "module.not.found";
        public static string MODULE_UNINITIALIZED = "module.uninitialized";
        public static string MODULE_UNSET_METADATA = "module.unset.metadata";
        public static string MODULE_RESOURCE_DOWNLOAD_FAIL = "module.resource.download.fail";
        public static string MODULE_RESOURCE_PARSE_FAIL = "module.resource.parse.fail";

        // Consumer errors
        public static string CONSUMER_CHARACTER_NOT_SET = "consumer.character.not.set";
        public static string CONSUMER_UNSUPPORTED_AVATAR_FORMAT = "consumer.unsupported.format";

        // Utility function to flag a failure
        public static void Fail(string error, AvatarConnectModule module = null)
        {
            AvatarConnectResult result = new AvatarConnectResult();
            result.Success = false;
            result.Error = error;
            Core.ManageModuleError(module, result);
        }
    }
}