namespace IronFoundry.Utilities
{
    public static class Constants
    {
        private static readonly int[] MemoryLimitsField = new int[6] { 64, 128, 256, 512, 1024, 2048 };

        public static int[] MemoryLimits { get { return MemoryLimitsField; } }
    }
}
