using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProjectMintBrushBackend.Models
{
    public class AccountModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public IdentificationNumber ID { get; set; }

        //not required
        public List<IdentificationNumber> EventsOwned { get; set; }
        public List<IdentificationNumber> EntriesOwned { get; set; }
        public List<IdentificationNumber> ChatEntries { get; set; }
    }

    public class IdentificationNumber
    {
        public string ID{ get; set; }

        
        public IdentificationNumber(string id)
        {
            ID = id;

        }
        public static IdentificationNumber blankID()
        {
            return new IdentificationNumber("000000");
        }
        public static IdentificationNumber NewID()
        {
            //some logic to create a random hex code
            return new IdentificationNumber("000000");
        }
    }
}