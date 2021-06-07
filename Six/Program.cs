using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Six
{
    class Program
    {
        private delegate int Operation(int x, int y);

        private static int Add(int x, int y) => x + y;
        private static int Multiply(int x, int y) => x * y;
        private static int Pow(int x, int y) => (int) Math.Pow(x, y);

        private static void OutputDelegateOperationResult(Operation o, int x, int y) =>
            Console.WriteLine("Delegate result: " + o.Invoke(x, y));

        private static void OutputFuncDelegateOperationResult(Func<int, int, int> o, int x, int y) =>
            Console.WriteLine("Func delegate result: " + o.Invoke(x, y));


        static void Main(string[] args)
        {
            OutputDelegateOperationResult(Add, 1, 2);
            OutputDelegateOperationResult(Multiply, 3, 4);
            OutputDelegateOperationResult(Pow, 2, 10);
            OutputDelegateOperationResult((x, y) => x / y, 10, 5);

            OutputFuncDelegateOperationResult(Add, 1, 2);
            OutputFuncDelegateOperationResult(Multiply, 3, 4);
            OutputFuncDelegateOperationResult(Pow, 2, 10);
            OutputFuncDelegateOperationResult((x, y) => x / y, 10, 5);


            OutputTypeInfo(typeof(Class1));
            Console.WriteLine("Result of method invoked with reflections: " + typeof(Class1).GetMethod("MethodIntFromString")?.Invoke(null, new object[] { "10" }));
        }

        private static void OutputTypeInfo(Type t)
        {
            OutputDivider();
            Console.WriteLine(t.Name + " info");

            foreach (var constructorInfo in t.GetConstructors()
                .Concat(t.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Concat(t.GetConstructors(BindingFlags.Static | BindingFlags.NonPublic))))
                Console.WriteLine("Constructor, Name: " + constructorInfo.Name + ", IsPublic: " +
                                  constructorInfo.IsPublic + ", IsPrivate: " +
                                  constructorInfo.IsPrivate + ", IsStatic: " + constructorInfo.IsStatic);

            foreach (var propertyInfo in t.GetProperties())
                Console.WriteLine("Property, Name: " + propertyInfo.Name + ", Type: " + propertyInfo.PropertyType.Name);

            foreach (var methodInfo in t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static))
                Console.WriteLine("Method, Name: " + methodInfo.Name + ", ParamsCount: " +
                                  methodInfo.GetParameters().Length + ", Returns type: " + methodInfo.ReturnType.Name);

            foreach (var propertyInfo in t.GetProperties().Where(x => Attribute.IsDefined(x, typeof(ShowMeAttribute))))
                Console.WriteLine("Property with [ShowMe] attribute, Name: " + propertyInfo.Name + ", Type: " +
                                  propertyInfo.PropertyType.Name);

            OutputDivider();
        }

        private static void OutputDivider() => Console.WriteLine("========================================");
    }
}