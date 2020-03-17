using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsexplorer.Resources
{
    public class Map
    {
        public List<Axis> Axes;
        int xndx = 0;
        Coordinates p1;
        public Map(int x, int y)
        {
            //initialize
            Axes = new List<Axis>();
            p1 = new Coordinates() { x = x, y = y };
            var ver = new Axis() { X = x };
            ver.Ranges.Add(new Range() { Min = y, Max = y });
            Axes.Add(ver);
        }

        public Coordinates Read(Move move)
        {
            Coordinates ncpos = new Coordinates();
            switch (move.direction)
            {
                case Robot.Direction.North:
                    {
                        ncpos.x = p1.x;
                        ncpos.y = p1.y + move.steps;
                    }
                    break;
                case Robot.Direction.East:
                    {
                        ncpos.y = p1.y;
                        ncpos.x = p1.x + move.steps;
                    }
                    break;
                case Robot.Direction.West:
                    {
                        ncpos.y = p1.y;
                        ncpos.x = p1.x - move.steps;
                    }
                    break;
                case Robot.Direction.South:
                    {
                        ncpos.x = p1.x;
                        ncpos.y = p1.y - move.steps;
                    }
                    break;
            }
            AddCoordinate(ncpos);
            return ncpos;
        }

        public int Explored()
        {
            return this.Axes.Select(s => s.Ranges.Explored()).Sum();
        }

        public void AddCoordinate(Coordinates p2)
        {
            //move in x axis
            if (p1.y == p2.y)
            {
                if (p1.x < p2.x) //East
                {
                    for (int i = p1.x + 1; i <= p2.x; i++)
                    {
                        if (xndx == (Axes.Count - 1))
                        {
                            var naxis = new Axis() { X = i };
                            naxis.Store(p1.y, p2.y);
                            Axes.Add(naxis);
                        }
                        else
                        {
                            Axes[xndx + 1].Store(p1.y, p2.y);
                        }
                        xndx++;
                    }
                    this.p1 = new Coordinates() { x = p2.x, y = p2.y };
                    return;
                }

                if (p1.x > p2.x)//West
                {
                    for (int i = p1.x - 1; i >= p2.x; i--)
                    {
                        if (xndx == 0)
                        {
                            var naxis = new Axis() { X = i };
                            naxis.Store(p1.y, p2.y);
                            Axes.Insert(0, naxis);
                            continue;
                        }
                        else
                        {
                            Axes[xndx - 1].Store(p1.y, p2.y);
                        }
                        xndx--;
                    }
                    this.p1 = new Coordinates() { x = p2.x, y = p2.y };
                    return;
                }
            }

            //move in y axis
            if (p1.x == p2.x)
            {
                Axes[xndx].Store(p1.y, p2.y);
                this.p1 = new Coordinates() { x = p2.x, y = p2.y };
                return;
            }
        }
    }
}
