using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ConsoleProxy {

    class Program {

        /// <summary>
        /// The name of the type whose _Main method is to be called must be passed as the first argument,
        /// with any subsequent arguments being passed on to the method to be called
        /// </summary>
        static void Main(String[] args) {

            if (args == null || args.Length < 1 || string.IsNullOrWhiteSpace(args[0])) {
                Console.WriteLine("Please specify the name of the class whose _Main method should be invoked");
                return;
            }
            string typeName = string.Format("ConsoleProxy.{0}", args[0]);
            if (args.Length > 1) {
                args = args.Skip(1).ToArray();
            }

            Type type = null;

            try {
                type = Type.GetType(typeName);
            }
            catch (NullReferenceException) {
                Console.WriteLine("Error. Type name is null");
            }
            catch (TargetInvocationException) {
                Console.WriteLine("Error. Class initializer for {0} invoked", typeName);
            }
            catch (ArgumentException e) {
                Console.WriteLine("Error. Argument exception: {0}", e.Message);
            }
            catch (TypeLoadException) {
                Console.WriteLine("Error. the type name passed in represents an array of System.TypedReference.");
            }
            catch (FileLoadException) {
                Console.WriteLine("Error. The assembly or one of its dependencies was found, but could not be loaded.");
            }
            catch (BadImageFormatException e) {
                Console.WriteLine("Error. BadImageFormat exception: {0}", e.Message);
            }

            if (type == null) {
                Console.WriteLine("No type with name {0} was found in the currently executing assembly ({1})", 
                    typeName, Assembly.GetExecutingAssembly().GetName());
            }
            else {
                try {
                    type.GetMethod("_Main", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[] { args });
                }
                catch (AmbiguousMatchException) {
                    Console.WriteLine("Error. More than one public static method found with the name {0}._Main", typeName);
                }
                catch (NullReferenceException) {
                    Console.WriteLine("Error. No public static method with the name _Main found on the type {0}", typeName);
                }
                catch (TargetInvocationException e) {
                    if (e.InnerException != null) {
                        // relay the message from an exception thrown by the invoked method to the user
                        Console.WriteLine("Error. Exception thrown by {0}._Main:", typeName);
                        Console.WriteLine(e.InnerException.Message);
                        Console.WriteLine(e.InnerException.StackTrace);
                    }
                    else {
                        Console.WriteLine("Error. Failed to invoke {0}._Main:", typeName);
                    }
                }
            }

        }

    }
}
