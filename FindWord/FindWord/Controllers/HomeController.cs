using FindWord.BLL;
using FindWord.DAL;
using FindWord.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FindWord.Controllers
{
    public class HomeController : Controller
    {
        private ISentenceManager sentenceManager;
        public HomeController()
        {
        }
        public HomeController(ISentenceManager sentenceManager)
        {
            this.sentenceManager = sentenceManager;
        }

        public async Task<ActionResult> Index()
        {
            IList<Sentence> sentence = new List<Sentence>();
            sentence = await sentenceManager.GetAll();
            ViewData["sentences"] = sentence;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Find(Keyword model)
        {
            if (ModelState.IsValid)
            {                
                string keyword = model.keyword;
                if (keyword == null || keyword == "")
                {
                    return RedirectToAction("Index", "Home");
                }
                await sentenceManager.Post(keyword);
            }
            return RedirectToAction("Index" , "Home" );
        }
        
    }
}