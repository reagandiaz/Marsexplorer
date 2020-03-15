
namespace Marsexplorer.Resources
{
    public class Block
    {
        public int Min;
        public int Height;
        public bool InRange(int num)
        {
            return Min <= num && num <= (Min + Height);
        }
    }
}
