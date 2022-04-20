using UnityEngine;
using System.Runtime.InteropServices;

// Webgl bridge to javascript, Required to be attached to a root GameObject named "AvatarConnectBridge".
public class AvatarConnectBridge : MonoBehaviour
{
    public void HandleClose()
    {
        Debug.Log("AvatarConnectBridge: HandleClose");
    }

    public void HandleError(string error)
    {
        Debug.Log("AvatarConnectBridge: HandleError: " + error);
    }

    public void HandleResult(string result)
    {
        AvatarConnect.Core.ReceiveMetadata(result);
    }
}

namespace AvatarConnect
{

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