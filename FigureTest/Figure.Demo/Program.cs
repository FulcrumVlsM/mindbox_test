using Figure.Assistant.Figures;
using Figure.Assistant.Services;
using Figure.Demo.CustomFigures;

namespace Figure.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAreaCalculationService areaService;

            //Площадь круга по радиусу
            var circle1 = new Circle("Первый круг")
            { 
                Radius = 10 
            };
            areaService = new CircleCalculationService(circle1);
            WriteCircle(circle1, areaService.CalculateArea());


            //площадь треугольника по трем сторонам
            var triangle1 = new Triangle("Первый треугольник")
            {
                ASide = 5,
                BSide = 4,
                CSide = 3
            };
            areaService = new GeronTriangleCalculationService(triangle1);
            WriteTriangle(triangle1, areaService.CalculateArea());


            //пусть теперь определением фигуры займется отдельный декоратор
            var circle2 = new Circle("Второй круг")
            {
                Radius = 4
            };
            areaService = AreaCalculationServiceDecorator.CreateDecorator(circle2);
            WriteCircle(circle2, areaService.CalculateArea());


            //Отправим некорректную фигуру
            try
            {
                var triangle2 = new Triangle("Второй треугольник")
                {
                    ASide = -1,
                    BSide = 4,
                    CSide = 3
                };
                areaService = AreaCalculationServiceDecorator.CreateDecorator(triangle2);
                WriteTriangle(triangle2, areaService.CalculateArea());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            //Что, если добавить кастомную фигуру?
            //Пусть кастомная фигура уже содержит метод расчета
            //Нужно привязать новую фигуру декоратору
            AreaCalculationServiceDecorator.RegisterNewService(typeof(RightPolygon), polygon => polygon as IAreaCalculationService);

            //Теперь можно работать с новой фигурой
            var polygon = new RightPolygon("Пятиугольник 1")
            {
                SideCount = 5,
                Side = 12
            };
            areaService = AreaCalculationServiceDecorator.CreateDecorator(polygon);
            Console.WriteLine($"Площадь правильного пятиугольника со сторонами {polygon.Side} = {areaService.CalculateArea()}");

            Console.ReadKey();
        }


        static void WriteCircle(Circle circle, float area) => 
            Console.WriteLine($"Площадь круга \"{circle.Name}\" радиусом {circle.Radius} = {area}");

        static void WriteTriangle(Triangle triangle, float area) => 
            Console.WriteLine($"Площадь треугольника \"{triangle.Name}\" со сторонами {triangle.ASide}, {triangle.BSide}, {triangle.CSide} = {area}");
    }
}