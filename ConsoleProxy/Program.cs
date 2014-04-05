using System;
using System.Linq;
using System.Reflection;

namespace ConsoleProxy {

    class Program {

        static void Main(String[] args) {

            if (args == null || args.Length < 1 || string.IsNullOrWhiteSpace(args[0])) {
                Console.WriteLine("Please specify the name of the class whose _Main method should be invoked");
            }
            string typeName = string.Format("ConsoleProxy.{0}", args[0]);
            if (args.Length > 1) {
                args = args.Skip(1).ToArray();
            }

            Type type = Type.GetType(typeName);

            type.GetMethod("_Main", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[] { args });

        }

    }
}
