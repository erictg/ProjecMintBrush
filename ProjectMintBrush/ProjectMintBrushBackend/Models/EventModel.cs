    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectMintBrushBackend.Models
{
    public class EventModel : IModel
    {
        //relational id numbers to map to other objects
        [Required]
        public virtual IdentificationNumber ID { get; set; }
        [Required]
        public virtual IdentificationNumber OwnedByUser { get; set; }
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
        



        //not required
        public virtual List<IdentificationNumber> Entries { get; set; }

        public EventModel()
        {

        }

        public EventModel(string userID, DateTime startTime, DateTime endTime, DateTime artistPickTime, double minPrice, double maxPrice, double optimalPrice)
        {
            ID = IdentificationNumber.NewID();
            OwnedByUser = new IdentificationNumber(userID);
            Entries = new List<IdentificationNumber>();
            StartTime = startTime;
            EndTime = endTime;
            ArtistPickTime = artistPickTime;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            OptimalPrice = optimalPrice;
        }

        public static EventModel CreateEvent(string userID, DateTime startTime, DateTime endTime, DateTime artistPickTime, double minPrice, double maxPrice, double optimalPrice)
        {
            var c = new EventModel()
            {
                ID = IdentificationNumber.NewID(),
                OwnedByUser = new IdentificationNumber(userID),
                Entries = new List<IdentificationNumber>(),
                StartTime = startTime,
                EndTime = endTime,
                ArtistPickTime = artistPickTime,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                OptimalPrice = optimalPrice
            };
            return c;
        }

        public IdentificationNumber GetID()
        {
            return ID;
        }
    }
}
