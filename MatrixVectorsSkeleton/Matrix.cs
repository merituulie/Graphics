using System;
using System.Text;

namespace MatrixTransformations
{
	public class Matrix
	{
		public float[,] mat = new float[2, 2];

		public Matrix()
		{
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

		public Vector ToVector()
		{
			return new Vector(mat[0, 0], mat[1, 0]);
		}

		public static Matrix operator +(Matrix m1, Matrix m2)
		{
			Matrix m = new Matrix();
			for (int y = 0; y < m1.mat.GetLength(0); y++)
			{
				for (int x = 0; x < m1.mat.GetLength(1); x++)
				{
					m.mat[y, x] = m1.mat[y, x] + m2.mat[y, x];
				}
			}
			return m;
		}

		public static Matrix operator -(Matrix m1, Matrix m2)
		{
			Matrix m = new Matrix();
			for (int y = 0; y < m1.mat.GetLength(0); y++)
			{
				for (int x = 0; x < m1.mat.GetLength(1); x++)
				{
					m.mat[y, x] = m1.mat[y, x] - m2.mat[y, x];
				}
			}
			return m;
		}
		public static Matrix operator *(Matrix m1, float f)
		{
			Matrix m = new Matrix();
			for (int y = 0; y < m1.mat.GetLength(0); y++)
			{
				for (int x = 0; x < m1.mat.GetLength(1); x++)
				{
					m.mat[y, x] = m1.mat[y, x] * f;
				}
			}
			return m;
		}

		public static Matrix operator *(float f, Matrix m1)
		{
			return m1 * f;
		}

		public static Matrix operator *(Matrix m1, Matrix m2)
		{
			Matrix m = new Matrix();
			for (int m1y = 0; m1y < m1.mat.GetLength(0); m1y++)
			{
				for (int m1x = 0; m1x < m1.mat.GetLength(1); m1x++)
				{
					float sum = 0;

					for (int m2y = 0; m2y < m2.mat.GetLength(0); m2y++)
					{
						sum += m1.mat[m1y, m2y] * m2.mat[m2y, m1x];
					}

					m.mat[m1y, m1x] = sum;
				}
			}
			return m;
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
			return $"/{mat[0, 0]}, {mat[0, 1]}\\\r\n\\{mat[1, 0]}, {mat[1, 1]}/ ";
		}
	}
}
