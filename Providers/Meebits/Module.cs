using UnityEngine;

namespace Meebits
{
    public class MeebitsMetadata : AvatarConnect.ProviderMetadata
    {
        public string type;
    }

    // Meebits AvatarConnect Module
    public class MeebitsModule : AvatarConnect.AvatarConnectModule
    {
        public MeebitsModule()
        {
            ModuleName = "meebits";
            AvatarMetadata = new MeebitsMetadata();
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