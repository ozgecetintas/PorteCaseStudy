namespace PorteCaseStudy.Common
{
    public static class PartCostHelper
    {
        public static int CalculatePartCost(int partCount, int partWeight)
        {
            return 50 + (partWeight * 7);
        }
    }
}
