namespace Figure.Assistant.Validators
{
    public class FigureValidator<T>
    {
        private readonly Predicate<T> _predicate;
        private readonly Action<T> _onInvalid;
        private FigureValidator<T>? _next;

        public FigureValidator(Predicate<T> predicate, Action<T> onInvalidFigureAction)
        {
            _predicate = predicate;
            _onInvalid = onInvalidFigureAction;
        }

        public void AddNext(FigureValidator<T> nextValidator)
        {
            if(_next == null)
            {
                _next = nextValidator;
            }
            else
            {
                _next.AddNext(nextValidator);
            }
        }

        public void EnsureValidFigure(T figure)
        {
            if (_predicate(figure))
            {
                if(_next != null)
                {
                    _next.EnsureValidFigure(figure);
                }
            }
            else
            {
                _onInvalid(figure);
            }
        }
    }
}
