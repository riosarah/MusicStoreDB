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
    [Table("Artist")]
    public class Artist : EntityObject, IArtist
    {
        [MaxLength(256)]
        public string Name { get; set; }
        public List<Album> Albums { get; set; }
    }
}
