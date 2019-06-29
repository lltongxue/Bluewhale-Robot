using ProtoBuf;
using System.IO;

namespace Skynet.Models
{
    [ProtoContract]
    public class ToxResponse
    {
        [ProtoMember(1)]
        public string url { get; set; }

        [ProtoMember(2)]
        public string uuid { get; set; }

        [ProtoMember(3)]
        public byte[] content { get; set; }

        [ProtoMember(4)]
        public string fromNodeId { get; set; }

        [ProtoMember(5)]
        public string fromToxId { get; set; }

        [ProtoMember(6)]
        public string toNodeId { get; set; }

        [ProtoMember(7)]
        public string toToxId { get; set; }

        public byte[] getBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, this);
                return ms.ToArray();
            }
        }

        public static ToxResponse fromBytes(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Serializer.Deserialize<ToxResponse>(ms);
            }
        }
    }
}