namespace Skynet.Models
{
    public class NodeResponse
    {
        public NodeResponseCode statusCode;
        public string description;
        public string value;
        public long time;
    }

    public enum NodeResponseCode
    {
        NotFound,
        OK,
        InvalidRequest,
        InvalidRequestMethod,
        TargetLocked,
        TargetIsFull,
        AlreadyExist,
        NoPermission,
        OutOfDate
    }
}