using Figure.Assistant.Exceptions;
using Figure.Assistant.Figures;
using Figure.Assistant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure.Tests
{
    public class TriangleAreaCalcTest
    {
        [TestCase(0, 1, 2)]
        [TestCase(1, 0, 2)]
        [TestCase(1, 2, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(5, 2, 2)]
        [TestCase(2, 5, 2)]
        [TestCase(2, 2, 5)]
        public void IncorrectSidesTest(int a, int b, int c)
        {
            Triangle triangle = new Triangle("test")
            {
                ASide = a,
                BSide = b,
                CSide = c
            };

            var areaService = new GeronTriangleCalculationService(triangle);

            Assert.Catch(typeof(InvalidFigureException), () => areaService.CalculateArea());
        }
    }
}
