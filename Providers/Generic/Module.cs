using UnityEngine;

// Generic AvatarConnect Module
namespace AvatarConnect
{
    public class GenericMetadata : AvatarConnect.ProviderMetadata
    {
    }

    // Generic AvatarConnect Module
    public class GenericModule : AvatarConnect.AvatarConnectModule
    {
        public GenericModule()
        {
            ModuleName = "generic";
            AvatarMetadata = new GenericMetadata();
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