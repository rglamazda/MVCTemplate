
namespace Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        Entities dbContext;

        public Entities Init()
        {
            return dbContext ?? (dbContext = new Entities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
