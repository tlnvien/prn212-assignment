using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.Models
{
    public class Playlist
    {
        public string PlaylistName { get; set; }

        public List<string> MediaFiles {  get; set; }

        public Playlist(string playlistName)
        {
            PlaylistName = playlistName;
            MediaFiles = new List<string>();
        }

        public void AddMedia(string mediaPath)
        {
            MediaFiles.Add(mediaPath);
        }


    }
}
