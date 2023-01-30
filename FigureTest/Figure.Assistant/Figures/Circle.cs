using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure.Assistant.Figures
{
    public class Circle : IFigure
    {
        private readonly string _name;

        public Circle(string name)
        {
            _name = name;
        }

        public float Radius { get; set; }

        public string Name => _name;

        public bool IsCorrect() => Radius > 0;
    }
}
