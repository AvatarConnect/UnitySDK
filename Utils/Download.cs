// Downloader for Avatar Connect.
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;

namespace AvatarConnect
{
    public static class Downloader
    {
        // URL sanity check
        public static bool IsValidUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return false;
            if (url.StartsWith("http://") || url.StartsWith("https://")) return true;
            return false;
        }

        // Request downloads, returns the downloadHandler.
        public static async Task<AvatarConnectResult> Download(string url)
        {
            if (!IsValidUrl(url))
            {
                AvatarConnectError.Fail(AvatarConnectError.INVALID_URL);

                return new AvatarConnectResult()
                {
                    Success = false,
                    OperationResult = null,
                    Error = AvatarConnectError.INVALID_URL
                };
            }

            // Construct the request
            UnityWebRequest request = UnityWebRequest.Get(url);

            // Send the request
            var download = request.SendWebRequest();

            // Wait for the request to complete
            while (!download.isDone)
            {
                await Task.Yield();
            }

            // Check for errors
            if (request.isNetworkError || request.isHttpError)
            {
                // Flag failure
                AvatarConnectError.Fail(AvatarConnectError.MODULE_RESOURCE_DOWNLOAD_FAIL);

                // Return the error
                return new AvatarConnectResult()
                {
                    Success = false,
                    OperationResult = null,
                    Error = request.error
                };
            }

            // Return the result
            return new AvatarConnectResult()
            {
                Success = true,
                OperationResult = request.downloadHandler,
                Error = null
            };
        }
    }
}