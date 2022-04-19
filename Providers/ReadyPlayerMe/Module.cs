using UnityEngine;
using AvatarConnect;
using Newtonsoft.Json.Linq;
namespace ReadyPlayerMe
{
    public class ReadyPlayerMeMetadata
    {
        public string bodyType;
        public string outfitGender;
        public string outfitVersion;
    }

    // ReadyPlayerMe AvatarConnect Module
    public class ReadyPlayerMeModule : AvatarConnect.AvatarConnectModule
    {
        ReadyPlayerMeMetadata AvatarMetadata;

        public ReadyPlayerMeModule()
        {
            ModuleName = "ready-player-me";
            AvatarMetadata = new ReadyPlayerMeMetadata();
            AxisInverted = true;
        }

        public override AvatarConnect.AvatarConnectResult Activate()
        {
            ModuleInitialized = true;
            AvatarConnect.AvatarConnectResult result = new AvatarConnect.AvatarConnectResult();
            result.Success = true;
            return result;
        }

        public override void ProcessMetadata(JObject metadata)
        {
            AvatarMetadata = metadata["metadata"].ToObject<ReadyPlayerMeMetadata>();

            if (AvatarMetadata == null)
            {
                AvatarConnectError.Fail(AvatarConnectError.SERVICE_JSON_FAIL);
                return;
            }
        }

        public override Avatar HandleRigAvatar()
        {
            if (AvatarMetadata == null)
            {
                return null;
            }

            Avatar avatar;

            switch (AvatarMetadata.bodyType)
            {
                case "masculine":
                    avatar = Resources.Load<Avatar>("RPM/MaleAnimationTargetV2");
                    break;
                case "feminine":
                    avatar = Resources.Load<Avatar>("RPM/FemaleAnimationTargetV2");
                    break;
                default:
                    avatar = Resources.Load<Avatar>("RPM/MaleAnimationTargetV2");
                    break;
            }

            if (avatar == null)
            {
                Debug.LogError("Could not load avatar");
            }
            return avatar;
        }
    }
}