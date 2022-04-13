using UnityEngine;
using AvatarConnect;

namespace ReadyPlayerMe
{
    public class ReadyPlayerMeMetadata : AvatarConnect.ProviderMetadata
    {
        public string extension;
        public string metadataUri;
    }

    // ReadyPlayerMe AvatarConnect Module
    public class ReadyPlayerMeModule : AvatarConnect.AvatarConnectModule
    {
        public ReadyPlayerMeModule()
        {
            ModuleName = "ready-player-me";
            AvatarMetadata = new ReadyPlayerMeMetadata();
        }

        public override AvatarConnect.AvatarConnectResult Activate()
        {
            ModuleInitialized = true;
            AvatarConnect.AvatarConnectResult result = new AvatarConnect.AvatarConnectResult();
            result.Success = true;
            return result;
        }
    }
}