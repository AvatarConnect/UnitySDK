
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
        public string type;
        public Metadata metadata;

    }

    // Avatar metadata json recived by the server
    [System.Serializable]
    public class Metadata
    {
        public string type;
        public string metadataUri;
        public string extension;
        public string avatarUri;
        public string imageUrl;

        public string ownerDownloadVox;
        public string ownerDownloadVoxTPose;
        public string ownerDownloadVoxTPoseCored;
        public string ownerDownloadVox3DPrint;
        public string ownerDownloadVRM;
        public string ownerDownloadFBX;
        public string ownerDownloadGLB;
    }
}