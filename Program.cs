using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace jeu_du_pendu
{
    internal class Program
    {
        static void AfficherMots(string mot, List<char> lettres)
        {
            for (int i = 0; i < mot.Length; i++) // inférieur ac la longueur du mots 
            {
                char lettre = mot[i];  //exepmle mot[1]= E

                if (lettres.Contains(lettre))
                {
                    Console.Write(lettre + " ");

                }

                else
                {
                    Console.Write("_ ");
                }

            }
        }
        static bool ToutesLettresDevinees(string mots, List<char> lettres)
        {

            foreach (var lettre in lettres)
            {
                mots = mots.Replace(lettres.ToString(), ""); // prendre la premier letre du tableau et le remplacer en une ch vide 

            }

            if (mots.Length == 0)

            {
                return true;
            }

            return false;

        }

        static char DemenderUneLettre()
        {

            while (true)

            {

                Console.Write("Rentrez une lettre : ");
                string reponse = Console.ReadLine();
                if (reponse.Length == 1) //longueur du caractere 
                {
                    reponse = reponse.ToUpper();
                    return reponse[0];
                }

                Console.WriteLine("ERREUR : Vous devez rentrer un seuler lettre");
            }


        }

        static void DevinerMots(string mots)
        {
            var lettresDevines = new List<char>();
            const int NBR_VIE = 6;
            int ViesRestant = NBR_VIE;

            while (ViesRestant > 0)

            {

                AfficherMots(mots, lettresDevines);
                Console.WriteLine();
                var lettre = DemenderUneLettre();
                Console.Clear();

                if (mots.Contains(lettre))
                {
                    Console.WriteLine(" Cette lettre est dans le mots ");
                    lettresDevines.Add(lettre);



                    if (ToutesLettresDevinees(mots, lettresDevines))
                    {

                      
                        break;


                    }
                }
                else
                {
                    Console.WriteLine(" Cette lettre n'est  pas dans le mots ");
                    ViesRestant--;
                    Console.WriteLine(" Vie restant : " + ViesRestant);

                }
                Console.WriteLine();
            }


            if (ViesRestant == 0)
            {
                Console.WriteLine("  PERDU ! LE MOTS ETAIT : " + mots);

            }
            else
            {
               
                Console.WriteLine();
                Console.WriteLine(" GAGNE ");

            }


        }
        static void Main(string[] args)
        {
            string mots = "ELEPHANT";

            DevinerMots(mots);

            /*
             char lettre = DemenderUneLettre();
             AfficherMots(mots, new List<char> { lettre });

             */




        }
    }
}