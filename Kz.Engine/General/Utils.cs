namespace Kz.Engine.General
{
    public static class Utils
    {        
        #region RangeMap

        /// <summary>
        /// Map a value from one range to another range.
        /// e.g. 5 in the range 1 - 10 would be 50 in the range 1 - 100
        /// </summary>
        public static float RangeMap(float srcValue, float srcMin, float srcMax, float destMin, float destMax)
        {
            var newValue = ((srcValue - srcMin) / (srcMax - srcMin)) * (destMax - destMin) + destMin;
            return newValue;
        }

        /// <summary>
        /// Map a value from one range to another range.
        /// e.g. 5 in the range 1 - 10 would be 50 in the range 1 - 100
        /// </summary>
        public static double RangeMap(double srcValue, double srcMin, double srcMax, double destMin, double destMax)
        {
            var newValue = ((srcValue - srcMin) / (srcMax - srcMin)) * (destMax - destMin) + destMin;
            return newValue;
        }

        /// <summary>
        /// Map a value from one range to another range.
        /// e.g. 5 in the range 1 - 10 would be 50 in the range 1 - 100
        /// </summary>
        public static decimal RangeMap(decimal srcValue, decimal srcMin, decimal srcMax, decimal destMin, decimal destMax)
        {
            var newValue = ((srcValue - srcMin) / (srcMax - srcMin)) * (destMax - destMin) + destMin;
            return newValue;
        }

        /// <summary>
        /// Map a value from one range to another range.
        /// e.g. 5 in the range 1 - 10 would be 50 in the range 1 - 100
        /// </summary>
        public static int RangeMap(int srcValue, int srcMin, int srcMax, int destMin, int destMax)
        {
            var newValue = ((srcValue - srcMin) / (srcMax - srcMin)) * (destMax - destMin) + destMin;
            return newValue;
        }

        /// <summary>
        /// Map a value from one range to another range.
        /// e.g. 5 in the range 1 - 10 would be 50 in the range 1 - 100
        /// </summary>
        public static long RangeMap(long srcValue, long srcMin, long srcMax, long destMin, long destMax)
        {
            var newValue = ((srcValue - srcMin) / (srcMax - srcMin)) * (destMax - destMin) + destMin;
            return newValue;
        }

        #endregion RangeMap

        #region Clamp

        /// <summary>
        /// Clamp a value between min and max (e.g. -5 between 7 and 17 would be 7)
        /// </summary>
        public static float Clamp(float value, float min, float max)
        {
            var result = (value < min) ? min : value;
            if (result > max) result = max;
            return result;
        }

        /// <summary>
        /// Clamp a value between min and max (e.g. -5 between 7 and 17 would be 7)
        /// </summary>
        public static double Clamp(double value, double min, double max)
        {
            var result = (value < min) ? min : value;
            if (result > max) result = max;
            return result;
        }

        /// <summary>
        /// Clamp a value between min and max (e.g. -5 between 7 and 17 would be 7)
        /// </summary>
        public static decimal Clamp(decimal value, decimal min, decimal max)
        {
            var result = (value < min) ? min : value;
            if (result > max) result = max;
            return result;
        }

        /// <summary>
        /// Clamp a value between min and max (e.g. -5 between 7 and 17 would be 7)
        /// </summary>
        public static int Clamp(int value, int min, int max)
        {
            var result = (value < min) ? min : value;
            if (result > max) result = max;
            return result;
        }

        /// <summary>
        /// Clamp a value between min and max (e.g. -5 between 7 and 17 would be 7)
        /// </summary>
        public static long Clamp(long value, long min, long max)
        {
            var result = (value < min) ? min : value;
            if (result > max) result = max;
            return result;
        }

        #endregion Clamp

        #region Lerp

        /// <summary>
        /// Linearly interpolate an amount (in the range of 0 to 1) between start and end
        /// </summary>
        public static float Lerp(float start, float end, float amount)
        {
            var result = start + amount * (end - start);
            return result;
        }

        /// <summary>
        /// Linearly interpolate an amount (in the range of 0 to 1) between start and end
        /// </summary>
        public static double Lerp(double start, double end, double amount)
        {
            var result = start + amount * (end - start);
            return result;
        }

        /// <summary>
        /// Linearly interpolate an amount (in the range of 0 to 1) between start and end
        /// </summary>
        public static decimal Lerp(decimal start, decimal end, decimal amount)
        {
            var result = start + amount * (end - start);
            return result;
        }

        /// <summary>
        /// Linearly interpolate an amount (in the range of 0 to 1) between start and end
        /// </summary>
        public static int Lerp(int start, int end, double amount)
        {
            var result = start + amount * (end - start);
            return (int)result;
        }

        /// <summary>
        /// Linearly interpolate an amount (in the range of 0 to 1) between start and end
        /// </summary>
        public static long Lerp(long start, long end, double amount)
        {
            var result = start + amount * (end - start);
            return (long)result;
        }

        #endregion Lerp

        #region Normalize

        /// <summary>
        /// Normalize a value between the range start to end (e.g. 5 in the range 0 to 10 would be 0.5)
        /// </summary>
        public static float Normalize(float value, float start, float end)
        {
            var result = (value - start) / (end - start);
            return result;
        }

        /// <summary>
        /// Normalize a value between the range start to end (e.g. 5 in the range 0 to 10 would be 0.5)
        /// </summary>
        public static double Normalize(double value, double start, double end)
        {
            var result = (value - start) / (end - start);
            return result;
        }

        /// <summary>
        /// Normalize a value between the range start to end (e.g. 5 in the range 0 to 10 would be 0.5)
        /// </summary>
        public static decimal Normalize(decimal value, decimal start, decimal end)
        {
            var result = (value - start) / (end - start);
            return result;
        }

        /// <summary>
        /// Normalize a value between the range start to end (e.g. 5 in the range 0 to 10 would be 0.5)
        /// </summary>
        public static int Normalize(int value, int start, int end)
        {
            var result = (value - start) / (end - start);
            return result;
        }

        /// <summary>
        /// Normalize a value between the range start to end (e.g. 5 in the range 0 to 10 would be 0.5)
        /// </summary>
        public static long Normalize(long value, long start, long end)
        {
            var result = (value - start) / (end - start);
            return result;
        }

        #endregion Normalize

        #region Wrap

        /// <summary>
        /// Wrap input value from min to max (e.g. 11 in range 1 to 10 would be 1)
        /// </summary>
        public static float Wrap(float value, float min, float max)
        {
            var result = value - (max - min) * MathF.Floor((value - min) / (max - min));
            return result;
        }

        /// <summary>
        /// Wrap input value from min to max (e.g. 11 in range 1 to 10 would be 1)
        /// </summary>
        public static double Wrap(double value, double min, double max)
        {
            var result = value - (max - min) * Math.Floor((value - min) / (max - min));
            return result;
        }

        /// <summary>
        /// Wrap input value from min to max (e.g. 11 in range 1 to 10 would be 1)
        /// </summary>
        public static decimal Wrap(decimal value, decimal min, decimal max)
        {
            var result = value - (max - min) * Math.Floor((value - min) / (max - min));
            return result;
        }

        /// <summary>
        /// Wrap input value from min to max (e.g. 11 in range 1 to 10 would be 1)
        /// </summary>
        public static int Wrap(int value, int min, int max)
        {
            var result = value - (max - min) * Math.Floor((double)(value - min) / (double)(max - min));
            return (int)result;
        }

        /// <summary>
        /// Wrap input value from min to max (e.g. 11 in range 1 to 10 would be 1)
        /// </summary>
        public static long Wrap(long value, long min, long max)
        {
            var result = value - (max - min) * Math.Floor((double)(value - min) / (double)(max - min));
            return (long)result;
        }

        #endregion Wrap

        #region EpsilonEquals

        /// <summary>
        /// Check if two floats are equal
        /// </summary>
        public static bool EpsilonEquals(float lhs, float rhs)
        {
            var result = MathF.Abs(lhs - rhs) <= (Consts.EPSILON * MathF.Max(1.0f, MathF.Max(MathF.Abs(lhs), MathF.Abs(rhs))));
            return result;
        }

        /// <summary>
        /// Check if two doubles are equal
        /// </summary>
        public static bool EpsilonEquals(double lhs, double rhs)
        {
            var result = Math.Abs(lhs - rhs) <= (Consts.DOUBLE_EPSILON * Math.Max(1.0, Math.Max(Math.Abs(lhs), Math.Abs(rhs))));
            return result;
        }

        /// <summary>
        /// Check if two decimals are equal
        /// </summary>
        public static bool EpsilonEquals(decimal lhs, decimal rhs)
        {
            var result = Math.Abs(lhs - rhs) <= (Consts.DECIMAL_EPSILON * Math.Max(1.0m, Math.Max(Math.Abs(lhs), Math.Abs(rhs))));
            return result;
        }

        #endregion FloatEquals
    }
}