using UnityEngine;

namespace ReadyPlayerMe
{
    // ReadyPlayerMe AvatarConnect Module
    public class ReadyPlayerMeModule : AvatarConnect.AvatarConnectModule
    {
        public ReadyPlayerMeModule()
        {
            ModuleName = "readyplayerme";
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