using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using VRM;
using UniVRM10;
using UniGLTF;

namespace AvatarConnect
{
    // Parent class for all partner modules
    // TODO: Handle partner metadata
    public class AvatarConnectModule
    {
        // If the module is ready
        public bool ModuleInitialized;

        // Metadata name of the module
        public string ModuleName;

        // Latest Metadata recived from the server
        public ProviderMetadata AvatarMetadata;

        // Startup call for this module, Use this to initialize and connect to your backend.
        // Note: Do not call in constructor.
        public virtual AvatarConnectResult Activate()
        {
            AvatarConnectResult result = new AvatarConnectResult();
            result.Success = true;
            return result;
        }

        // Will load a AvatarConnect avatar, then use the input gameobject to load the avatar into.
        public virtual void RequestAvatar(GameObject avatarObject, AvatarRequest requestData)
        {
            AvatarConnectResult result = Downloader.Download(requestData.avatar.uri);

            if (result == null || !result.Success)
            {
                AvatarConnectError.Fail(AvatarConnectError.MODULE_RESOURCE_DOWNLOAD_FAIL, this);
                return;
            }

            SpawnAvatar((byte[])result.OperationResult, requestData.avatar.type);
        }

        // Spawns the avatar into the input gameobject
        public virtual void SpawnAvatar(byte[] avatarData, string format)
        {
            switch (format)
            {
                case "vrm":
                    // GLB data
                    GltfData vrm_glb_data = HandleGLB(avatarData);
                    if (vrm_glb_data == null) return;

                    // VRM data
                    VRMData vrm_data = new VRMData(vrm_glb_data);

                    // Import VRM
                    using (VRMImporterContext context = new VRMImporterContext(vrm_data))
                    {
                        RuntimeGltfInstance instance = context.Load();
                        instance.EnableUpdateWhenOffscreen();
                        instance.ShowMeshes();
                    }

                    vrm_glb_data.Dispose();
                    break;
                case "glb":
                    // GLB data
                    GltfData glb_data = HandleGLB(avatarData);

                    if (glb_data == null) return;

                    using (ImporterContext context = new ImporterContext(glb_data))
                    {
                        RuntimeGltfInstance instance = context.Load();
                        instance.EnableUpdateWhenOffscreen();
                        instance.ShowMeshes();
                    }

                    glb_data.Dispose();
                    break;

                default:
                    AvatarConnectError.Fail(AvatarConnectError.CONSUMER_UNSUPPORTED_AVATAR_FORMAT, this);
                    break;
            }
        }

        // GLB parsing
        public virtual GltfData HandleGLB(byte[] avatarData)
        {
            GltfData glb_data = new GlbBinaryParser(avatarData, ModuleName + "_character").Parse();

            if (glb_data == null)
            {
                AvatarConnectError.Fail(AvatarConnectError.MODULE_RESOURCE_PARSE_FAIL, this);
                return null;
            }

            return glb_data;
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