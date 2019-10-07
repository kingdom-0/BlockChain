using System.Data.Entity;
using IoT.WCD.BlockChain.Infrastructure.Interfaces;

namespace IoT.WCD.BlockChain.Infrastructure
{
    class PersonalDataDbContext : DbContext, IDbContext
    {
        public PersonalDataDbContext():base("name=iot_personal_data")
        {
            Database.SetInitializer<PersonalDataDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //TODO: Add entity info.
            base.OnModelCreating(modelBuilder);
        }
    }
}
