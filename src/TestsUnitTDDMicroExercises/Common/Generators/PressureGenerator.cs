using System.Linq;
using FsCheck;

namespace TestsUnitTDDMicroExercises.Common.Generators
{
    internal static class PressureGenerator
    {
        private static readonly Arbitrary<double> Double;

        public static Arbitrary<double> WithinRange(double floor, double ceiling) =>
            Double.Generator.Where(@double => floor < @double && ceiling > @double).ToArbitrary();

        public static Arbitrary<double> OutsideOfRange(double floor, double ceiling) =>
            Double.Generator.Where(@double => floor > @double || @double > ceiling).ToArbitrary();

        static PressureGenerator() => Double = Arb.Generate<double>().ToArbitrary();
    }
}