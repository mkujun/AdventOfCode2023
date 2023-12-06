using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Aoc
{
    public class Day2
    {
        string input = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\2.txt"));

        public Day2()
        {
            int partOne = 0;

            foreach (string line in File.ReadLines(@input))
            {
                bool gameValid = true;
                //Console.WriteLine(line);

                string game = line.Split(':')[0];
                int gameNo = Int32.Parse(game.Split(' ')[1]);

                var sets = line.Split(':')[1];
                string[] setList = sets.Split(";");

                int redMax = 0;
                int greenMax = 0;
                int blueMax = 0;

                foreach (var set in setList)
                {
                    string[] rgb = set.Split(",");

                    int red = 0;
                    int blue = 0;
                    int green = 0;

                    foreach (var color in rgb)
                    {
                        if (color.Contains("red"))
                        {
                            red = Int32.Parse(string.Join("", color.ToCharArray().Where(Char.IsDigit)));
                        }
                        else if (color.Contains("blue"))
                        {
                            blue = Int32.Parse(string.Join("", color.ToCharArray().Where(Char.IsDigit)));
                        }
                        else if (color.Contains("green"))
                        {
                            green = Int32.Parse(string.Join("", color.ToCharArray().Where(Char.IsDigit)));
                        }
                    }
                    
                    
                    if (red > 12)
                    {
                        gameValid = false;
                    }
                    if (green > 13)
                    {
                        gameValid = false;
                    }
                    if (blue > 14)
                    {
                        gameValid = false;
                    }


                }


                if (gameValid)
                {
                    //Console.WriteLine("Game  valid");
                    //Console.WriteLine("Game no", gameNo);
                    partOne = partOne + gameNo;
                }
            }

            Console.WriteLine(partOne);
        }
    }
}
