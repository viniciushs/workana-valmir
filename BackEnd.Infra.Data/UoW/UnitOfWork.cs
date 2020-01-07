namespace BackEnd.Infra.Data.UoW
{
    using BackEnd.Infra.Data.Contexts;
    using BackEnd.Infra.Data.Interfaces;
    using System.Threading.Tasks;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly BackEndContext context;

        public UnitOfWork(BackEndContext context)
        {
            this.context = context;
        }

        public bool Commit()
        {
            var rowsAffected = this.context.SaveChanges();
            return rowsAffected > 0;
        }

        public async Task CommitAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
