namespace Lab5.Core.Services
{
    public class Lab2Service
    {
        public long CalculateMoves(char direction, int parameter, string[] rules)
        {
            // Логіка з Lab2
            Dictionary<char, int> directions = new()
            {
                { 'N', 0 }, { 'S', 1 }, { 'W', 2 }, 
                { 'E', 3 }, { 'U', 4 }, { 'D', 5 }
            };

            return DoMoves(direction, parameter, rules, directions);
        }

        private long DoMoves(char dir, int param, string[] rules, Dictionary<char, int> directions)
        {
            if (param == 1) return 1;

            long totalMoves = 1;
            string rule = rules[directions[dir]];

            foreach (char subDir in rule)
            {
                totalMoves += DoMoves(subDir, param - 1, rules, directions);
            }

            return totalMoves;
        }
    }
}