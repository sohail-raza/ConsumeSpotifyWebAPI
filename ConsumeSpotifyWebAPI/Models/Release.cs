using System.ComponentModel.DataAnnotations;

namespace ConsumeSpotifyWebAPI.Models
{
    public class Release
    {
        [Key]
       public string Id { get; set; }
        public string Name { get; set; }
        public string Artists { get; set; }
        public string Date { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
    }
}
