using System;
using System.Linq;

namespace StellarSystem
{
    public class SolarSystem : StellarSystem
    {
        public SolarSystem()
        {
            CentralStar = "Sun";
            planets = new[] { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Pluto" };
        }
        public override string this[int index]
        {
            get
            {
                if (index < 1 || index > 9) throw new IndexOutOfRangeException("Index cannot be negative or higher than 9");
                return planets[index - 1];
            }
        }

        public override int this[string index]
        {
            get
            {
                if (planets.Any(planet => planet == index)) return Array.IndexOf(planets, index) + 1;
                throw new IndexOutOfRangeException("No such planet exists in our system");
            }
        }

        public override string ToString()
        {
            return "Solar System";
        }
    }
}
