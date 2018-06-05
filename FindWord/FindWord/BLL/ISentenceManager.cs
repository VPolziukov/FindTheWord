using FindWord.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindWord.BLL
{
    public interface ISentenceManager
    {
        Task<List<Sentence>> GetAll();
        Task Post(string keyword);
    }
}
