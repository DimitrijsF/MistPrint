using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MistPrintCore.Models
{
    public class FileSystem
    {
        [Serializable]
        public class Directory
        {
            [JsonProperty("Name")]
            public string Name { get; set; }
            [JsonProperty("Directories")]
            public List<Directory> Directories { get; set; }
            [JsonProperty("Files")]
            public List<File> Files { get; set; }
        }
        [Serializable]
        public class File
        {
            [JsonProperty("Name")]
            public string Name { get; set; }
            [JsonProperty("Size")]
            public double Size { get; set; }
            [JsonProperty("Modified")]
            public DateTime Modified { get; set; }
            [JsonProperty("Path")]
            public string Path { get; set; }
        }
    }
}
