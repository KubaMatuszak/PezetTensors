namespace ProcessTest.Model
{

    /// <summary>
    /// Cable model. 
    /// </summary>
    public class Cable
    {
        public Cable() { }
        public Node FromNode { get; set; }
        public Node ToNode { get; set; }
        public double XFrom;
        public double YFrom;
        public double XTo;
        public double YTo;
    }
}
