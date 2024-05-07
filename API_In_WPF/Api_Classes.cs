using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API_In_WPF
{
    class Api_Classes
    {
    }

    public class Joke()
    {
        public bool error { get; set; } = false;
        public string? category { get; set; } = null;
        public string? type { get; set; } = null;
        public string? setup { get; set; } = null;
        public string? delivery { get; set; } = null;
        public string? joke { get; set; } = null;
        public Flags? flags { get; set; } = null;
        public int id { get; set; } 
        public bool safe { get; set; } = false;
        public string? lang { get; set; } = null;

    }

    public class Flags {
        public bool nsfw { get; set; }
        public bool religious { get; set; }
        public bool political { get; set; }
        public bool racist { get; set; }
        public bool sexist { get; set; }

        [JsonPropertyName("explicit")]
        public bool Explicit { get; set; }

    }


    public class AnimalPic 
    {
        public string? id { get; set; } = null;

        public string? url { get; set; } = null;
        public int width { get; set; }
        public int height { get; set; }

        public string? image { get; set; } = null;
        public string? link { get; set; } = null;
    }

    public class AnimslImagesResponse
    {
        public List<AnimalPic> Images { get; set; }
    }


    public class  ReqUser
    {
        public int id { get; set; }
        public string email { get; set; } = null;
        public string first_name { get; set; } = null;
        public string last_name { get; set; } = null;
        public string avatar { get; set; } = null;
    }


    public class  ReqRespons
    {
        [JsonPropertyName("data")]
        public List<ReqUser> Userlist { get;}
    }
}
