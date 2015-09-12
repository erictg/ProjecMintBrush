    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectMintBrushBackend.Models
{
    public class EventModel
    {
        //relational id numbers to map to other objects
        [Required]
        public IdentificationNumber ID { get; set; }
        [Required]
        public IdentificationNumber OwnedByUser { get; set; }
        //not required
        public List<IdentificationNumber> Entries { get; set; }


        public static EventModel CreateEvent(IdentificationNumber userID)
        {
            var c = new EventModel()
            {
                ID = IdentificationNumber.NewID(),
                OwnedByUser = userID,
                Entries = new List<IdentificationNumber>()
            };
            return c;
        }
    }
}
