using Newtonsoft.Json;

namespace AvatarConnect
{
    // Result of a operation
    public class AvatarConnectResult
    {
        // If the operation was successful
        public bool Success;

        // If the operation succeeded then this will contain the result
        public object OperationResult;

        // If the operation failed then this will contain the error
        public string Error;
    }

}