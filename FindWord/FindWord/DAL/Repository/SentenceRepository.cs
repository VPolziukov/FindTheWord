using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindWord.DAL.Repository
{
    public class SentenceRepository : GenericRepository<Sentence>
    {
        private readonly List<Sentence> _sentence;
        public SentenceRepository(ContextDB context) : base(context)
        {
        }

        public override async Task<Sentence> GetAsync(params object[] id)
        {
            var sentence = await base.GetAsync(id);

            if (sentence == null)
            {
                return null;
            }

            return sentence;
        }

        //public override async Task<List<Sentence>> GetAll()
        //{
        //    return await Task.Run(() => _sentence);
        //}
        
    }
}