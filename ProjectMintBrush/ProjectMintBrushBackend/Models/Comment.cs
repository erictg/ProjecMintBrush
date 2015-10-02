using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ProjectMintBrushBackend.Models
{
    public class Comment 
    {
        [Key]
        [Required]
        public virtual int ID { get; set; }
        [Required]
        public virtual int UserOwned { get; set; }
        [Required]
        public virtual int EntryOwned { get; set; }
        [Required]
        public virtual DateTime TimeCreated { get; set; }
        [Required]
        public virtual String Text { get; set; }

        
    }
}
