using UnityEngine;
using System.Runtime.InteropServices;

namespace AvatarConnect
{
    // Webgl bridge to javascript, Required to be attached to a root GameObject named "AvatarConnectBridge".
    public class AvatarConnectBridge : MonoBehaviour
    {
        public static void HandleClose()
        {
            Debug.Log("AvatarConnectBridge: HandleClose");
        }

        public static void HandleError(string error)
        {
            Debug.Log("AvatarConnectBridge: HandleError: " + error);
        }

        public static void HandleResult(string result)
        {
            Core.ReceiveMetadata(result);
        }
    }

    // SDK bindings
    public static class SDK
    {
#if UNITY_WEBGL
        [DllImport("__Internal")]
        public static extern void InitAvatarConnectSDK();
        [DllImport("__Internal")]
        public static extern void EnableAvatarConnectSDK();
        [DllImport("__Internal")]
        public static extern void DisableAvatarConnectSDK();
#else
        // Stubs
        public static void InitAvatarConnectSDK() { }
        public static void EnableAvatarConnectSDK() { }
        public static void DisableAvatarConnectSDK() { }
#endif
    }
}