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
    }
}