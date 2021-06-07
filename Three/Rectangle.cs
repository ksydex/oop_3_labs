namespace Three
{
    public class Rectangle : GeometricFigure
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public override double CalcArea()
            => Height * Width;

        public override string ToString()
            => $"Прямоугольник: h={Height}, w={Width}, S={CalcArea()}";
    }
}