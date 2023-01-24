
namespace BoulangerieEtArroseur.Compteur.Source
{
    class Champ
    {
        /**
         * Une parcelle contient soit : 
         * - un plant, noté "x"
         * - un arroseur, noté "o"
         * Exemple pour une parcelle 3*3 :
         *      x x x
         *      x o x
         *      x x x
         * Cette parcelle contient 8 plant et 1 arroseur
         * 
         * Pour obtenir l'élément à la position [0, 0] : parcelle[0, 0]
         * Pour obtenir le nombre de lignes : parcelle.GetLength(0)
         * Pour obtenir le nombre de colonnes : parcelle.GetLength(1)
         */
        char[,] parcelle;
        char arroseur = 'o';
        char plant = 'x';

        public Champ(char[,] parcelle)
        {
            this.parcelle = parcelle;
        }

        public int GetNombreArrosseursEtPlants(char valeur)
        {
            int nombreColonnes = parcelle.GetLength(1);
            int nombreLignes = parcelle.GetLength(0);

            int occurence = 0;

            for (int i = 0; i < nombreColonnes; i++)
            {
                for (int j = 0; j < nombreLignes; j++)
                {
                    if (parcelle[j, i] == valeur)
                    {
                        occurence++;
                    }
                }
            }
            return occurence;
        }

        /**
         * Renvoie le nombre d'arroseurs présents dans la parcelle
         * Les arroseurs sont représentés par la lette "o"
         */
        public int GetNombreArroseurs()
        {
            return GetNombreArrosseursEtPlants(arroseur);
        }

        /**
         * Renvoie le nombre de plant présents dans la parcelle
         * Les plant sont représentés par la lettre "x"
         */
        public int GetNombrePlants()
        {
            return GetNombreArrosseursEtPlants(plant);
        }

        /**
         * Renvoie le nombre de plant arrosés dans la parcelle
         * Les plant sont représentés par la lettre "x"
         * On considère qu'un plant est arrosé s'il se trouve dans une case
         * adjacente à un arroseur.
         * Les diagonales comptent, donc un arroseur peut arroser jusqu'à 8 plant
         */
        public int GetNombrePlantsArroses()
        {
            int nombreColonnes = parcelle.GetLength(1);
            int nombreLignes = parcelle.GetLength(0);

            int plantsArosses = 0;

            for (int i = 0; i < nombreColonnes; i++)
            {
                for (int j = 0; j < nombreLignes; j++)
                {
                    if (parcelle[j,i] == arroseur)
                    {
                        for(int a = i-1; a < i+2; a++ )
                        {
                            for(int b = j-1; b < j+2; b++)
                            {
                                int n = i + a;
                                int m = j + b;

                                if(n > 0 && m < nombreColonnes)
                                {
                                    if(m > 0 && m < nombreLignes)
                                    {
                                        if (parcelle[m, n] == plant)
                                        {
                                            plantsArosses++;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
            return plantsArosses;
        }
    }
}
