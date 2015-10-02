using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
namespace ProjectMintBrushBackend.Models
{
    public class Portfolio
    {
        [Key]
        [Required]
        public virtual int ID { get; set; }

        [Required]
        public virtual int ArtistID { get; set; }

        [Required]
        public virtual int EntryID { get; set; }

    }
}
