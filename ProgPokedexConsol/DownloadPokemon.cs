using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace ProgPokedexConsol
{
    class DownloadPokemon
    {
        private static Task[] tasks = new Task[8];
        public static List<Pokemon> listePokemon = new List<Pokemon>();
        public static int[,] listeGen()
        {
            return new int[,]
            {
                {1, 151, 1},
                {152, 251, 2},
                {252, 386, 3},
                {387, 493, 4},
                {494, 649, 5},
                {650, 721, 6},
                {722, 802, 7},
                {803, 898, 8}
            };
        }

        public static string[] listeType()
        {
            return new string[]
            {
                "Normal" , "Fire", 
                "Water", "Grass",
                "Electric", "Ice" ,
                "Fighting", "Poison" ,
                "Ground", "Flying" ,
                "Psychic", "Bug" ,
                "Rock", "Ghost" ,
                "Dark", "Dragon" ,
                "Steel", "Fairy"
            };
        }


        /// <summary>
        /// Download all pokemon
        /// </summary>
        public static void DownloadGeneration()
        {
            int[,] tabGen = listeGen();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //On remplit la liste de listes vides pour après pouvoir Insert à l'indice qu'on souhaite
            tasks[0] = Task.Run(() => { DownloadPokemonFromJSON(tabGen[0,0], tabGen[0,1], tabGen[0,2]); });
            tasks[1] = Task.Run(() => { DownloadPokemonFromJSON(tabGen[1,0], tabGen[1,1], tabGen[1,2]); });
            tasks[2] = Task.Run(() => { DownloadPokemonFromJSON(tabGen[2,0], tabGen[2,1], tabGen[2,2]); });
            tasks[3] = Task.Run(() => { DownloadPokemonFromJSON(tabGen[3,0], tabGen[3,1], tabGen[3,2]); });
            tasks[4] = Task.Run(() => { DownloadPokemonFromJSON(tabGen[4,0], tabGen[4,1], tabGen[4,2]); });
            tasks[5] = Task.Run(() => { DownloadPokemonFromJSON(tabGen[5,0], tabGen[5,1], tabGen[5,2]); });
            tasks[6] = Task.Run(() => { DownloadPokemonFromJSON(tabGen[6,0], tabGen[6,1], tabGen[6,2]); });
            tasks[7] = Task.Run(() => { DownloadPokemonFromJSON(tabGen[7,0], tabGen[7,1], tabGen[7,2]); });

            Task.WaitAll(tasks);
            sw.Stop();
            listePokemon.Sort((pkmn1, pkmn2) => { return pkmn1.id.CompareTo(pkmn2.id); });
            Thread.Sleep(2000); Console.Clear();
            Console.WriteLine("Downloading time: " + sw.ElapsedMilliseconds + " ms");
            Option.Menu();
        }

        public static void getListOfTypes()
        {
            var table = new ConsoleTable("type", "type");
            table.AddRow("Normal", "Fire");
            table.AddRow("Water", "Grass");
            table.AddRow("Electric", "Ice");
            table.AddRow("Fighting", "Poison");
            table.AddRow("Ground", "Flying");
            table.AddRow("Psychic", "Bug");
            table.AddRow("Rock", "Ghost");
            table.AddRow("Dark", "Dragon");
            table.AddRow("Steel", "Fairy");

            table.Write();
        }

        /// <summary>
        /// Download all pokemon of a generation
        /// </summary>
        /// <param name="gen"></param>
        /// <param name="borne_inf"></param>
        /// <param name="borne_sup"></param>
        public static void DownloadPokemonFromJSON(int borne_inf, int borne_sup, int gen)
        {
            int i;
            List<Pokemon> temp = new List<Pokemon>();
            Console.WriteLine("Génération numéro " + gen + " en chargement !");

            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                                
                for (i = borne_inf; i <= borne_sup; i++)
                {
                    string jsonStringPerPokemon = webClient.DownloadString("https://tmare.ndelpech.fr/tps/pokemons/" + i);
                    //listePokemon.Add(JsonSerializer.Deserialize<Pokemon>(jsonString));
                    temp.Add(JsonSerializer.Deserialize<Pokemon>(jsonStringPerPokemon));
                    //Console.WriteLine("\r" + pokemon.id);
                }
                listePokemon.AddRange(temp);
                Console.WriteLine("Génération numéro " + gen + " chargé");
                               

            }

        }
    }
}
