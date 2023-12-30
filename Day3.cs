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
        //string input = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\input.txt"));
        string input = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\3.txt"));

        List<char[]> matrix = new List<char[]>();

        static int rows = 140;
        static int columns = 140;

        /*
        static int rows = 10;
        static int columns = 10;
        */

        List<int> part1 = new List<int>();

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

                        // last number in a row scenario
                        if (j == columns - 1 && currentNumber)
                        {
                            int jEnd = j;
                            int jBegin = j - rowNumber.Length + 1;

                            CheckAroundNumber(i, jBegin, jEnd, rowNumber);
                            currentNumber = false;
                            rowNumber = "";
                        }
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

        static bool AreAllCharsSame(List<char> charList, char targetChar)
        {
            // Check if every character is the same as the target character.
            foreach (char c in charList)
            {
                if (c != targetChar)
                {
                    return false;
                }
            }

            return true;
        }

        public void CheckAroundNumber(int i, int jBegin, int jEnd, string rowNumber)
        {
            if (i == 13 && rowNumber == "738")
            {

            }
            // above
            List<char> rowAbove = new List<char>();

            for(int k = jBegin - 1; k <= jEnd + 1; k++)
            {
                try
                {
                    rowAbove.Add(matrix[i - 1][k]);
                }
                catch (Exception ex)
                {

                }
            }

            // current
            List<char> rowCurrent = new List<char>();

            for(int k = jBegin - 1; k <= jEnd + 1; k = k + rowNumber.Length + 1)
            {
                try
                {
                    rowCurrent.Add(matrix[i][k]);
                }
                catch (Exception ex)
                {

                }
            }

            // bellow
            List<char> rowBellow = new List<char>();

            for(int k = jBegin - 1; k <= jEnd + 1; k++)
            {
                try
                {
                    rowBellow.Add(matrix[i + 1][k]);
                }
                catch (Exception ex)
                {

                }
            }

            if (!AreAllCharsSame(rowAbove, '.') || !AreAllCharsSame(rowCurrent, '.') || !AreAllCharsSame(rowBellow, '.'))
            {
                part1.Add(Int32.Parse(rowNumber));
            }
        }

        public Day3()
        {
            ConvertInputToMatrix();
            //PrintMatrix();
            ReadMatrix();

            Console.WriteLine(part1.Sum());
        }
    }
}
