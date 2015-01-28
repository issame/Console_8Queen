using System;

namespace Console_8Queen
{
    class Program
    {
        static int sol;
        static char[,] tableau = new char[8, 8];

        static void ponerReina(int i, int j)
        {
            tableau[i, j] = 'X';
        }

        static void quitarReina(int i, int j)
        {
            tableau[i, j] = '.';
        }

        static bool posicionSegura(int m, int n)
        {
            if (tableau[m, n] != 'X')
            {
                for (int a = 0; a < 8; a++)
                {
                    for (int b = 0; b < 8; b++)
                    {
                        if ((a + b) == (m + n))
                        {
                            if (tableau[a, b] == 'X')
                            {
                                return false;
                            }
                        }

                        if ((a - b) == (m - n))
                        {
                            if (tableau[a, b] == 'X')
                            {
                                return false;
                            }
                        }

                        if (a == m)
                        {
                            if (tableau[a, b] == 'X')
                            {
                                return false;
                            }
                        }

                        if (b == n)
                        {
                            if (tableau[a, b] == 'X')
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            else
                return false;

            return true;
        }

        private static void inicializar()
        {
            sol = 1;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    tableau[i, j] = '.';
                }
            }
        }

        static void afficher()
        {
            Console.WriteLine("Solucion " + sol);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("|_" + tableau[i, j] + "_");
                }
                Console.Write("|");
                Console.WriteLine();
            }
            sol++;
        }

        private static void tester(int i)
        {
            for (int j = 0; j < 8; j++)
            {
                if (posicionSegura(j, i))
                {
                    ponerReina(j, i);
                    if (i < 7)
                    {
                        tester(i + 1);
                    }
                    else
                        afficher();

                    quitarReina(j, i);
                }
            }
        }

        static void Main(string[] args)
        {
            inicializar();

            tester(0);

            Console.ReadKey();
        }
    }
}
