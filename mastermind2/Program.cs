using System;
using MasterMindLogic;

namespace mastermind2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int toWin = 100;
            const int digits = 5;

            
            var mm = new Basic(digits);

            Greet(mm, toWin);

            int round = 0;
            bool wehaveawinner = false;
            while (round <= toWin && !wehaveawinner)
            {
                round++;
                // Console.Write($"Runde {round:D3}: ");
                // var guess = Console.ReadLine();

                // if(!int.TryParse(guess, out int guessedNumber) || guess.Length != mm.DigitsPerNumber)
                // {
                //     Console.WriteLine("ungültige Eingabe");
                //     round--;
                //     continue;
                // }

                wehaveawinner = mm.GetGuess(round);
            }

            if(wehaveawinner)
                Winner(round);
            else
                Loser();
        }



        public static void Greet(MasterMindLogic.Basic mm, int tries) => Console.WriteLine($@"
MASTER MIND GAME
================

Rate meine {mm.DigitsPerNumber}-stellige Zahl zwischen {mm.DisplayMinNumber} und {mm.DisplayMaxNumber}. 
Du gewinnst, wenn du es in {tries} Versuchen schaffst.

Legende:
{mm.DisplayCorrectPlace} = korrekte Ziffer, an korrekter Stelle
{mm.DisplayCorrectDigit} = korrekte Ziffer, aber an falscher Stelle


Deine erste Zahl?
");

        public static void Winner(int tries) => Console.WriteLine($@"

 Super!! Du hast die Lösung in {tries} Versuchen erraten. Kannst du es noch schneller?           
 ");

        public static void Loser() => Console.WriteLine($@"

 Leider verloren! Du hast meine Geheimzahl nicht erraten! Mehr Glück beim nächsten mal.            
 ");
    }
}
