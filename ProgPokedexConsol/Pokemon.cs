using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPokedexConsol
{
    class JSONPokemon
    {
        public int id { get; set; }
        public string url { get; set; }
        public long lastEdit { get; set; }
    }
    public class name
     {
         public string en { get; set; }
         public string fr { get; set; }
     }

     public class genus
     {
         public string en { get; set; }
         public string fr { get; set; }
     }

     public class description
     {
         public string en { get; set; }
         public string fr { get; set; }
     }

     public class Pokemon
     {
         public int id { get; set; }
         public name name { get; set; }
         public List<string> types { get; set; }
         public int height { get; set; }
         public float weight { get; set; }
         public genus genus { get; set; }
         public description description { get; set; }

     }
    
}
