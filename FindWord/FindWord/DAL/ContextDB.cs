namespace FindWord.DAL
{
    using System.Data.Entity;

    public class ContextDB : DbContext
    {
        public virtual DbSet<Sentence> Sentences { get; set; }
        public ContextDB()
            : base("name=ContextDB")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ContextDB>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ContextDB>());
        }
    }
}