using Figure.Assistant.Exceptions;
using Figure.Assistant.Figures;
using Figure.Assistant.Services;

namespace Figure.Tests
{
    public class CircleAreaCalcServiceTest
    {
        /// <summary>
        /// Тест на круг с радиусом 0
        /// </summary>
        [TestCase(0)]
        [TestCase(-1)]
        public void IncorrectRadiusTest(float r)
        {
            var circle = new Circle("Test") { Radius = r };
            var areaService = new CircleCalculationService(circle);
            Assert.Catch(typeof(InvalidFigureException), () => areaService.CalculateArea());
        }


        /// <summary>
        /// Проверка корректности вычисления. При R=1 S=pi
        /// </summary>
        /// <remarks>Значение точности взял произвольное</remarks>
        [Test]
        [DefaultFloatingPointTolerance(0.0001)]
        public void PIAreaTest()
        {
            var pi = Math.PI;
            var circle = new Circle("Test") { Radius = 1 };
            var areaService = new CircleCalculationService(circle);
            Assert.That(pi, Is.EqualTo(areaService.CalculateArea()));
        }
    }
}
