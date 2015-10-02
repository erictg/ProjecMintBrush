using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProjectMintBrushBackend.Models
{
    public class Entry 
    {
        [Key]
        [Required]
        public virtual int ID { get; set; }
        [Required]
        public virtual int OwnedUserID { get; set; }
        [Required]
        public virtual int EventInID { get; set; }
        
        //it will also need its picture
        [Required]
        public virtual int PictureID { get; set; }
        [Required]
        public virtual string PictureUrl { get; set; }
    }
}