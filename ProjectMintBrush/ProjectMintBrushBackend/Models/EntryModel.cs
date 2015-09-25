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
        public virtual IdentificationNumber ID { get; set; }
        [Required]
        public virtual IdentificationNumber OwnedUserID { get; set; }
        [Required]
        public virtual IdentificationNumber EventIn { get; set; }
        public IdentificationNumber GetID()
        {
            return ID;
        }
        //it will also need its picture
    }
}