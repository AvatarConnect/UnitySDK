using UnityEngine;

namespace Meebits
{
    // Meebits AvatarConnect Module
    public class MeebitsModule : AvatarConnect.AvatarConnectModule
    {
        public MeebitsModule()
        {
            ModuleName = "meebits";
        }

        public override AvatarConnect.AvatarConnectResult Activate()
        {
            Debug.Log("AvatarConnect Module Activate");

            AvatarConnect.AvatarConnectResult result = new AvatarConnect.AvatarConnectResult();
            return result;
        }

        public override AvatarConnect.AvatarConnectResult RequestAvatar(GameObject AvatarObject)
        {
            Debug.Log("AvatarConnect Module RequestAvatar");

            AvatarConnect.AvatarConnectResult result = new AvatarConnect.AvatarConnectResult();
            return result;
        }
    }
}