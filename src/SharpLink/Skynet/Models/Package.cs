using ProtoBuf;
using System;
using System.IO;

namespace Skynet.Models
{
    [ProtoContract]
    public class Package
    {
        [ProtoMember(1)]
        public string uuid { get; set; } // 36 bytes string

        [ProtoMember(2)]
        public byte[] content { get; set; }

        [ProtoMember(3)]
        public int totalCount { get; set; }

        [ProtoMember(4)]
        public int currentCount { get; set; }

        [ProtoMember(5)]
        public uint totalSize { get; set; }

        [ProtoMember(6)]
        public uint startIndex { get; set; }

        private static Package mStaticPackage = null;

        public byte[] toBytes()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, this);
                return ms.ToArray();
            }
        }

        public static Package fromBytes(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Serializer.Deserialize<Package>(ms);
            }
        }

        public static Package fromBytesStatic(byte[] data)
        {
            byte[] uuidbytes = new byte[16];
            for (int i = 0; i < 16; i++)
            {
                uuidbytes[i] = data[i];
            }
            if (mStaticPackage == null)
                mStaticPackage = new Package();
            mStaticPackage.uuid = new Guid(uuidbytes).ToString();
            mStaticPackage.totalCount = data[18] * 256 + data[19];
            mStaticPackage.currentCount = data[20] * 256 + data[21];
            mStaticPackage.totalSize = BitConverter.ToUInt32(data, 22);
            mStaticPackage.startIndex = BitConverter.ToUInt32(data, 26);
            mStaticPackage.content = new byte[data[16] * 256 + data[17]];

            for (int i = 0; i < mStaticPackage.content.Length; i++)
            {
                mStaticPackage.content[i] = data[30 + i];
            }
            return mStaticPackage;
        }
    }
}