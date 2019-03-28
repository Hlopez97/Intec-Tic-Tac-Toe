using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            int game = 1;
            while (game == 1)
            {
                Console.WriteLine("* Este es un juego de tic tac toe");
                Console.WriteLine("* Hecho por hector Lopez");
                Console.WriteLine("* el jugador 1 es O y el jugador 2 es X");
                int truth = 1;
                int[] Valores = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int cont = 0;
                int tie = 0;
                int win = 0;
                Console.WriteLine("* para jugar el jugador 1 mueve primero y luego el jugador 2, se ve en el juego");
                Console.WriteLine("* debe seleccionar una de 9 posiciones");
                Console.WriteLine("* estan escritas de esta forma");
                Console.WriteLine("");
                Console.WriteLine("123");
                Console.WriteLine("456");
                Console.WriteLine("789");
            
                int jcont = 2;
                while (truth == 1)
                {
                    

                    //condicion de empate
                    if (cont == 9) { tie = 1; break; }
                    //condiciones de ganada

                    for (int a = 0; a < 7; a++)
                    {
                        switch (a)
                        {
                            case 0:
                                // fila
                                if ( Program.cond(Valores[a],Valores[a+1],Valores[a+2]) )
                                {
                                    if (Valores[a] + Valores[a + 1] + Valores[a + 2] == 3) { win = 1; }
                                    else { win = 2; }
                                }
                                 // diagonal
                                if (Program.cond(Valores[a],Valores[4],Valores[8]))
                                {
                                    if (Valores[a] + Valores[4] + Valores[8] == 3) { win = 1; }
                                    else { win = 2; }
                                }

                                // columna
                                if (Program.cond(Valores[a],Valores[a+3],Valores[a+6]))
                                {
                                    if (Valores[a] + Valores[a+3] + Valores[a+6] == 3) { win = 1; }
                                    else { win = 2; }

                                }
                                break;
                            case 1:
                                //columna
                                if (Program.cond(Valores[a], Valores[a + 3], Valores[a + 6]))
                                {
                                    if (Valores[a] + Valores[a + 3] + Valores[a + 6] == 3) { win = 1; }
                                    else { win = 2; }

                                }
                                break;

                            case 2:

                                //diagonal
                                if (Program.cond(Valores[a], Valores[4], Valores[6]))
                                {
                                    if (Valores[a] + Valores[4] + Valores[6] == 3) { win = 1; }
                                    else { win = 2; }
                                }

                                //columna
                                if (Program.cond(Valores[a], Valores[a + 3], Valores[a + 6]))
                                {
                                    if (Valores[a] + Valores[a + 3] + Valores[a + 6] == 3) { win = 1; }
                                    else { win = 2; }

                                }
                                break;
                            case 3:
                                // fila
                                if (Program.cond(Valores[a], Valores[a + 1], Valores[a + 2]))
                                {
                                    if (Valores[a] + Valores[a + 1] + Valores[a + 2] == 3) { win = 1; }
                                    else { win = 2; }
                                }
                                break;
                            case 6:
                                // fila
                                if (Program.cond(Valores[a], Valores[a + 1], Valores[a + 2]))
                                {
                                    if (Valores[a] + Valores[a + 1] + Valores[a + 2] == 3) { win = 1; }
                                    else { win = 2; }
                                }
                                break;
                        }
                    }

                    //acabar juego si ganar
                    if (win != 0) { break; }

                    //seguir juego
                    //insertar numero del 1-9
                    int jugada;
                    string entrada;
                    int vcont = 0;
                    do
                    {
                        if (vcont > 0) { Console.WriteLine("\nhaz fallado!!! intenta denuevo!"); }
                        Console.WriteLine("\nEntre un numero del 1 al 9, jugador " + ((jcont % 2) + 1+"\n"));
                        entrada = Console.ReadLine();
                        bool verdad = int.TryParse(entrada, out jugada);
                        if (verdad) { if (jugada > 0 && jugada < 10) { break; } }
                        vcont++;
                    } while (true);



                    if (Valores[jugada-1] != 0)
                    {
                        Console.WriteLine("Intene denuevo, ha jugado en un lugar ya ocupado");
                        jcont++;
                    }
                    else
                    {
                        Valores[jugada - 1] = (jcont % 2) + 1;
                        List<String> Valores2 = new List<string> { };
                        for (int len= 0; len<9; len++)
                        {
                            if (Valores[len] == 0) { Valores2.Add(" "); }
                            else if (Valores[len] == 1) { Valores2.Add("O"); }
                            else { Valores2.Add("X"); }
                        }
                        Program.skele(Valores2[0], Valores2[1], Valores2[2], Valores2[3], Valores2[4], Valores2[5], Valores2[6], Valores2[7], Valores2[8]);
                        
                    }
                    jcont++;
                    cont++;
                }
                if (tie == 1) { Console.WriteLine("Es un empate :o"); }
                else if (win == 1) { Console.WriteLine("gano el jugador 1!"); }
                else if (win == 2) { Console.WriteLine("gano el jugador 2!"); }
                Console.WriteLine("desea continua? presione 1, exit 0");
                game = Convert.ToInt32(Console.ReadLine());
                while (game != 1 && game != 0)
                {
                    Console.WriteLine("nope no vas a romper el juegom intente denuevo");
                    game = Convert.ToInt32(Console.ReadLine());
                }
            }
            
        }
        static bool cond(int a, int b, int c)
        {
            if (((a == b) && (a == c)) && ((a + b + c == 3) || (a + b + c == 6)))
            {
                return true;
            }
            else { return false; }
        }
        static void skele(string a, string b, string c, string d, string e, string f, string g, string h, string i)
        {
            Console.WriteLine("   " + "   " + "* " + " " + "   * " + " ");
            Console.WriteLine("   " + a + "  *  " + b + "  *  " + c);
            Console.WriteLine("      *     *");
            Console.WriteLine(" * * * * * * * * *");
            Console.WriteLine("      *     *");
            Console.WriteLine("   " + d + "  *  " + e + "  *  " + f);
            Console.WriteLine("      *     *");
            Console.WriteLine(" * * * * * * * * *");
            Console.WriteLine("      *     *");
            Console.WriteLine("   " + g + "  *  " + h + "  *  " + i);
            Console.WriteLine("   " + "   " + "* " + " " + "   * " + " ");
        }
    }
    
}
