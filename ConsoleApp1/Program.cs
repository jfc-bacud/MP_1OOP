using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        static List<int> defaultValues = new List<int>();
        static List<int> recordedValues = new List<int>();
        static int[] defaultArray = new int[15];

        static void Main(string[] args)
        {
            int choice = 0;
            GenerateValues();

            while (true)
            {
                
                Console.Clear();
                DisplayBoard(defaultArray, 5, choice);
                
                Console.WriteLine("[1] Draw \t[2] End");
                Console.Write("\nChoose an option: ");

                if (OptionSelect(out choice))
                {
                    Operation(choice);
                    
                }
                else
                {
                    continue; 
                }
                
               
            }
            
        }

        static void GenerateValues()
        {
            for (int i = 1; i < 76; i++)
            {
                defaultValues.Add(i);
            }
        }
        // For Default List Generation

        static bool OptionSelect(out int choice)
        {        
           int userInput = int.Parse(Console.ReadLine());

           if (userInput == 1 || userInput == 2)
           {
                choice = userInput;
                return true;
           }
           else
           {
                Console.WriteLine("\nAn error has occurred, please try inputting a valid value");
                Console.ReadKey();
                choice = 0;
                return false;
           }
        }
        /// <summary>
        /// For user input
        /// </summary>
        /// <param name="choice"></param>

        static void Operation(int choice)
        {
            if (choice == 1)
            {
                Draw();
            }
            else
            {
                End();
            }

        }

        static void Draw()
        {
            while (true)
            {
                int randomNum = rnd.Next(1, 76);

                if (!recordedValues.Contains(randomNum))
                {
                    recordedValues.Add(randomNum);
                    Console.WriteLine($"Player has drew {randomNum}");
                    Console.ReadKey();
                    break;
                }
            }
            
        }

        static void End()
        {

        }






        static void DisplayBoard(int[] array, int num, int choice)
        {
            int[] values = array;
            string bingoDisplay = "BINGO";
            int count = 0;
            int tempChoice = choice;

            if (tempChoice == 0 || tempChoice == 2)
            {
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
            else if (tempChoice == 1)
            {
                while (num > 0)
                {
                    values = GenerateValues(array, num);

                    foreach (int i in values)
                    {
                        if (recordedValues.Contains(i))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(i + "\t");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(i + "\t");
                        }
                    }
                    Console.WriteLine("\n");
                    num--;
                }
            }     
        }
        /// <summary>
        /// Displaying Values for Default Board
        /// </summary>
        /// <param name="array"></param>
        /// <param name="num"></param>
        /// <returns></returns>

        static int[] GenerateValues(int[] array, int num) 
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
        /// <summary>
        /// Generating Values for Default Board
        /// </summary>
        /// 

        static void GenrateValues()
        {
            for (int i = 1; i < 76; i++)
            {
                defaultValues.Add(i);
            }
        }

        
        
    }
}
