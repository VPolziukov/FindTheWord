using FindWord.DAL;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace FindWord.BLL
{
    public class SentenceManager : ISentenceManager
    {
        private IUnitOfWork unitOfWork;
        public SentenceManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Post(string keyword)
        {            
            string path = HttpContext.Current.Server.MapPath(@"~/App_Data/UploadedFiles/some.txt");
            int id = 1;
            string text = File.ReadAllText(path);
            var allsentences = text.Split('.');             
            foreach (var sentence in allsentences)
            {
                int numberOfInclude = 0;
                var allwords = sentence.Split(' ');
                foreach (var word in allwords)
                {
                    if (keyword.ToLower() == word.ToLower())
                    {
                        numberOfInclude++;
                    }                    
                }
                if (numberOfInclude > 0) 
                {
                    string resultString = "";
                    for (int i = allwords.Length - 1; i >= 0; i--)
                    {
                        resultString += allwords[i] + ' ';
                    }
                    Sentence _sentence = new Sentence()
                    {
                        id = id,
                        sentence = resultString,
                        number = numberOfInclude
                    };
                    unitOfWork.SentenceRepository.Insert(_sentence);
                    await unitOfWork.SaveAsync();
                }
            }          
        }
        public async Task<List<Sentence>> GetAll()
        {
            var sentenceList =  await unitOfWork.SentenceRepository.GetAll();
            return sentenceList;
        }
    }
}