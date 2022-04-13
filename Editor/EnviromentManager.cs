#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

using System.Reflection;

namespace AvatarConnect
{
    [InitializeOnLoad]
    public class EditorManager
    {
        static EditorManager()
        {
            char separator = Path.DirectorySeparatorChar;

            string this_path = Environment.FILE_PATH();
            string sdk_path = this_path.Replace(separator + "Editor" + separator + "EnviromentManager.cs", "");

            // Kill the UniGLTF.EditorSettingsValidator, It Causes significant performance degradation due to flawed implementation
            // TODO: add a helper method replacing separator insertion
            string validator_path = sdk_path + separator + "ThirdParty" + separator + "UniVRM" + separator + "Assets" + separator + "UniGLTF" + separator + "Editor" + separator + "EditorSettingsValidator";
            // Check if the folder exists
            if(Directory.Exists(validator_path))
            {
                // Remove the folder
                Directory.Delete(validator_path, true);
            }

        }
    }

    public class Environment
    {
        // Get the file path of the CURRENT source file calling the method
        public static string FILE_PATH([System.Runtime.CompilerServices.CallerFilePath] string fileName = "")
        {
            return fileName;
        }

        // Get the current line number calling the method
        public static int LINE([System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0)
        {
            return lineNumber;
        }
    }
}
#endif