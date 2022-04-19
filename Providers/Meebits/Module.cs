using UnityEngine;

namespace Meebits
{
    public class MeebitsMetadata
    {
    }

    // Meebits AvatarConnect Module
    public class MeebitsModule : AvatarConnect.AvatarConnectModule
    {
        public MeebitsModule()
        {
            ModuleName = "meebits";
            TextureFilterMode = FilterMode.Point;
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