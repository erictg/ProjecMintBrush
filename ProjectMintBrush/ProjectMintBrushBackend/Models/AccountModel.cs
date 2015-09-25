using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProjectMintBrushBackend.Models
{
    
    public class AccountModel : IModel
    {
        [Required]
        public virtual string Username { get; set; }
        [Required]
        public virtual string Password { get; set; }
        [Required]
        public virtual IdentificationNumber ID { get; set; }
        [Required]
        public virtual string Email { get; set; }
        //not required
        public virtual List<IdentificationNumber> EventsOwned { get; set; }
        public virtual List<IdentificationNumber> EntriesOwned { get; set; }
        public virtual List<IdentificationNumber> CommentEntries { get; set; }

        public AccountModel()
        {
            Username = "";
            Password = "";
            ID = IdentificationNumber.blankID();
            Email = "";
            EventsOwned = null;
            EntriesOwned = null;
            CommentEntries = null;
        }

        public static AccountModel CreateAccount(string username, string password, string email)
        {
            var am = new AccountModel()
            {
                Username = username,
                Password = password,
                Email = email,
                ID = IdentificationNumber.NewID(),
                EventsOwned = new List<IdentificationNumber>(),
                EntriesOwned = new List<IdentificationNumber>(),
                CommentEntries = new List<IdentificationNumber>()
            };
            am.EventsOwned.Add(IdentificationNumber.blankID());
            am.EntriesOwned.Add(IdentificationNumber.blankID());
            am.CommentEntries.Add(IdentificationNumber.blankID());

            return am;
        }

        public IdentificationNumber GetID()
        {
            return ID;
        }
    }

    public class IdentificationNumber
    {
        public string ID{ get; set; }

        public IdentificationNumber()
        {
            ID = "000000";
        }
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
            var random = new Random(); 
            var x = String.Format("{0:X6}", random.Next(int.MaxValue));
            SQLCommand.ExecuteQueryAddIDToIDList(x);
            return new IdentificationNumber(x);
            
        }
    }
}