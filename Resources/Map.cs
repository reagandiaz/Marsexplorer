using System.Collections.Generic;
using System.Linq;

namespace Marsexplorer.Resources
{
    public class Map
    {
        public Map()
        {

        }
        public int AreaExplored
        {
            get
            {
                int cnt = 0;
                axes.ForEach(s =>
                {
                    s.Blocks.ForEach(b =>
                    {
                        cnt += (b.Height + 1);
                    });
                });
                return cnt;
            }
        }

        public List<Axis> axes;

        public Axis laxis;

        public void Load(Coordinates current, Move movement)
        {
            Coordinates newcoordinates = new Coordinates();
            switch (movement.direction)
            {
                case Robot.Direction.East:
                    EastWest(current, movement, (int x) => { return x + 1; }, Robot.Direction.East);
                    break;
                case Robot.Direction.West:
                    EastWest(current, movement, (int x) => { return x - 1; }, Robot.Direction.West);
                    break;
                case Robot.Direction.North:
                    {
                        //check if already in the block
                        ResolveBlock(laxis, current.y, movement.steps);
                        current.y = current.y + movement.steps;
                    }
                    break;
                case Robot.Direction.South:
                    {
                        //check if already in the block
                        ResolveBlock(laxis, current.y - movement.steps, movement.steps);
                        current.y = current.y - movement.steps;
                    }
                    break;
            }
        }

        public delegate int GetRangeCallBack(int y, int steps);

        public delegate int GetAxisCallBack(int currentx);

        public void EastWest(Coordinates current, Move movement, GetAxisCallBack getaxis, Robot.Direction dir)
        {
            //check if next axis exists
            for (int i = 0; i < movement.steps; i++)
            {
                //check if next axis exists
                var nextaxis = axes.SingleOrDefault(s => s.axis == (getaxis(current.x)));
                if (nextaxis == null)
                {
                    //new block
                    nextaxis = new Axis() { axis = (getaxis(current.x)), Blocks = new List<Block>() { new Block() { Min = current.y, Height = 0 } } };
                    //ordered
                    if (axes[axes.Count - 1].axis < nextaxis.axis)
                        axes.Add(nextaxis);
                    else
                        axes.Insert(0, nextaxis);
                }
                else
                {
                    //create block in the existing axis if not defined
                    ResolveBlock(nextaxis, current.y, 0);
                }
                laxis = nextaxis;
                current.x = getaxis(current.x);
            }
        }

        public void ResolveBlock(Axis nextaxis, int ycur, int height)
        {
            var minblock = nextaxis.Blocks.FirstOrDefault(s => s.InRange(ycur));
            var maxblock = nextaxis.Blocks.FirstOrDefault(s => s.InRange(ycur + height));

            //not bound in any block
            if (minblock == null && maxblock == null)
            {
                var nblock = new Block() { Min = ycur, Height = height };

                if (nextaxis.Blocks[nextaxis.Blocks.Count - 1].Min < nblock.Min)
                    nextaxis.Blocks.Add(nblock);
                else
                    nextaxis.Blocks.Insert(0, nblock);
                return;
            }

            //increase the height of existing
            if (minblock != null && maxblock == null)
            {
                minblock.Height = (ycur + height) - minblock.Min;
                return;
            }

            //decrease the bounds
            if (minblock == null && maxblock != null)
            {
                maxblock.Min = ycur;
                maxblock.Height = maxblock.Height + height;
                return;
            }

            //merge
            if (minblock != maxblock)
            {
                //increased the height
                minblock.Height = (maxblock.Min + maxblock.Height) - minblock.Min;
                return;
            }

            //just moving sideways
        }
    }
}
