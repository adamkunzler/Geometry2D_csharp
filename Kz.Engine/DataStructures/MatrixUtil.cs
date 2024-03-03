namespace Kz.Engine.DataStructures
{
    public static class MatrixUtil
    {
        /// <summary>
        /// Print a NxM matrix
        /// </summary>
        /// <param name="n">Number of Rows</param>
        /// <param name="m">Number of Columns</param>
        /// <returns>a string representing the matrix</returns>
        public static string PrintMatrix(float[] data, int n, int m)
        {
            var result = "";
            for (var y = 0; y < n; y++)
            {
                result += "(";
                for (var x = 0; x < m; x++)
                {
                    result += $"{data[x + y * m],8:0.000}";
                    if (x < m - 1)
                    {
                        result += ",\t";
                    }
                }
                result += ")\n";
            }
            return result;
        }
    }
}