using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterMindLogic
{
    public class Basic
    {
        private string solution;

        public int DigitsPerNumber { get; private set; }
        public string DisplayMinNumber => FormatNumber(0);
        public string DisplayMaxNumber =>  FormatNumber(MaxNumber);

        public string DisplayCorrectPlace => @"✔️ "; //☀️🌤️ ✔️❌️ ❗️❓️ ");
        public string DisplayCorrectDigit => @"❌️";

        public int MaxNumber => (int)(Math.Pow(10, DigitsPerNumber)-1);

        public string Solution { get => solution; private set => solution = value; }
        public Basic(int digits = 3)
        {
            if (digits > 9 || digits < 1) 
                throw new ArgumentOutOfRangeException();
            DigitsPerNumber = digits;
            Solution = GetSolution();
        }

        public string FormatNumber(int number)
        {
            return number.ToString($"D{DigitsPerNumber}");
        }    
        private string GetSolution()
        {
            var rnd = new Random();
            return FormatNumber(rnd.Next(MaxNumber+1));
        }

        static void ClearLine(){
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth)); 
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        public bool GetGuess(int round) 
        {
            string linePrefix = $"Runde {round.ToString().PadLeft(3)}: "; 
            string guess;
            do
            {
                Console.Write(linePrefix);
                guess = Console.ReadLine();

                if(!int.TryParse(guess, out int guessedNumber) || guess.Length != DigitsPerNumber)
                {
                    guess = null;
                    Console.WriteLine("ungültige Eingabe");
                    Task.Delay(1000).Wait();
                    Console.CursorTop--;
                    ClearLine();
                    //Console.Write("\r" + new string(' ', Console.WindowWidth-1) + "\r");
                    Console.CursorTop --;
                    ClearLine();
                }
            }
            while(guess == null);

            var eval = EvaluateNumber(Solution, guess);
            Console.CursorTop--;
            Console.Write($"{linePrefix}{guess} ");
            
            for(var p = 0; p < eval.Places; p++)
            {
                Console.Write($"{DisplayCorrectPlace} ");
            }
            for(var d = 0; d < eval.Digits; d++)
            {
                Console.Write($"{DisplayCorrectDigit} ");      
            }
            System.Console.WriteLine();
            if(eval.Places == DigitsPerNumber)
                return true;
            return false;
        }

        public (int Places, int Digits) EvaluateNumber(string solution, string guess)
        {
            var result = (Places: 0, Digits: 0);

            List<char> unmatchedSolution = new List<char>(solution.ToCharArray()); 
            List<char> unmatchedGuess = new List<char>(guess.ToCharArray()); 
 
            // alle Places finden
            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == solution[i])
                {
                    result.Places++;
                    unmatchedSolution.Remove(solution[i]);
                    unmatchedGuess.Remove(solution[i]);
                }
            }

            // alle Digits finden
            while (unmatchedGuess.Count > 0)
            {                    
                if (unmatchedSolution.Contains(unmatchedGuess[0]))
                {
                    result.Digits++;
                    
                    unmatchedSolution.Remove(unmatchedGuess[0]);
                }
                unmatchedGuess.Remove(unmatchedGuess[0]);
            }

            return result;
        }

        public string[] GetCandidates()
        {
            var candidates = new string[(int)Math.Pow(10, DigitsPerNumber)];

            for (int i = 0; i < candidates.Length; i++)
            {
                candidates[i] = i.ToString($"D{DigitsPerNumber}");
            }

            System.Console.WriteLine($"Teste Zahlen von {candidates[0]}-{candidates[^1]}");
            return candidates;
        }

        [Obsolete]
        public bool CheckZahl(string toCheck, (string Zahl, int Stelle, int Ziffer) vorgabe)
        {
            var result = (Zahl: toCheck, Stelle: 0, Ziffer: 0);


            //check STelle
            for (int i = 0; i < vorgabe.Zahl.Length; i++)
            {
                if (vorgabe.Zahl[i] == toCheck[i])
                    result.Stelle++;
                else if (toCheck.Contains(vorgabe.Zahl[i].ToString()))
                    result.Ziffer++;
            }


            bool ret = result.Stelle == vorgabe.Stelle && result.Ziffer == vorgabe.Ziffer;
            return ret;
        }
    }
}
