using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProjectMintBrushBackend.Models
{
    public class EntryModel : IModel
    {
        [Required]
        public IdentificationNumber ID { get; set; }
        [Required]
        public IdentificationNumber OwnedUserID { get; set; }
        [Required]
        public IdentificationNumber EventIn { get; set; }
        public IdentificationNumber GetID()
        {
            return ID;
        }
        //it will also need its picture
    }
}