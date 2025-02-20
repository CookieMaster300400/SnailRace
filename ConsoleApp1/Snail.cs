namespace ConsoleApp1
{
    class Snail
    {
        Random speed = new();
        public static List<string[]> snailBody = new();
        public static List<int> snailsSpeed = new();
        public static List<int> snailStep = new();
        public Snail(int numberOnShell)
        {
            snailBody.Add(new string[] { "  ___   0 0", $" /{numberOnShell}  \\ / /", "CCCCCCCCO"});
            snailsSpeed.Add(speed.Next(1, 6));
            snailStep.Add(0);
        }
        public static void ShowSnails()
        {
            for (int i = 0; i < snailBody.Count; i++)
            {
                Console.WriteLine($"{snailBody[i][0]}\n{snailBody[i][1]}\n{snailBody[i][2]}\n\t\t\t\t\t\t\t\t{snailStep[i]}cm\n___________________________________________________________________________________________________________________________");
            }
        }
    }
}
