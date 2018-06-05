using FindWord.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindWord.DAL
{
    public interface IUnitOfWork
    {
        IGenericRepository<Sentence> SentenceRepository { get; }

        Task SaveAsync();
    }
}
