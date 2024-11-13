using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.Models
{
    public class RecentlyMedia
    {
        public string FileName { get; set; }

        public string CoverArt { get; set; }

        public MediaType MediaType { get; set; }
    }
}
