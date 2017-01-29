using System;

namespace ThreeDimensionalForms
{
    public class Ellipsoid : ThreeDShape
    {
        public Ellipsoid(double radiusA, double radiusB, double radiusC)
        {
            if(radiusA<=0 || radiusB<=0 || radiusC<=0) throw new Exception("Ellipsoid must have postive radiuses");
            this.RadiusA = radiusA;
            this.RadiusB = radiusB;
            this.RadiusC = radiusC;
        }

        public double RadiusA { get; }
        public double RadiusB { get; }
        public double RadiusC { get; }

        private const double p = 1.6075; // there is no exacte formule for ellipsoid surface, so it's for approximation

        public override double Volume => 4d / 3 * Math.PI * RadiusA * RadiusB * RadiusC;

        public override double Surface
            =>
                4 * Math.PI *
                Math.Pow((Math.Pow(RadiusA * RadiusB, p) + Math.Pow(RadiusA * RadiusC, p) + Math.Pow(RadiusB * RadiusC, p)) / 3, p);
    }
}
