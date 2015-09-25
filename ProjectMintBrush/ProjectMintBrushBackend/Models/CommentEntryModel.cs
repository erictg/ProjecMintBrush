using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ProjectMintBrushBackend.Models
{
    public class CommentEntryModel : IModel
    {
        [Required]
        public virtual IdentificationNumber ID { get; set; }
        [Required]
        public virtual IdentificationNumber UserOwned { get; set; }
        [Required]
        public virtual IdentificationNumber EntryOwned { get; set; }
        [Required]
        public virtual DateTime TimeCreated { get; set; }
        [Required]
        public virtual String Comment { get; set; }

        public static CommentEntryModel CreateComment(IdentificationNumber userID, IdentificationNumber entryID, string comment)
        {
            CommentEntryModel c = new CommentEntryModel()
            {
                ID = IdentificationNumber.NewID(),
                UserOwned = userID,
                EntryOwned = entryID,
                TimeCreated = DateTime.UtcNow,
                Comment = comment
            };
            return c;
        }
        public IdentificationNumber GetID()
        {
            return ID;
        }
    }
}
