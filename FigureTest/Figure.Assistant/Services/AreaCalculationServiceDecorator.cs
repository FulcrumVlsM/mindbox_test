using Figure.Assistant.Figures;

namespace Figure.Assistant.Services
{
    /// <summary>
    /// Декоратор, который сам определит фигуру и метод для расчета ее площади
    /// </summary>
    public class AreaCalculationServiceDecorator : IAreaCalculationService
    {
        //набор дефолтных сопоставлений
        private static Stack<KeyValuePair<Type, Func<IFigure, IAreaCalculationService>>> _registeredServices = new(new List<KeyValuePair<Type, Func<IFigure, IAreaCalculationService>>>()
        {
            new(typeof(Circle), figure => new CircleCalculationService(figure as Circle)),
            new(typeof(Triangle), figure => new GeronTriangleCalculationService(figure as Triangle))
        });

        private readonly IAreaCalculationService _service;

        private AreaCalculationServiceDecorator() { }

        private AreaCalculationServiceDecorator(IAreaCalculationService areaCalculationService)
        {
            _service = areaCalculationService;
        }

        public float CalculateArea() => _service.CalculateArea();


        public static IAreaCalculationService CreateDecorator(IFigure figure)
        {
            Type t = figure.GetType();
            IAreaCalculationService? service = null;
            
            foreach (var rsi in _registeredServices)
            {
                if(t == rsi.Key)
                {
                    service = rsi.Value(figure);
                    if(service != null)
                    {
                        return new AreaCalculationServiceDecorator(service);
                    }
                }
            }

            throw new Exception("Не найдено ни одного зарегистрированного сервиса для данного типа");
        }


        /// <summary>
        /// Регистрация сервиса для типа фигуры
        /// </summary>
        /// <param name="t"></param>
        /// <param name="handler"></param>
        public static void RegisterNewService(Type t, Func<IFigure, IAreaCalculationService> handler)
        {
            _registeredServices.Push(new(t, handler));
        }
    }
}
