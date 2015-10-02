using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectMintBrushBackend.Models
{
    public class ProjectMintBrushBackendContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ProjectMintBrushBackendContext() : base("name=ProjectMintBrushBackendContext")
        {
        }

        public System.Data.Entity.DbSet<ProjectMintBrushBackend.Models.Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<ProjectMintBrushBackend.Models.Entry> Entries { get; set; }

        public System.Data.Entity.DbSet<ProjectMintBrushBackend.Models.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<ProjectMintBrushBackend.Models.Event> Events { get; set; }

        public System.Data.Entity.DbSet<ProjectMintBrushBackend.Models.Portfolio> Portfolios { get; set; }
    
    }
}
