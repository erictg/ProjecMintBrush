﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ProjectMintBrushBackend.Models
{
    public class ChatEntryModel
    {
        [Required]
        public IdentificationNumber ID { get; set; }
        [Required]
        public IdentificationNumber UserOwned { get; set; }
        [Required]
        public IdentificationNumber EntryOwned { get; set; }
        [Required]
        public DateTime TimeCreated { get; set; }
        [Required]
        public String Comment { get; set; }

        public static ChatEntryModel CreateComment(IdentificationNumber userID, IdentificationNumber entryID, string comment)
        {
            ChatEntryModel c = new ChatEntryModel()
            {
                ID = IdentificationNumber.NewID(),
                UserOwned = userID,
                EntryOwned = entryID,
                TimeCreated = DateTime.UtcNow,
                Comment = comment
            };
            return c;
        }

    }
}
