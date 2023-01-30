using Figure.Assistant.Exceptions;
using Figure.Assistant.Figures;
using Figure.Assistant.Validators;

namespace Figure.Assistant.Services
{
    /// <summary>
    /// Базовая реализация сервиса
    /// </summary>
    /// <remarks>Сюда прописываем общие вещи для всех реализаций, например, в данном случае - это валидация</remarks>
    public abstract class BaseAreaCalculationService<T> : IAreaCalculationService
        where T : IFigure
    {
        protected readonly T _figure;
        private readonly FigureValidator<T>? _areaValidator;

        public BaseAreaCalculationService(T figure) : this(figure, null) { }

        public BaseAreaCalculationService(T figure, FigureValidator<T>? areaValidator)
        {
            var baseIsCorrectValidator = new FigureValidator<T>(frg => frg.IsCorrect(), 
                (fgr) => throw new InvalidFigureException($"Фигура с именем \"{fgr.Name}\" имеет некорректные данные"));

            if(areaValidator != null)
            {
                baseIsCorrectValidator.AddNext(areaValidator);
            }

            _figure = figure;
            _areaValidator = baseIsCorrectValidator;
        }

        public float CalculateArea()
        {
            _areaValidator?.EnsureValidFigure(_figure);
            return CalculateArea(_figure);
        }

        protected abstract float CalculateArea(T figure);
    }
}
