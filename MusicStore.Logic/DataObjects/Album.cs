using MusicStore.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Logic.DataObjects
{
    [Table("Album")]
    public class Album : EntityObject, IAlbum
    {
        [MaxLength(256)]
        public int ArtistId { get; set; }
        [MaxLength(256)]
        public string Title { get; set; }
        public Artist? Artist { get; set; }
        public List<Track> Tracks { get; set; }
    }
}
