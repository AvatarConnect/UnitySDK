using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using VRM;
using UniVRM10;
using UniGLTF;
using Newtonsoft.Json.Linq;

namespace AvatarConnect
{
    // Parent class for all partner modules
    public class AvatarConnectModule
    {
        // If the module is ready
        public bool ModuleInitialized;

        // Metadata for the module
        public string ModuleName;
        public bool AxisInverted;
        public FilterMode TextureFilterMode = FilterMode.Bilinear;

        // Startup call for this module, Use this to initialize and connect to your backend.
        // Note: Do not call in constructor.
        public virtual AvatarConnectResult Activate()
        {
            AvatarConnectResult result = new AvatarConnectResult();
            result.Success = true;
            return result;
        }

        // Will load a AvatarConnect avatar, then use the input gameobject to load the avatar into.
        public virtual async Task RequestAvatar(GameObject avatarObject, JObject requestData)
        {
            AvatarConnectResult result = await Downloader.Download(requestData["avatar"]["uri"].ToString());

            if (result == null || !result.Success)
            {
                AvatarConnectError.Fail(AvatarConnectError.MODULE_RESOURCE_DOWNLOAD_FAIL, this);
                return;
            }

            ProcessMetadata(requestData);

            ACAvatar avatar = SpawnAvatar((byte[])result.OperationResult, requestData["avatar"]["format"].ToString());
            if (avatar == null) { return; }

            avatar.AvatarObject.transform.SetParent(avatarObject.transform);
            avatar.AvatarObject.transform.localPosition = Vector3.zero;
            avatar.AvatarObject.transform.localRotation = Quaternion.identity;

            avatar.Activate();
            avatar.AvatarObject.AddComponent<AvatarConnectUpdateFetch>().Avatar = avatar;

            Core.Avatars.Add(avatar);
        }

        // Spawns the avatar into the input gameobject
        public virtual ACAvatar SpawnAvatar(byte[] avatarData, string format)
        {
            switch (format)
            {
                case "vrm":
                    return HandleVRMAvatar(avatarData);

                case "glb":
                    return HandleGLBAvatar(avatarData);
            }

            AvatarConnectError.Fail(AvatarConnectError.CONSUMER_UNSUPPORTED_AVATAR_FORMAT, this);

            return null;
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

        public virtual ACAvatar HandleVRMAvatar(byte[] avatarData)
        {
            ACAvatar avatar = new ACAvatar();

            // GLB data
            GltfData vrm_glb_data = HandleGLB(avatarData);
            if (vrm_glb_data == null) return null;

            // VRM data
            VRMData vrm_data = new VRMData(vrm_glb_data);

            // Import VRM
            using (VRMImporterContext context = new VRMImporterContext(vrm_data))
            {
                context.InvertAxis = AxisInverted ? Axes.X : Axes.Z;

                RuntimeGltfInstance instance = context.Load();
                instance.EnableUpdateWhenOffscreen();
                instance.ShowMeshes();
                HandleTextures(instance.Textures);
                avatar.AvatarObject = instance.Root;

                avatar.Animator = instance.GetComponent<Animator>();
                Avatar anim_avatar = HandleRigAvatar();
                if (anim_avatar != null) avatar.Animator.avatar = anim_avatar;
                avatar.Animator.runtimeAnimatorController = Core.AvatarController;
            }

            vrm_glb_data.Dispose();

            return avatar;
        }

        public virtual ACAvatar HandleGLBAvatar(byte[] avatarData)
        {
            ACAvatar avatar = new ACAvatar();

            // GLB data
            GltfData glb_data = HandleGLB(avatarData);

            if (glb_data == null) return null;

            using (ImporterContext context = new ImporterContext(glb_data))
            {
                context.InvertAxis = AxisInverted ? Axes.X : Axes.Z;

                RuntimeGltfInstance instance = context.Load();
                instance.EnableUpdateWhenOffscreen();
                instance.ShowMeshes();
                HandleTextures(instance.Textures);
                avatar.AvatarObject = instance.Root;

                avatar.Animator = avatar.AvatarObject.AddComponent<Animator>();
                Avatar anim_avatar = HandleRigAvatar();
                if (anim_avatar != null) avatar.Animator.avatar = anim_avatar;
                avatar.Animator.runtimeAnimatorController = Core.AvatarController;
            }

            glb_data.Dispose();

            return avatar;
        }

        // Force all textures to use the same filter mode
        public virtual void HandleTextures(IReadOnlyList<Texture> textures)
        {
            foreach (Texture texture in textures)
            {
                if (texture == null) continue;

                texture.filterMode = TextureFilterMode;
            }
        }

        public virtual Avatar HandleRigAvatar()
        {
            return null;
        }

        public virtual void ProcessMetadata(JObject metadata)
        {
            return;
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