
namespace DoAn.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private DoAnDbContext dbContext;

        public DoAnDbContext Init()
        {
            return dbContext ?? (dbContext = new DoAnDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}