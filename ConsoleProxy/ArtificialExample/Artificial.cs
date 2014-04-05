using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProxy {

    public class Artificial {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">Two expected, the second of which must be an integer</param>
        public static void _Main(string[] args) {

            if (args == null || args.Length != 2) {
                throw new ArgumentException("Artificial._Main must be called with two arguments");
            }

            Console.WriteLine("The first argument is {0}", args[0]);

            int n;
            if (Int32.TryParse(args[1], out n)) {
                Console.WriteLine("The second argument is {0}", n);
            }
            else {
                throw new ArgumentException("The second argument to Artifical._Main must be an integer");
            }
        }

    }
}
