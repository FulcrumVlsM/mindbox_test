using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure.Assistant.Figures
{
    public interface IFigure
    {
        string Name { get; }

        bool IsCorrect();
    }
}
