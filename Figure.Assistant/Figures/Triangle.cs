namespace Figure.Assistant.Figures
{
    public class Triangle : IFigure
    {
        private const double PRECISION = 0.0001;
        private readonly string _name;

        public Triangle(string name)
        {
            _name = name;
        }

        public float ASide { get; set; }

        public float BSide { get; set; }

        public float CSide { get; set; }

        //Проверка на то что треугольник является прямоугольным (по теореме Пифагора)
        public bool IsRightTriangle
        {
            get
            {
                var aPow = Math.Pow(ASide, 2);
                var bPow = Math.Pow(BSide, 2);
                var cPow = Math.Pow(CSide, 2);

                if (Math.Abs(aPow - (bPow + cPow)) <= PRECISION)
                    return true;
                else if (Math.Abs(bPow - (aPow + cPow)) <= PRECISION)
                    return true;
                else if (Math.Abs(cPow - (aPow + bPow)) <= PRECISION)
                    return true;
                else return false;
            }
        }

        public string Name => _name;

        /// <summary>
        /// Проверка корректности данных
        /// </summary>
        /// <returns></returns>
        /// <remarks>Предположим здесь проверяется только неотрицательность, для проверки соотношений сторон пусть будет отдельный валидатор</remarks>
        public bool IsCorrect() => ASide > 0 && BSide > 0 && CSide > 0;
    }
}
