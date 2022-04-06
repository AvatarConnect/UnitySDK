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