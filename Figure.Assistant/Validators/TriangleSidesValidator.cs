using Figure.Assistant.Exceptions;
using Figure.Assistant.Figures;

namespace Figure.Assistant.Validators
{
    internal class TriangleSidesValidator : FigureValidator<Triangle>
    {
        public TriangleSidesValidator() 
            : base(fgr => fgr.ASide < fgr.BSide + fgr.CSide && (fgr.BSide < fgr.CSide + fgr.ASide ? fgr.CSide < fgr.ASide + fgr.BSide : false), 
                  fgr => throw new InvalidFigureException($"Треугольника \"{fgr.Name}\" с такими сторонами существовать не может"))
        { }
    }
}
