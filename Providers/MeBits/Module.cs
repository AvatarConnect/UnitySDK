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

        public override bool Activate()
        {
            Debug.Log("AvatarConnect Module Activated");
            return true;
        }

        public override void RequestAvatar(GameObject AvatarObject)
        {
            Debug.Log("AvatarConnect Module RequestAvatar");
        }
    }
}