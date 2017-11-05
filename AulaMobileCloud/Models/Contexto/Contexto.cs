using AulaMobileCloud.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AulaMobileCloud.Models.Contexto
{
    public class Contexto : DbContext
    {
       
            public Contexto() 
            {
            }

            public System.Data.Entity.DbSet<AulaMobileCloud.Models.Characters> Character { get; set; }
          
    }
}