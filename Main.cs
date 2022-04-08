// AvatarConnect Unity SDK - By MoNA Gallery, Inc. and It's Open Source Contributors.

using UnityEngine;
using System.Collections.Generic;

namespace AvatarConnect
{
    // Main Avatar Connect class
    // Use this class to call the modules
    public static class Core
    {
        // Global module registry.
        public static AvatarConnectModule[] GetModuleRegistry()
        {
            return new AvatarConnectModule[]{
                new ReadyPlayerMe.ReadyPlayerMeModule(),
                new Meebits.MeebitsModule()
            };
        }

        // If AvatarConnect is ready to use
        public static bool ServiceInitialized = false;
        public static List<AvatarConnectModule> ActiveModules;

        // Considered temporary.
        public static GameObject AvatarObject;

        // Required startup call, returns true if service is ok.
        public static bool Initialize()
        {
            if (ServiceInitialized) return true;

            // Check if the unity client has internet access
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                AvatarConnectError.Fail(AvatarConnectError.SERVICE_CONNECT_ERROR);
                return false;
            }

            // Create fallback object if not AvatarObject is found.
            if (AvatarObject == null)
            {
                AvatarConnectError.Fail(AvatarConnectError.CONSUMER_CHARACTER_NOT_SET);
                AvatarObject = new GameObject("Avatar");
            }

            ActiveModules = new List<AvatarConnectModule>();
            ServiceInitialized = true;

            return true;
        }

        // Activate all modules
        public static void ActivateAllModules()
        {
            if (!ServiceInitialized) return;

            ActivateModules(GetModuleRegistry());
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

            AvatarRequest request = JsonUtility.FromJson<AvatarRequest>(metadata);

            if (request == null)
            {
                AvatarConnectError.Fail(AvatarConnectError.SERVICE_JSON_FAIL);
                return;
            }

            AvatarConnectModule module = GetModule(request.type);

            if (module == null)
            {
                AvatarConnectError.Fail(AvatarConnectError.MODULE_NOT_FOUND);
                return;
            }

            if (!module.ModuleInitialized)
            {
                AvatarConnectError.Fail(AvatarConnectError.MODULE_UNINITIALIZED);
                return;
            }

            AvatarConnectResult result = module.RequestAvatar(AvatarObject);

        }

        // Endpoint for all internal & external errors
        public static void ManageModuleError(AvatarConnectModule module, AvatarConnectResult error)
        {
            if (!error.Success) return;

            // Assume this is a internal error
            if (module == null)
            {
                // TODO
                Debug.LogError("AvatarConnect [Internal]: " + error.Error);
                return;
            }

            Debug.LogError("AvatarConnect [Module " + module.ModuleName + "]: " + error.Error);
        }

        // Get partner module by name, returns null if not found.
        public static AvatarConnectModule GetModule(string moduleName)
        {
            if (!ServiceInitialized || ActiveModules == null) return null;

            foreach (AvatarConnectModule module in ActiveModules)
            {
                if (module.ModuleName == moduleName)
                {
                    return module;
                }
            }

            return null;
        }
    }

    // Webgl bridge to javascript, Required to be attached to a root GameObject named "AvatarConnectBridge".
    public class AvatarConnectBridge : MonoBehaviour
    {

    }
}