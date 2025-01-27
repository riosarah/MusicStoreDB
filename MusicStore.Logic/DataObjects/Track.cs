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
    [Table("Tracks")]
    public class Track : EntityObject, ITrack
    {
        [MaxLength(256)]
        public int AlbumId { get; set; }
        [MaxLength(256)]
        public int GenreId { get; set; }
        [MaxLength(256)]
        public string Title { get; set; }
        [MaxLength(256)]
        public string Composer { get; set; }
        [MaxLength(256)]
        public long Milliseconds { get; set; }
        [MaxLength(256)]
        public long Bytes { get; set; }
        [MaxLength(256)]
        public double UnitPrice { get; set; }
        public Album? Album { get; set; }
        public Genre? Genre { get; set; }
    }
}
