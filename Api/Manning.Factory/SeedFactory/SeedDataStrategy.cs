namespace Manning.Factory.SeedFactory
{
    public static class SeedDataStrategy
    {
        public class SeedDataRegistry
        {
            public Action? SeedMethod { get; set; }
            public string? EntityName { get; set; }

            public virtual bool Any()
            {
                throw new NotImplementedException();
            }
        }

        public class SeedDataRegistry<T> : SeedDataRegistry
        {
            public Func<IQueryable<T>> DbSet { get; set; }

            public override bool Any()
            {
                return DbSet().Any();
            }

            public SeedDataRegistry(Func<IQueryable<T>> dbSet, Action seedMethod, string entityName)
            {
                DbSet = dbSet;
                SeedMethod = seedMethod;
                EntityName = entityName;
            }
        }
        public static void SeedStrategy(List<SeedDataRegistry> seedDataRegistries)
        {
            foreach (var reg in seedDataRegistries)
            {
                if (!reg.Any() && reg.SeedMethod != null)
                {
                    reg.SeedMethod();
                }
                else
                {
                    Console.WriteLine($"Skipped {reg.EntityName} - Data Already Found");
                }
            }
        }
    }
}