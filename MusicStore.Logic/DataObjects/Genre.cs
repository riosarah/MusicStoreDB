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
    [Table("Genre")]
    public class Genre : EntityObject, IGenre
    {
        [MaxLength(256)]
        public string Name { get; set; }
        public List<Track> Tracks { get; set; }
    }
}
