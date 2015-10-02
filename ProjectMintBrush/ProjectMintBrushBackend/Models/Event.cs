    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectMintBrushBackend.Models
{
    public class Event
    {
        //relational id numbers to map to other objects
        [Key]
        [Required]
        public virtual int ID { get; set; }
        [Required]
        public virtual int UserID { get; set; }
        [Required]
        public virtual DateTime StartTime { get; set; }
        [Required]
        public virtual DateTime EndTime { get; set; }
        [Required]
        public virtual DateTime ArtistPickTime { get; set; }
        [Required]
        public virtual double MinPrice { get; set; }
        [Required]
        public virtual double MaxPrice { get; set; }
        [Required]
        public virtual double OptimalPrice { get; set; }

    }

   
}
