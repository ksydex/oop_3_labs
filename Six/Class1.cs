namespace Six
{
    public class Class1
    {
        public static int StaticPropertyInt { get; set; }
        public int PropertyInt { get; set; }
        [ShowMe] public string PropertyString { get; set; }
        [ShowMe] public double PropertyDouble { get; set; }

        public Class1()
        {
            PropertyInt = 1337;
            PropertyString = "Logic";
            PropertyDouble = 77.44;
        }

        public Class1(int v1, string v2, double v3)
        {
            PropertyInt = v1;
            PropertyString = v2;
            PropertyDouble = v3;
        }

        static Class1() => StaticPropertyInt = 100;

        public void MethodVoid()
        {
        }

        public static int MethodIntFromString(string x)
            => int.TryParse(x, out var y) ? y : 0;
    }
}