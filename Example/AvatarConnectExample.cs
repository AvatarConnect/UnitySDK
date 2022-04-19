using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AvatarConnect;

public class AvatarConnectExample : MonoBehaviour
{
    public GameObject avatarTarget;

    void Start()
    {
        // Force TXAA
        QualitySettings.antiAliasing = 8;

        if (avatarTarget == null)
        {
            Debug.LogError("AvatarConnectExample: avatarTarget is null");
            return;
        }

        // Apply host
        AvatarConnect.Core.AvatarObject = avatarTarget;

        // Initialize AvatarConnect
        AvatarConnect.Core.Initialize();

        // Activate all modules
        AvatarConnect.Core.ActivateAllModules();

        // Start AvatarConnect
        AvatarConnect.SDK.InitAvatarConnectSDK();

        AvatarConnect.SDK.EnableAvatarConnectSDK();

        // Packet served by the Avatar connect service

        // string avatarPacket = "{\"provider\": \"ready-player-me\", \"avatar\": {\"format\": \"glb\",\"uri\": \"https://xxxxxxxxxxxxxx.cloudfront.net/xxxxxxxxxxxxxxxxxxxxxxxxxx.glb?v=83685\", \"type\": \"humanoid\"}, \"metadata\": {\"bodyType\": \"fullbody\",\"outfitGender\": \"xxxxxxxxx\"}}";



        // Process the metadata packet
        // AvatarConnect.Core.ReceiveMetadata(avatarPacket);
    }
}