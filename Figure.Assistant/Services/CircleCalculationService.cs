using Figure.Assistant.Figures;

namespace Figure.Assistant.Services
{
    public class CircleCalculationService : BaseAreaCalculationService<Circle>
    {
        public CircleCalculationService(Circle circle) : base(circle) { }


        protected override float CalculateArea(Circle circle) => (float)(Math.Pow(_figure.Radius, 2) * Math.PI);
    }
}
