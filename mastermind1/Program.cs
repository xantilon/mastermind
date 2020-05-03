using System;
using System.Collections.Generic;
using System.Text;
using MasterMindLogic;

namespace mastermind1
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            Console.WriteLine("MASTERMIND 1");


            /* fixed example */
            var mm = new Basic(3);
            
            var given = new List<(int Zahl, int Stelle, int Ziffer)> {
                            (682,1,0),
                            (614,0,1),
                            (206,0,2),
                            (738,0,0),
                            (870,0,1)
                        };


            var candidates = mm.GetCandidates();

            bool found = false;
            var founds = new StringBuilder("gefundene Lösung(en): ");

            foreach (var check in candidates)
            {
                System.Console.Write($"{check}:");
                found = true;
                foreach (var give in given)
                {
                    System.Console.Write(".");
                    if((give.Stelle, give.Ziffer)!= mm.EvaluateNumber(check, give.Zahl.ToString($"D{mm.DigitsPerNumber}")))
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    founds.Append($"{check} ");
                    System.Console.WriteLine($"found: {check}");
                }
                else    
                    System.Console.WriteLine("");

            }

            System.Console.WriteLine( founds.ToString() );
        }


        
    }
}

