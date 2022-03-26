using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace ProgPokedexConsol
{
    class Option
    {
        public static void Menu()
        {
            string optionChoice;
            
            do
            {
                Console.WriteLine("\n\n1) Afficher la liste des Pokémons\n2) Afficher un Pokémon de chaque type pour chaque génération\n3) Afficher tout les Pokémons d'un type\n4) Afficher tous les Pokémons de la génération de votre choix\n5) Afficher la moyenne des poids des Pokémons du type de votre choix\n6) Afficher le pokemon par son id\n7) Pour quitter\n\n");
                optionChoice = Console.ReadLine();
                Console.Clear();
            } while (optionChoice == null && optionChoice != "1" && optionChoice != "2" && optionChoice != "3" && optionChoice != "4" && optionChoice != "5");
            switch (optionChoice)
            {
                case "1":
                    GetNameId(DownloadPokemon.listePokemon);
                    break;
                    
                case "2":
                    GetOnePokemonPerTypePerGen(DownloadPokemon.listePokemon);
                    break;
                    
                case "3":
                    GetAllThePokemonOfOneType(DownloadPokemon.listePokemon);
                    break;
                    
                case "4":
                    GetAllThePokemonOfOneGeneration(DownloadPokemon.listePokemon);
                    break;
                    
                case "5":
                    GetAverageWeightOfOneType(DownloadPokemon.listePokemon);
                    break;
                case "6":
                    GetPokemonById(DownloadPokemon.listePokemon);
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                case "727":
                    Console.WriteLine("WYSI !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Enfaite c'est pas drôle...");
                    break;
            }
        }   
        /// <summary>
        /// Affichage de la liste des pokemons
        /// </summary>
        /// <param name="pokemons"></param>
        public static void GetNameId(List<Pokemon> pokemons)
        {
            var table = new ConsoleTable("Nom", "Name", "Id");
            foreach (var pokemon in pokemons)
            {
                table.AddRow(pokemon.name.fr, pokemon.name.en, pokemon.id);
            }
            table.Write();
            Menu();

        }
        /// <summary>
        /// Affiche un pokemon par type par génération aléatoirement
        /// </summary>
        /// <param name="pokemons"></param>
        public static void GetOnePokemonPerTypePerGen(List<Pokemon> pokemons)
        {
            
            Random random = new Random();
            int randomPokemon;
            
            int[,] listeGeneration = DownloadPokemon.listeGen();
            
            for (int i = 0; i < listeGeneration.GetLength(0); i++)
            {
                Console.WriteLine("\n\nPokémon de random de chaque type de la génération: " + i);
                var table = new ConsoleTable("Nom", "Name", "Id", "Type 1");
                List<string> listeTypePokemonDone = new List<string>();                               
                for (int j = 0; j < listeGeneration[i,1]; j++)
                {
                    randomPokemon = random.Next(listeGeneration[i, 0], listeGeneration[i, 1]);
                    if (!listeTypePokemonDone.Contains(pokemons[randomPokemon].types[0]))
                    {
                        listeTypePokemonDone.Add(pokemons[randomPokemon].types[0]);
                        table.AddRow(pokemons[randomPokemon].name.fr, pokemons[randomPokemon].name.en, pokemons[randomPokemon].id, pokemons[randomPokemon].types[0]);
                    }
                    
                }
                table.Write();
            }

            Menu();
        }
        /// <summary>
        /// Affichage de tous les pokemons d'un type
        /// </summary>
        /// <param name="pokemons"></param>
        public static void GetAllThePokemonOfOneType(List<Pokemon> pokemons)
        {
            var table = new ConsoleTable("Nom", "Name", "Id", "Type 1","Type 2");
            string typeChosen;
            Console.WriteLine("Quel type de pokemon voulez-vous afficher ?");
            DownloadPokemon.getListOfTypes();
            typeChosen = Console.ReadLine();
            foreach (var pokemon in pokemons)
            {
                //Add to the list if the type is the same as the one chosen
                if (pokemon.types.Contains(typeChosen))
                {
                    string type1;
                    string type2;
                    if (pokemon.types.Count == 1)
                    {
                        type1 = pokemon.types[0];
                        type2 = "";
                    }
                    else
                    {
                        type1 = pokemon.types[0];
                        type2 = pokemon.types[1];
                    }
                    table.AddRow(pokemon.name.fr, pokemon.name.en, pokemon.id, type1, type2); 
                }

            }
            table.Write();

            Menu();
        }

        public static void GetAllThePokemonOfOneGeneration(List<Pokemon> pokemons)
        {
            var table = new ConsoleTable("Nom", "Name", "Id", "Type 1", "Type 2");
            int generationChosen;
            int[,] generationTest = DownloadPokemon.listeGen();
            Console.WriteLine("Quelle génération voulez-vous afficher ?");
            generationChosen = int.Parse(Console.ReadLine());

            foreach (var pokemon in pokemons)
            {
                //Add to the list if the type is the same as the one chosen
                if (pokemon.id <= generationTest[generationChosen-1,1] && pokemon.id >= generationTest[generationChosen-1,0])
                {
                    string type1;
                    string type2;
                    if (pokemon.types.Count == 1)
                    {
                        type1 = pokemon.types[0];
                        type2 = "";
                    }
                    else
                    {
                        type1 = pokemon.types[0];
                        type2 = pokemon.types[1];
                    }
                    table.AddRow(pokemon.name.fr, pokemon.name.en, pokemon.id, type1, type2);
                }

            }
            table.Write();
            Menu();
        }

        public static void GetAverageWeightOfOneType(List<Pokemon> pokemons)
        {
            string typeChosen;
            float tailleTot=0, poidsTot=0;
            int nbpokemon=0;
            Console.WriteLine("De quel type de pokemon voulez-vous donc le poids moyen ?");
            DownloadPokemon.getListOfTypes();
            typeChosen = Console.ReadLine();
            foreach(Pokemon pokemon in pokemons)
            {
                if (pokemon.types.Contains(typeChosen))
                {
                    poidsTot += pokemon.weight;
                    tailleTot += pokemon.height;
                    nbpokemon++;
                }
            }
            Console.WriteLine("La moyenne des poids des " + nbpokemon + " pokemons de type " + typeChosen + " est de: " + poidsTot / nbpokemon + "kg et la taille moyenne de:" + tailleTot / nbpokemon + "cm" );
            Menu();
        }
       
        public static void GetPokemonById(List<Pokemon> pokemons)
        {
            int idChosen;
            var table = new ConsoleTable("Nom", "Name", "Type 1", "Type 2");
            Console.WriteLine("Id du pokemon");
            idChosen = int.Parse(Console.ReadLine());
            foreach (Pokemon pokemon in pokemons)
            {
                if (pokemon.id == idChosen)
                {
                    //Si tu piges pas c'est pas grave tkt c'est une joke/ osu! ref
                    if (idChosen == 727)
                    {
                        Console.WriteLine("Bon... tu passes pas les 4* là moi j'ai 500pp là va train connard");
                    }
                    table.AddRow(pokemon.name.fr, pokemon.name.en, pokemon.types[0], pokemon.types[1]);

                }
            }
            table.Write();
            Menu();
        }
    }
}
