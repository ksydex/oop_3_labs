namespace Three
{
    public class Square : GeometricFigure
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public override double CalcArea()
            => Side * Side;
        
        public override string ToString()
            => $"Квадрат: side={Side}, S={CalcArea()}";
    }
}