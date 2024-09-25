using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static Random rnd = new Random();
        static List<int> list = new List<int>();
        static int[] defaultArray = new int[15];
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                DisplayBoard(defaultArray, 5);

                Console.WriteLine("[1] Draw \t[2] End");
                Console.Write("\nChoose an option: ");

                if (OptionSelect())
                {
                    
                    
                }
                else
                {
                    continue; 
                }
                
               
            }
            
        }

        static bool OptionSelect()
        {        
           int userInput = int.Parse(Console.ReadLine());

           if (userInput == 1 || userInput == 2)
           {
                return true;
           }
           else
           {
                Console.WriteLine("\nAn error has occurred, please try inputting a valid value");
                Console.ReadKey();
                return false;
           }
        }

        static void DisplayBoard(int[] array, int num) // Display
        {
            int[] values = array;
            string bingoDisplay = "BINGO";
            int count = 0;

            while (num > 0)
            {
                values = GenerateValues(array, num);

                Console.Write(bingoDisplay[count] + "\t-\t");

                foreach (int i in values)
                {
                    Console.Write(i + "\t");
                }
                Console.WriteLine("\n");
                num--;
                count++;
            }
            Console.WriteLine("\n");
        }

        static int[] GenerateValues(int[] array, int num) // Generating Values
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (num == 5)
                    array[i] = i + 1;
                else
                    array[i] += 15;
            }
            return array;
        }

        
    }
}
