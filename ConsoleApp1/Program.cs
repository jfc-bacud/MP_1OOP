using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static Random rnd = new Random();
        static List<int> recordedValues = new List<int>();
        static List<string> recordedStrings = new List<string>();
        static int[] defaultArray = new int[15];

        static void Main(string[] args)
        {
            int choice = 0;

            while (true)
            {
                Console.Clear();

                DisplayBoard(defaultArray, 5);

                Console.WriteLine("[1] Draw \t[2] End");

                if (ValidOptionSelect(out choice))
                {
                    if (ValidOption(choice, out choice))
                    {
                        Operation(choice);
                    }
                }               
            }

        }

        #region USER INPUT METHODS

        /// <summary>
        /// INITIAL USER INPUT, RETURNS TRUE OR FALSE IF INPUT IS VALUD AND OUTS VALUE OF USER INPUT IF VALID, IN THE CASE WHERE IT IS NOT, OUTS 0
        /// </summary>
        /// <param name="choice"></param>
        /// <returns></returns>
        static bool ValidOptionSelect(out int choice)
        {
            try
            {
                Console.Write("\nChoose an option: ");
                int userInput = int.Parse(Console.ReadLine());
                choice = userInput;
                return true;
            }
            catch
            {
                Console.WriteLine("\nAn error has occured, please input a valid value");
                Console.WriteLine("Input any key to continue...");
                Console.ReadKey();
                choice = 0;
                return false;
            }
        }
        
        /// <summary>
        /// CHECKS IF USER INPUT OUTPUTTED BY PREVIOUS METHOD IS VALID IN THE CURRENT CONTEXT OF THE PROGRAM (OPERATIONS), OUTS 0 IF NOT VALID
        /// </summary>
        /// <param name="userInput"></param>
        /// <param name="choice"></param>
        /// <returns></returns>
        static bool ValidOption(int userInput, out int choice)
        {
            if (userInput == 1 || userInput == 2)
            {
                choice = userInput;
                return true;
            }
            else
            {
                Console.WriteLine("\nAn error has occured, please input a valid value");
                Console.WriteLine("Input any key to continue...");
                Console.ReadKey();
                choice = 0;
                return false;
            }
        }
        #endregion


        /// <summary>
        /// ONCE USER INPUT IS VALIDATED, PROCEEDS TO A SPECIFIC OPERATION DEPENDING ON USER INPUT
        /// </summary>
        /// <param name="choice"></param>
        static void Operation(int choice)
        {
            if (choice == 1)
            {
                Draw();
            }
            else if (choice == 2)
            {
                End();
            }
        }
        
        /// <summary>
        /// PRIMARY METHOD RESPONSIBLE FOR DRAWING NUMBERS
        /// </summary>
        static void Draw()
        {
            while (true)
            {
                int randomNum = rnd.Next(1, 76);
                string recordedString = "";

                if (!recordedValues.Contains(randomNum))
                {
                    recordedValues.Add(randomNum);
                    Console.WriteLine($"\nPlayer has drew {GenerateLetters(randomNum, 5)}-{randomNum}");

                    recordedString = (GenerateLetters(randomNum, 5).ToString() + "-" + randomNum.ToString());
                    recordedStrings.Add(recordedString);

                    Console.ReadKey();
                    break;
                }
            }
        }
        

        #region END METHODS

        /// <summary>
        /// INITIAL END PROCESS, RESPONSIBLE FOR LISTING RECORDED NUMBERS AND END OPERATION PROMPT
        /// </summary>
        static void End()
        {
            int choice = 0;
            Console.Write("\nRecorded Numbers: ");

            foreach (string i in recordedStrings)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("\n\nWill you...\n\n[1] Continue [2] Reset Board?");
            
            if (ValidOptionSelect(out choice))
            {
                if (ValidOption(choice, out choice))
                {
                    EndOperation(choice);
                }
            }
        }
        
        /// <summary>
        /// ONCE USER INPUT IS VALIDATED IN END PROCESS, PROCEED TO A SPECIFIC OPERATION DEPENDING ON THE VALUE OF CHOICE
        /// </summary>
        /// <param name="choice"></param>
        static void EndOperation(int choice)
        {
            if (choice == 1)
            {
                Console.WriteLine("\nContinuing current progress, input any key to continue...");
                Console.ReadKey();
            }
            else if (choice == 2)
            {
                ResetBoard();
            }
        }
        
        /// <summary>
        /// METHOD RESPONSIBLE FOR RESETTING THE BOARD
        /// </summary>
        static void ResetBoard()
        {
            recordedValues.Clear();
            recordedStrings.Clear();
            Console.WriteLine("\nBoard has been reset, input any key to continue...");
            Console.ReadKey();
        }
        
        #endregion


        /// <summary>
        /// PRIMARY METHOD RESPONSIBLE FOR DISPLAYING THE BINGO BOARD, AND ANY CHANGES WITHIN
        /// </summary>
        /// <param name="array"></param>
        /// <param name="num"></param>
        static void DisplayBoard(int[] array, int num)
        {
            int[] values = array;
            int count = 0;
            string bingoPlaceholder = "BINGO";

            Console.WriteLine("\n");

            while (num > 0)
            {
                values = GenerateValues(array, num);
                Console.Write($"   {bingoPlaceholder[count]}\t-\t");

                foreach (int i in values)
                {
                    if (recordedValues.Contains(i))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(i + "\t");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(i + "\t");
                    }
                }
                Console.WriteLine("\n");
                num--;
                count++;
            }
            Console.WriteLine("\n");
        }
        

        /// <summary>
        /// METHOD RESPONSIBLE FOR GENERATING THE NUMBERS FOR THE BINGO BOARD
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
        /// METHOD RESPONSIBLE FOR GENERATING LETTERS THAT WILL BE USED FOR RECORDING OF OUTPUTS
        /// </summary>
        /// <param name="randomNum"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        static char GenerateLetters(int randomNum, int num)
        {
            string bingoPlaceholder = "BINGO";
            int tempNum = 0;
            int count = 0;

            while (num > 0)
            {
                for (int i = 0; i < 15; i++)
                {
                    tempNum++;
                    if (tempNum == randomNum)
                    {
                        break;
                    }                    
                }

                if (tempNum == randomNum)
                {
                    break;
                }

                num--;
                count++;
            }
            return bingoPlaceholder[count];
        }
        
    }
}
        

