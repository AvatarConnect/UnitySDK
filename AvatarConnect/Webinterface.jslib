mergeInto(LibraryManager.library, {

    InitAvatarConnectSDK: function () {
        console.log("InitAvatarConnectSDK");
        window.avatarConnectSDKInit();
    },

    EnableAvatarConnectSDK: function () {
        console.log("EnableAvatarConnectSDK");
        window.avatarConnectSDKEnable();
    },

    DisableAvatarConnectSDK: function () {
        console.log("DisableAvatarConnectSDK");
        window.avatarConnectSDKDisable();
    },
    
});
