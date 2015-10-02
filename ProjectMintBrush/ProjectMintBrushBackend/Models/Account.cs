using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ProjectMintBrushBackend.Enums;
namespace ProjectMintBrushBackend.Models
{
    
    public class Account
    {

        //login info
        [Key]
        [Required]
        public virtual int ID { get; set; }

        [Required]
        public virtual string Username { get; set; }

        [Required]
        public virtual string Password { get; set; }

        [Required]
        public virtual string Email { get; set; }


        //account info
        public virtual AccountType AccountType { get; set; }

        public virtual int PictureID { get; set; }

        public virtual string ProfilePictureURL { get; set; }


        //data
        public virtual int FollowerCount { get; set; }

        public virtual int FollowingCount { get; set; }



    }

}