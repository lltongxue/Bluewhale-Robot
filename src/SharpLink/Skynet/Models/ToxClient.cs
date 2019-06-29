using System.Collections.Generic;

namespace Skynet.Models
{
    internal class ToxClient
    {
        public string Id { get; set; }
        public List<NodeInfo> nodes { get; set; }
    }
}