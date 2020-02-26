using System;
using System.Text;

namespace MatrixTransformations
{
    public class Vector
    {
        public float x, y;

        public Vector()
        {
        }

        public Vector(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector v = new Vector(
                v1.x + v2.x,
                v1.y + v2.y
            );
            return v;
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            Vector v = new Vector(
                v1.x - v2.x,
                v1.y - v2.y
            );
            return v;
        }

        public static Vector operator *(Vector v1, float f)
        {
            Vector v = new Vector(
                v1.x * f,
                v1.y * f
            );
            return v;
        }

        public static Vector operator *(float f, Vector v)
        {
            return f * v; // ??
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("", 50);

            sb.Append("/"+x+"\\n");
            sb.Append("\\n"+y+"/");

            return sb.ToString();
        }
    }
}
