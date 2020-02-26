using System;
using System.Text;

namespace MatrixTransformations
{
    public class Matrix
    {
        float[,] mat = new float[2, 2];

        public Matrix() {
        }
        public Matrix(float m11, float m12,
                      float m21, float m22)
        {
            mat[0, 0] = m11; mat[0, 1] = m12;
            mat[1, 0] = m21; mat[1, 1] = m22;
        }

        public Matrix(Vector v)
        {
            mat[0, 0] = v.x;
            mat[1, 0] = v.y;
        }

        public Vector ToVector() {

            return new Vector(mat[0, 0], mat[1, 0]);
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix m3 = new Matrix();
            for (int i = 0; i < m1.mat.GetLength(0); i++) {
                for (int j=0; j < m1.mat.GetLength(1); j++) {
                    m3.mat[i, j] = m1.mat[i, j] + m2.mat[i, j];
                }
            }
            return m3;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix m3 = new Matrix();
            for (int i = 0; i < m1.mat.GetLength(0); i++) {
                for (int j=0; j < m1.mat.GetLength(1); j++) {
                    m3.mat[i, j] = m1.mat[i, j] - m2.mat[i, j];
                }
            }
            return m3;
        }
        public static Matrix operator *(Matrix m1, float f)
        {
            Matrix m3 = new Matrix();
            for (int i = 0; i < m1.mat.GetLength(0); i++) {
                for (int j=0; j < m1.mat.GetLength(1); j++) {
                    m3.mat[i, j] = m1.mat[i, j] * f;
                }
            }
            return m3;
        }

        public static Matrix operator *(float f, Matrix m1)
        {
            return m1 * f;
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix m3 = new Matrix(); // getlenght
            for (int i=0; i < m1.mat.GetLength(0); i++) {
                for(int j= 0; j < m1.mat.GetLength(1); j++) {
                    
                    float sum = 0;

                    for (int k=0; k < m2.mat.GetLength(0); k++) {
                        sum += m1.mat[i, k] * m2.mat[k, j];
                        
                    }
                    m3.mat[i, j] = sum;
                }
            }
            return m3;
        }

        public static Vector operator *(Matrix m1, Vector v)
        {
            return (m1 * new Matrix(v)).ToVector();
        }

        public static Matrix Identity()
        {
            return new Matrix(1, 0, 0, 1);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("/"+mat[0,0]+" "+mat[0,1]+"\\n");
            sb.Append("\\n"+mat[1,0]+" "+mat[1,1]+"/");

            return sb.ToString();
        }
    }
}
