using System;

namespace First
{
    class Program
    {
        public static double Discriminant(double a, double b, double c) => b * b - 4 * a * c;

        public static double ReadDouble(bool nonZero = false)
        {
            try
            {
                var x = Convert.ToDouble(Console.ReadLine());
                if (!nonZero || x != 0) return x;

                Console.WriteLine("Коэффициент не может быть равен 0, введите повторно...");
                return ReadDouble();
            }
            catch (Exception)
            {
                Console.WriteLine("Введите коэффициент...");
                return ReadDouble();
            }
        }

        public static double SolveDefault(double a, double b, double disc, bool first)
            => (-b + (first ? 1 : -1) * Math.Sqrt(disc)) / (2 * a);

        // 1, -2, -3
        // -1, -2, 15
        // 1, 12, 36
        static void Main(string[] args)
        {
            Console.WriteLine("Введите поочередно коэффициенты a, b, c");

            var a = ReadDouble(true);
            var b = ReadDouble();
            var c = ReadDouble();

            Console.WriteLine($"Уравнение: {a}*x^2+{b}*x+{c}");
            var disc = Discriminant(a, b, c);
            Console.WriteLine($"Дискриминант: {disc}");
            Console.WriteLine(disc switch
            {
                0 => "Единственный корень уровнения равен " + (-b / (2 * a)),
                var x when x > 0 =>
                    $"2 корня уравнения: x1={SolveDefault(a, b, x, true)}, x2={SolveDefault(a, b, x, false)}",
                var x when x < 0 => "Дискриминант отрицательный, нет корней",
                _ => "Ошибка при вычислении корней"
            });
        }
    }
}