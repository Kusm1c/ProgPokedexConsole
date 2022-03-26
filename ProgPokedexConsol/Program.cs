using ProgPokedexConsol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProgPokedexConsol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DownloadPokemon.DownloadGeneration(); 
        }
    }
}