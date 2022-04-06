// AvatarConnect Unity SDK - By MoNA Gallery, Inc. and It's Open Source Contributors.

using UnityEngine;

namespace AvatarConnect
{
    // Global module registry.
    public static AvatarConnectModule[] ModuleRegistry = {
        new ReadyPlayerMe.ReadyPlayerMeModule(),
        new Meebits.MeebitsModule()
    };

    // Main Avatar Connect class
    // Use this class to call the modules
    public static class AvatarConnect
    {
        // If AvatarConnect is ready to use
        public static bool ServiceInitialized = false;

        public List<AvatarConnectModule> ActiveModules;

        // Required startup call, returns true if service is ok.
        public bool Initialize(AvatarConnectModule[] avatarConnectModules)
        {
            if (ServiceInitialized) return true;

            ActiveModules = new List<AvatarConnectModule>();

            return true;
        }

        public static void ActivateAllModules()
        {
            if (!ServiceInitialized) return;

            ActivateModules(ModuleRegistry());
        }

        // Activate specific modules
        public static void ActivateModules(AvatarConnectModule[] avatarConnectModules)
        {
            if (!ServiceInitialized) return;

            foreach (AvatarConnectModule module in avatarConnectModules)
            {
                AvatarConnectResult result = module.ModuleActivate();

                if (!result.Success)
                {
                    ManageModuleError(module, result);
                    return;
                }

                ActiveModules.Add(module);
            }
        }

        // Recives data from Avatarconnect
        public static void ReceiveMetadata(string metadata)
        {
            if (!ServiceInitialized) return;

            AvatarRequest request = JsonManager.Deserialize<AvatarRequest>(metadata);

            if (request == null)
            {
                Debug.LogError("AvatarConnect: Failed to deserialize metadata");
                ManageModuleError(null, new AvatarConnectResult() { Success = false, Error = AvatarConnectError.SERVICE_JSON_FAIL });
                return;
            }

            // TODO: Remove.
            Debug.Log("AvatarConnect: Received Metadata");
            Debug.Log(request.type);
            Debug.Log(request.metadata.type);
            Debug.Log(request.metadata.metadataUri);
            Debug.Log(request.metadata.extension);
            Debug.Log(request.metadata.avatarUri);
            Debug.Log(request.metadata.imageUrl);
            Debug.Log(request.metadata.ownerDownloadVox);
            Debug.Log(request.metadata.ownerDownloadVoxTPose);
            Debug.Log(request.metadata.ownerDownloadVoxTPoseCored);
            Debug.Log(request.metadata.ownerDownloadVox3DPrint);
            Debug.Log(request.metadata.ownerDownloadVRM);
            Debug.Log(request.metadata.ownerDownloadFBX);
            Debug.Log(request.metadata.ownerDownloadGLB);

        }

        // Manage module error
        public static void ManageModuleError(AvatarConnectModule module, AvatarConnectResult error)
        {
            if (!error.Success) return;

            // Assume this is a internal error
            if (module == null)
            {

            }
        }
    }

    // Webgl bridge to javascript, Required to be attached to a root GameObject named "AvatarConnectBridge".
    public class AvatarConnectBridge : MonoBehaviour
    {

    }
}