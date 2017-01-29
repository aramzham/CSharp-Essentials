using System;

namespace ThreeDimensionalForms
{
    public class Parallelepiped : ThreeDShape
    {
        public Parallelepiped(double baseEdgeA, double baseEdgeB, double edgeC, double angleAB, double angleCBase)
        {
            if (baseEdgeA <= 0 || baseEdgeB <= 0 || edgeC <= 0) throw new Exception("Parallelepiped edges must be positive");
            if (angleAB >= 180 || angleAB <= 0 || angleCBase >= 180 || angleCBase <= 0) throw new Exception("Impossible to create a parallelepiped with specified angles");
            this.BaseEdgeA = baseEdgeA;
            this.BaseEdgeB = baseEdgeB;
            this.EdgeC = edgeC;
            this.AngleAB = angleAB;
            this.AngleCBase = angleCBase;
        }

        public double BaseEdgeA { get; }
        public double BaseEdgeB { get; }
        public double EdgeC { get; }
        public double AngleAB { get; }
        public double AngleCBase { get; }

        public override double Volume => BaseEdgeA * BaseEdgeB * EdgeC * Math.Sin(AngleAB) * Math.Sin(AngleCBase);
        public override double Surface => 2 * (BaseEdgeA * BaseEdgeB + BaseEdgeA * EdgeC + BaseEdgeB * EdgeC);
    }
}
