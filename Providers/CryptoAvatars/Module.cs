using UnityEngine;

namespace CryptoAvatars
{
    public class CryptoAvatarsMetadata
    {
    }

    // Crypto Avatars AvatarConnect Module
    public class CryptoAvatarsModule : AvatarConnect.AvatarConnectModule
    {
        public CryptoAvatarsModule()
        {
            ModuleName = "crypto-avatars";
            AxisInverted = true;
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