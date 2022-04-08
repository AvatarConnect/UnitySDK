using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AvatarConnect;

public class AvatarConnectExample : MonoBehaviour
{
    void Start()
    {
        // Create host object for the avatar
        GameObject avatar = new GameObject("Avatar");
        avatar.transform.parent = transform;

        // Apply host
        AvatarConnect.Core.AvatarObject = avatar;

        // Initialize AvatarConnect
        AvatarConnect.Core.Initialize();

        // Activate all modules
        AvatarConnect.Core.ActivateAllModules();

        // Packet served by the Avatar connect service
        string avatarPacket = "";

        // Process the metadata packet
        AvatarConnect.Core.ReceiveMetadata(avatarPacket);
    }
}