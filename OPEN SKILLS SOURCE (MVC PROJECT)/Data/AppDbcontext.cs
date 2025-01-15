using OPEN_SKILLS_SOURCE__MVC_PROJECT_.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OPEN_SKILLS_SOURCE__MVC_PROJECT_.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {

        }

        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<ContactForms> ContactForms { get; set; }


    }
}
