using GroupManager.Core.Model;
using GroupManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupManager.Core.Context
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Parents> Parents { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        
        public ApplicationContext()
            :base("DefaultConnection")
        {
            Database.SetInitializer(new ApplicationDbInitialier());
        }
    }
    public class ApplicationDbInitialier:CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            IList<Privilege>repository= new List<Privilege>();
            repository.Add(
                new Privilege { Header = "Малозабезпечені сім'ї", Id = Guid.NewGuid() }

                );
            repository.Add(
              new Privilege { Header = "Громадяни, які постраждали внаслідок Чорнобильської катастрофи", Id = Guid.NewGuid() }

              );
            repository.Add(
              new Privilege { Header = "Багатодітні сім'ї", Id = Guid.NewGuid() }

              );
            repository.Add(
              new Privilege { Header = "Учасники бойових дій", Id = Guid.NewGuid() }

              );
            context.Privileges.AddRange(repository);
            base.Seed(context);
        }
    }
}
