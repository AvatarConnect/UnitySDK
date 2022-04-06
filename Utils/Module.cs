using UnityEngine;

namespace AvatarConnect
{
    // Parent class for all partner modules
    public class AvatarConnectModule
    {
        // If the module is ready
        public static bool ModuleInitialized;

        // Metadata name of the module
        public static string ModuleName;

        // Latest Metadata recived from the server
        public Metadata AvatarMetadata;

        // Startup call for this module, Use this to initialize and connect to your backend.
        // Note: Do not call in constructor.
        public virtual AvatarConnectResult Activate()
        {
            AvatarConnectResult result = new AvatarConnectResult();
            return result;
        }

        // Will load a AvatarConnect avatar, then use the input gameobject to load the avatar into.
        public virtual AvatarConnectResult RequestAvatar(GameObject avatarObject)
        {
            AvatarConnectResult result = new AvatarConnectResult();
            return result;
        }

        // ----------------------------------------------
        //   Private internal module handling
        // ----------------------------------------------
        public AvatarConnectResult ModuleActivate()
        {
            AvatarConnectResult result = Activate();
            return result;
        }
    }
}