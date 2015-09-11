using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProjectMintBrushBackend.Models
{
    public class EntryModel
    {
        [Required]
        public IdentificationNumber ID { get; set; }
        [Required]
        public IdentificationNumber OwnedUserID { get; set; }
        [Required]
        public IdentificationNumber EventIn { get; set; }

        //it will also need its picture
    }
}