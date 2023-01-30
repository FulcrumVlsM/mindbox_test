using Figure.Assistant.Figures;
using Figure.Assistant.Services;

namespace Figure.Demo.CustomFigures
{
    internal class RightPolygon : IFigure, IAreaCalculationService
    {
        internal RightPolygon(string name) => Name = name;

        public string Name { get; private set; }

        public float Side { get; set; }

        public uint SideCount { get; set; }

        public float CalculateArea() => 
            (float)(SideCount * Math.Pow(Side, 2) / (4 * Math.Tan(Math.PI / SideCount)));

        public bool IsCorrect() => Side > 0;
    }
}
