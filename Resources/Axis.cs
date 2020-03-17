
namespace Marsexplorer.Resources
{
    public class Coordinates
    {
        public int x;
        public int y;
    }

    public class Axis
    {
        public int X;
        public Ranges Ranges;
        public void Store(int y1, int y2)
        {
            Ranges.Store(y1, y2);
        }

        public override string ToString()
        {
            return $"{X}";
        }

        public Axis()
        {
            Ranges = new Ranges();
        }
    }
}
