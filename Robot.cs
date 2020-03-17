using System;
using System.IO;
using System.Text;
using Marsexplorer.Resources;

namespace Marsexplorer
{
    public class Robot
    {
        Map map;
        public int ExploredAreaCount => map.Explored();

        public Robot()
        {

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
            //initialize map
            map = new Map(Convert.ToInt32(strpos[0]), Convert.ToInt32(strpos[1]));
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
                map.Read(movement);
            }
            return map.Explored();
        }
    }
}