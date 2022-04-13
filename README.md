# AvatarConnect Unity SDK
Implementation of runtime NFT character loading for Unity games and social platforms; currently, GLTF & VRM 3D model formats are supported. 

Learn more about AvatarConnect http://avatarconnect.org/

# Using the SDK

Required Unity Project settings:

`Player / Other Settings / Script Compilation / Allow 'unsafe' Code -> true`

Required Unity Packages:

`com.unity.nuget.newtonsoft-json`

# Implement your project into AvatarConnect

AvatarConnect In Unity works by implementing each provider as a Module class; this class handles all runtime events that you can customize or change depending on what your project requires.

To begin adding support for your project, you'll need your partner folder; create one like this:
`partners/<Your Project>`
Feel free to structure your project after your preference, but we do suggest keeping a `partners/<Your Project>/module.cs` at your root that implements the main.cs.

# License

MIT (http://opensource.org/licenses/MIT)
