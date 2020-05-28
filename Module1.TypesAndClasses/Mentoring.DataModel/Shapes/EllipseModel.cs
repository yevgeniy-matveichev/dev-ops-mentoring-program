
using Mentoring.DataAccess;

namespace Mentoring.DataModel.Shapes
{
    public class EllipseModel
    {
        public double Radius1 { get; set; } //SM: not double because of types in the Shape Ellipse Class
        
        public double Radius2 { get; set; }
        
        public Units Unit { get; set; }
    }
}
