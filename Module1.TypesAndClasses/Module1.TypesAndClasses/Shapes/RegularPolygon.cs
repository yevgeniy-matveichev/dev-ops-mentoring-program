using Module1.TypesAndClasses.Interfaces;

namespace Module1.TypesAndClasses.Shapes
{
    public class RegularPolygon : IShape
    {
        public Units Units => throw new System.NotImplementedException();

        //public int Perimeter()
        //{
        //    throw new System.NotImplementedException();
        //}
        
        //public long Square()
        //{
        //    throw new System.NotImplementedException();
        //}

        double IShape.Perimeter()
        {
            throw new System.NotImplementedException();
        }

        double IShape.Square() 
        {
            throw new System.NotImplementedException();
        }
    }
}
