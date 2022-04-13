
namespace AvatarConnect
{
    // Result of a operation
    public class AvatarConnectResult
    {
        // If the operation was successful
        public bool Success;

        // If the operation succeeded then this will contain the result
        public object OperationResult;

        // If the operation failed then this will contain the error
        public string Error;
    }

    // Avatar metadata header json recived by the server
    [System.Serializable]
    public class AvatarRequest
    {
        // type - What avatar provider this is the avatar of
        public string provider;
        public AvatarInfo avatar;
        public string metadata;
    }

    [System.Serializable]
    public class AvatarInfo
    {
        public string type;
        public string uri;
    }

    // Inhered from this base class to get the Provider specific metadata
    [System.Serializable]
    public class ProviderMetadata { }

}