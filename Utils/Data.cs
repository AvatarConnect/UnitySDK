
namespace AvatarConnect
{
    // Result of a operation
    public class AvatarConnectResult
    {
        public bool Success;
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