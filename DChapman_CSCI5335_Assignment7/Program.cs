/*Created by:  David Chapman
 * CSCI 5335 Assignment 7:  Adapter Pattern
 * 2/23/2015
 * Revisions:
 * 2/25/2015 - Added binary representation of HELLO
 * 
 * 
 * <Summary>
 * Implementation of adapter pattern design using languages.
 * There are 3 types of Human Languages: English, Spanish, and French. Machines cannott
 * speak human languages, they can only report their status in binary code.  The Binary 
 * Adapter returns the prntStatus method of the Machine Language which returns the 
 * machines binary representation of HELLO.
 * <Summary>
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChapman_CSCI5335_Assignment7
{
    class Program
    {
        //The abstract class
        public abstract class HumanLanguage
        {
            public abstract void sayHello();
        }

        //The HumanLanguage sub classes:
        public class English : HumanLanguage
        {
            public override void sayHello()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hello.");
                Console.ResetColor();
            }
        }
        public class Spanish : HumanLanguage
        {
            public override void sayHello()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hola.");
                Console.ResetColor();
            }
        }
        public class French : HumanLanguage
        {
            public override void sayHello()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Bonjour.");
                Console.ResetColor();
            }
        }
        //MachineLanguage abstract class.  This class will have to be adapted.
        public abstract class MachineLanguage
        {
            public abstract void prntStatus();
        }
        //MachineLanguage sub classS
        public class Binary : MachineLanguage
        {
            public override void prntStatus()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("01001000");
                Console.WriteLine("01000101");
                Console.WriteLine("01001100");
                Console.WriteLine("01001111");
                Console.ResetColor();
            }
        }
        //BinaryAdapter inherits HumanLanguge.  This is the adapter:
        public class BinaryAdapter : HumanLanguage
        {
            MachineLanguage binary = new Binary();
            public BinaryAdapter(MachineLanguage _binary)
            {
                this.binary = _binary;
            }
            public override void sayHello()
            {
                binary.prntStatus();
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "Object Oriented Design Assignment 7:  Adapter Pattern";
            Console.WindowHeight = 30;
            Console.WindowWidth = 50;
            //Create Language objects:
            HumanLanguage English = new English();
            HumanLanguage French = new French();
            HumanLanguage Spanish = new Spanish();
            MachineLanguage Binary = new Binary();

            //This is the adapter for the binary language:
            HumanLanguage BinaryAdapter = new BinaryAdapter(Binary);

            Console.WriteLine("*************************************");
            Console.WriteLine("*************************************");
            Console.WriteLine("*  Welcome to the Speech Simulator  *");
            Console.WriteLine("*  Listed below are the words for   *");
            Console.WriteLine("*  'Hello' in various languages     *");
            Console.WriteLine("*************************************");
            Console.WriteLine("*************************************");
            Console.WriteLine();

            //Print out hello in each language
            Console.WriteLine("English:  ");
            English.sayHello();
            Console.WriteLine();
            Console.WriteLine("French:  ");
            French.sayHello();
            Console.WriteLine();
            Console.WriteLine("Spanish:  ");
            Spanish.sayHello();
            Console.WriteLine();

            //The adapter makes it possible for the binary object to sayHello:
            Console.WriteLine("Machine:  ");
            BinaryAdapter.sayHello();
            Console.ReadKey();
        }
    }
}
