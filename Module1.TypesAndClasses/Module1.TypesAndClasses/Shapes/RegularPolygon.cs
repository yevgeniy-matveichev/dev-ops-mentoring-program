using Module1.TypesAndClasses.Interfaces;

namespace Module1.TypesAndClasses.Shapes
{
    public class RegularPolygon : BaseShape
    {
        public RegularPolygon(): base(Metric.Metr)
        {

        }

        public override double Perimeter()
        {
            return 15;
        }

        public override double Square()
        {
            return 28;
        }
    }
}
