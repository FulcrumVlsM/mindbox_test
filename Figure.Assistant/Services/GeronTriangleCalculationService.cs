using Figure.Assistant.Figures;
using Figure.Assistant.Validators;

namespace Figure.Assistant.Services
{
    public class GeronTriangleCalculationService : BaseAreaCalculationService<Triangle>
    {
        public GeronTriangleCalculationService(Triangle triangle) : base(triangle, new TriangleSidesValidator()) { }

        protected override float CalculateArea(Triangle figure)
        {
            var p = (figure.ASide + figure.BSide + figure.CSide) / 2;
            return (float)Math.Sqrt(p * (p - figure.ASide) * (p - figure.BSide) * (p - figure.CSide));
        }
    }
}
