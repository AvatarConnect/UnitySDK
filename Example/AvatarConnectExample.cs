using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AvatarConnect;

public class AvatarConnectExample : MonoBehaviour
{
    public GameObject avatarTarget;

    void Start()
    {
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

        string avatarPacket = ""; // (*Testing only*) Left blank for example, fill this with your avatar packet

        // Process the metadata packet
        AvatarConnect.Core.ReceiveMetadata(avatarPacket);
    }
}