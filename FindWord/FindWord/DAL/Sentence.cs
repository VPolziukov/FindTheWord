using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindWord.DAL
{
    public class Sentence
    {
        [Key]
        public int id { get; set; }
        [Column]
        public string sentence { get; set; }
        [Column]
        public int number { get; set; }
    }
}