using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// Theory and facts
// Question 1: The stack works like a stack of plates. When a call is made in the stack, you can view the situation like a new plate being added to the stack of plates.
//             When the program finishes executing one method call, that plate is removed off of the stack. The heap is different and more like a spread-out assortment
//             of things laying around. Any "garbage" needs to be collected off of the heap because otherwise it will just remain laying there, taking up space.
//             C#'s garbage collection does this for you.
// Question 2: Value types are simple types that are stored in memory as values and are stored wherever they are declared; either on the stack when in methods or on 
//             the heap if they are declared in a class. These are included in System.ValueType. Reference types are stored as a reference to another location in memory 
//             instead and are the types that extend System.Object, or even are an instance of System.Object.object. A reference type is always stored on the heap.
// Question 3: The first method returns 3 because it is dealing with a value type. The variable x contains the value 3 (probably in two's complement notation) and 
//             setting y = x puts the value 3 inside of y. When y is then set to 4, x remains 3 which explains the return value of 3. The second metho9d uses a 
//             reference type; MyInt. Because it is a reference type, the y = new MyInt() declaration in ReturnValue2 creates a new MyInt and stores the address to this
//             new object into y. When y = x is called, the address stored in x is copied into y. The reference to the object just created is then lost. Then when 
//             y.MyValue is modified, this modifies the object that x also points to. That explains the different result.

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
           
            while (true)
            {

                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ReverseText();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        // Question 1: 
        // Question 2: The list's capacity increases when an element is being added when the list is at capacity.
        // Question 3: The capacity doubles each time it increases.
        // Question 4: The capacity doesn't increase at the same rate that items are added because increasing the capacity means that all
        //             items in the list have to be copied to a new one, which would take a lot of time if it was done each time an element 
        //             was added.
        // Question 5: The capacity does not reduce when elements are removed from the list.
        // Question 6: It is better to use an array directly when you know that you will be working with a constant, known number of 
        //             elements.
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}
            var words = new List<string>();
            var keepRunning = true;
            Console.WriteLine("This module investigates the List data structure. Write some text preceded by a + to add it to the list.");
            Console.WriteLine("For instance, writing '+Adam' will add 'Adam' to the list.");
            Console.WriteLine("Writing something preceded by a - will remove that item from the list if it is in the list.");
            Console.WriteLine("For instance, writing '-Adam' will remove 'Adam' from the list if that is in it.");
            Console.WriteLine("Write anything starting with anything else to quit this module.");
            while (keepRunning)
            {
                var input = Console.ReadLine();
                var choice = input[0];
                var value = input.Substring(1);
                switch (choice)
                {
                    case '+':
                        {
                            words.Add(value);
                            PrintListStatus(words);
                            break;
                        }
                    case '-':
                        {
                            words.Remove(value);
                            PrintListStatus(words);
                            break;
                        }
                    default:
                        Console.WriteLine("Are you sure you want to exit? The current list will be lost. To confirm, type 'Yes'");
                        if (Console.ReadLine().ToLower().StartsWith("y"))
                        {
                            keepRunning = false;
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// Helper method for ExamineList that prints list count and capacity.
        /// </summary>
        /// <param name="words"></param>
        private static void PrintListStatus(List<string> words)
        {
            Console.WriteLine($"Current list count: {words.Count}");
            Console.WriteLine($"Current list capacity: {words.Capacity}");
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            var line = new Queue<string>();
            var keepRunning = true;
            Console.WriteLine("This simulates a line of people at the register at a small grocery store.");
            Console.WriteLine("To add an individual, write 'enqueue' followed by the person's name in one word.");
            Console.WriteLine("To have someone be served , write 'dequeue'.");
            Console.WriteLine("The program will print the state of the queue after each command.");
            Console.WriteLine("To quit, enter anything starting with anything else.");
            Console.WriteLine("The store opens and the line is empty. Enter a command:");
            while (keepRunning)
            {
                var input = Console.ReadLine();
                var parts = input.Split();
                var option = parts[0];
                switch (option)
                {
                    case "enqueue":
                        line.Enqueue(parts[1]);
                        PrintQueueState(line);
                        break;
                    case "dequeue":
                        line.Dequeue();
                        PrintQueueState(line);
                        break;
                    default:
                        Console.WriteLine("Are you sure you want to exit? The current queue will be lost. To confirm, type 'Yes'");
                        if (Console.ReadLine().ToLower().StartsWith("y"))
                        {
                            keepRunning = false;
                        }
                        break;
                }
            }
        }

        private static void PrintQueueState(Queue<string> line)
        {
            Console.WriteLine($"Number of people in the line: {line.Count}");
            Console.WriteLine("The following people are in the line:");
            foreach (var item in line)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Demonstrates the datastructure Stack by taking text input from console, putting the non-whitespace characters onto a stack, then
        /// assembles a new string by popping characters off the stack
        /// </summary>
        // Question 1: For a situation like customers arriving at the register in a grocery store it is not suitable to use the stack
        //             structure because the first customer would be served last!
        static void ReverseText()
        {
            var textStack = new Stack<char>();
            PrintReverseTextInstructions();
            var text = Console.ReadLine();
            var words = text.Split();
            FillStack(textStack, words);

            var wordsOut = new string[words.Length];
            BuildReverseStringFromStack(textStack, words, wordsOut);
            Console.WriteLine(String.Join(separator: " ", wordsOut));
        }

        private static void PrintReverseTextInstructions()
        {
            Console.WriteLine("Reverses a text string using a stack data structure, then returns to main menu.");
            Console.WriteLine("Please enter some text:");
        }

        private static void FillStack(Stack<char> textStack, string[] words)
        {
            for (int n = 0; n < words.Length; n++)
            {
                foreach (var token in words[n].ToCharArray())
                {
                    textStack.Push(token);
                }
            }
        }

        private static int BuildReverseStringFromStack(Stack<char> textStack, string[] words, string[] wordsOut)
        {
            var x = 0;
            for (int i = words.Length - 1; i >= 0; i--)
            {
                var length = words[i].Length;
                var word = new char[length];
                for (int n = 0; n < length; n++)
                {
                    word[n] = textStack.Pop();
                }
                wordsOut[x] = new string(word);
                x++;
            }

            return x;
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
             Regex test = new Regex(@"\p{Ps}"); // Any opening bracket
        }

    }
}
