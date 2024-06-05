namespace Constructor.DTO
{
    public class StaticsDTO
    {
        public int TotalCount { get; set; }
        public int ProblemCount { get; set; }

        public Dictionary<string, int> GoodSales { get; set; } = new Dictionary<string, int>();
    }
}
