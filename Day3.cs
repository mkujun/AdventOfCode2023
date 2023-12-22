using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 140x140 (real), 10x10 (test)

namespace Aoc
{
    public class Day3
    {
        string input = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\input.txt"));
        //string input = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\3.txt"));

        List<char[]> matrix = new List<char[]>();
        static int rows = 10;
        static int columns = 10;

        public void ConvertInputToMatrix()
        {
            foreach (string line in File.ReadLines(@input))
            {
                char[] chars = line.ToCharArray();
                matrix.Add(chars);
            }
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i][j]);
                }
            }
        }

        public void ReadMatrix()
        {
            for(int i = 0;i < rows; i++)
            {
                string rowNumber = "";
                bool currentNumber = false;

                for(int j  = 0; j < columns; j++)
                {
                    char element = matrix[i][j];
                    if (Char.IsDigit(element))
                    {
                        if (!currentNumber)
                        {
                            currentNumber = true;
                        }
                        rowNumber = rowNumber + element;
                    }
                    else
                    {
                        if (rowNumber != "")
                        {
                            int jEnd = j - 1;
                            int jBegin = j - rowNumber.Length;

                            CheckAroundNumber(i, jBegin, jEnd, rowNumber);
                        }

                        currentNumber = false;
                        rowNumber = "";
                    }
                }
            }
        }

        // TODO: finish this one...
        public void CheckAroundNumber(int i, int jBegin, int jEnd, string rowNumber)
        {
            try
            {
                // look up, left, down and right for entire number index...

            }
            catch (IndexOutOfRangeException ex)
            {

            }
        }

        public Day3()
        {
            ConvertInputToMatrix();
            //PrintMatrix();
            ReadMatrix();
        }
    }
}
