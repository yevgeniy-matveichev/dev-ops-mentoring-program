using Module1.TypesAndClasses.Interfaces;
using Module1.TypesAndClasses.Shapes;
using System;

namespace Module1.TypesAndClasses.Generics
{
    public class ShapePrinter<T> where T: IShape
    {
        public void Print(T shape)
        {
            Console.WriteLine(shape.ToString());
        }

        //public override string ToString()
        //{
        //    //var eTriangle = new EquilateralTriangle(5);

        //    //var sb = new System.Text.StringBuilder();
        //    //sb.Append($"Shape: '{nameof(EquilateralTriangle)}'. ");
        //    //sb.Append($"Square = {eTriangle.Square()}, ");
        //    //sb.Append($"perimeter = {eTriangle.Perimeter()}. ");
        //    //sb.Append($"Side = {_a}");

        //    //return sb.ToString();

        //    return $"Shape: '{shape.GetType().Name}'. Square = {shape.Square()}, perimeter = {shape.Perimeter()}"
        //}

        //public bool PerimeterEquals<T>(T shape1, T shape2)
        //{
        //    if (shape1 == null)
        //    {
        //        if (shape2 == null)
        //        {
        //            throw new ArgumentNullException("Objects shape1 and shape2 were null.");
        //        }

        //        throw new ArgumentNullException(nameof(shape1));
        //    }

        //    if (shape2 == null)
        //    {
        //        throw new ArgumentNullException(nameof(shape2));
        //    }

        //    return shape1.Perimeter() == shape2.Perimeter();
        //}
    }
}
