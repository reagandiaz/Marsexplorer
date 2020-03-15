using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Marsexplorer.Resources;

namespace Marsexplorer
{
    public class Robot
    {
        readonly Map map;
        Coordinates ipos;
        Coordinates cpos;
        public Coordinates Current => cpos;
        public Coordinates Initial => ipos;

        public int ExploredAreaCount => map.AreaExplored;

        public Robot()
        {
            map = new Map();
        }

        public enum Direction
        {
            North,
            South,
            East,
            West
        }

        public int ExecuteFromFile(string filepath)
        {
            FileInfo fi = new FileInfo(filepath);
            StringBuilder str = new StringBuilder();
            using (StreamReader reader = fi.OpenText())
            {
                string strmovecnt = reader.ReadLine();
                str.AppendLine(strmovecnt);
                str.AppendLine(reader.ReadLine());
                var movecount = Convert.ToInt32(strmovecnt);
                for (int i = 0; i < movecount; i++)
                    str.AppendLine(reader.ReadLine());
                reader.Close();
            }
            return Execute(str.ToString().Split(System.Environment.NewLine));
        }

        public int Execute(string[] instruction)
        {
            var movecount = Convert.ToInt32(instruction[0]);
            var strpos = instruction[1].Split(' ');

            ipos = new Coordinates() { x = Convert.ToInt32(strpos[0]), y = Convert.ToInt32(strpos[1]) };
            cpos = new Coordinates() { x = ipos.x, y = ipos.y };

            map.axes = new List<Axis>() { new Axis() { axis = cpos.x, Blocks = new List<Block>() { new Block() { Min = cpos.y, Height = 0 } } } };
            map.laxis = map.axes.First();

            for (int i = 0; i < movecount; i++)
            {
                var strmove = instruction[2 + i].Split(' ');
                var movement = new Move() { steps = Convert.ToInt32(strmove[1]) };
                switch (Convert.ToChar(strmove[0]))
                {
                    case 'N':
                        movement.direction = Robot.Direction.North;
                        break;
                    case 'E':
                        movement.direction = Robot.Direction.East;
                        break;
                    case 'W':
                        movement.direction = Robot.Direction.West;
                        break;
                    case 'S':
                        movement.direction = Robot.Direction.South;
                        break;
                }
                map.Load(cpos, movement);
            }
            return map.AreaExplored;
        }
    }
}