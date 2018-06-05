using FindWord.DAL.Repository;
using System;
using System.Threading.Tasks;

namespace FindWord.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IGenericRepository<Sentence> sentenceRepository;
        private ContextDB context;
        private bool disposed = false;

        public UnitOfWork(ContextDB context)
        {
            this.context = context;
        }

        public IGenericRepository<Sentence> SentenceRepository
        {
            get
            {
                if (sentenceRepository == null)
                {
                    sentenceRepository = new SentenceRepository(context);
                }

                return sentenceRepository;
            }
        }
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = false;
        }
    }
}