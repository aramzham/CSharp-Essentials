namespace StellarSystem
{
    public abstract class StellarSystem
    {
        public string CentralStar { get; set; }

        protected string[] planets;

        public abstract string this[int index] { get; }
        public abstract int this[string index] { get; }
    }
}
