namespace ConsoleApp1
{
    internal class Program
    {
        static int SnailNumber(int maxSnails, int minSnails)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Перед началом гонки откройте консоль полностью\nСколько улиток будут учавствовать в гонке? Минимум {minSnails} максимум {maxSnails}");
                int snailNumber = 0;
                if (int.TryParse(Console.ReadLine(), out snailNumber) && snailNumber >= minSnails && snailNumber <= maxSnails)
                    return snailNumber;
            }
        }
        static void CreateSnails(int snailNumber)
        {
            for(int i = 1; i <= snailNumber; i++)
            {
                Snail snail = new Snail(i);
            }
        }
        static void CountDown(string go, string one, string two, string three)
        {
            int count = 3;
            while(count > -1)
            {
                Console.Clear();
                Console.WriteLine(count == 3 ? three : count == 2 ? two : count == 1 ? one : go);
                --count;
                Thread.Sleep(1000);
            }
        }
        static List<string[]> Race(int finish)
        {
            while (true)
            {
                List<string[]> winner = new();
                for (int i = 0; i < Snail.snailBody.Count; i++)
                {
                    string spaces = new string(' ', Snail.snailsSpeed[i]);
                    Snail.snailBody[i][0] = spaces + Snail.snailBody[i][0];
                    Snail.snailBody[i][1] = spaces + Snail.snailBody[i][1];
                    Snail.snailBody[i][2] = spaces + Snail.snailBody[i][2];
                    Snail.snailStep[i] = Snail.snailStep[i] + Snail.snailsSpeed[i];
                    if (Snail.snailStep[i] >= finish)
                    {
                        winner.Add(new string[] { Snail.snailBody[i][0], Snail.snailBody[i][1], Snail.snailBody[i][2] });
                    }
                }
                if (Snail.snailStep.Any(steps => steps >= finish))
                {
                        return winner;
                }
                Console.Clear();
                Snail.ShowSnails();
                Thread.Sleep(500);
            }
        }
        static void ShowWinner(List<string[]> winner, int finish)
        {
            Console.Clear();
            for (int i = 0; i < winner.Count; i++)
            {
                Console.WriteLine($"{winner[i][0].Substring(finish)}\n{winner[i][1].Substring(finish)}\n{winner[i][2].Substring(finish)}\n  Won");
            }
        }
        static void Main(string[] args)
        {
            const string Go = "\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\tGGGGG\t    OOOOO\n\t\t\t\t\t      GG     GG\t  OO     OO\n\t\t\t\t\t      GG     GG\t  OO     OO\n\t\t\t\t\t      GG\t  OO     OO\n\t\t\t\t\t      GG\t  OO     OO\n\t\t\t\t\t      GG   GGGG   OO     OO\n\t\t\t\t\t      GG     GG   OO     OO\n\t\t\t\t\t\tGGGGG\t    OOOOO";
            const string One = "\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t1\n\t\t\t\t\t\t\t      1 1\n\t\t\t\t\t\t\t    1   1\n\t\t\t\t\t\t\t  1     1\n\t\t\t\t\t\t\t\t1\n\t\t\t\t\t\t\t\t1\n\t\t\t\t\t\t\t\t1\n\t\t\t\t\t\t\t\t1";
            const string Two = "\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t22222\n\t\t\t\t\t\t       2     2\n\t\t\t\t\t\t\t     2\n\t\t\t\t\t\t\t    2\n\t\t\t\t\t\t\t   2\n\t\t\t\t\t\t\t  2\n\t\t\t\t\t\t\t 2\n\t\t\t\t\t\t\t2\n\t\t\t\t\t\t       222222222";
            const string Three = "\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t33333\n\t\t\t\t\t\t       3     3\n\t\t\t\t\t\t\t     3\n\t\t\t\t\t\t\t     3\n\t\t\t\t\t\t\t   3\n\t\t\t\t\t\t\t     3\n\t\t\t\t\t\t\t     3\n\t\t\t\t\t\t       3     3\n\t\t\t\t\t\t\t33333";
            const int MaxSnails = 6;
            const int MinSnails = 2;
            const int Finish = 120;
            int snailNumber = SnailNumber(MaxSnails, MinSnails);
            CreateSnails(snailNumber);
            CountDown(Go, One, Two, Three);
            List<string[]> winner = Race(Finish);
            ShowWinner(winner, Finish);
        }
    }
}
