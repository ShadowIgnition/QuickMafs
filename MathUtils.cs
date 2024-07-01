using System.Data;

namespace QuickMafs
{
    public static class MathUtils
    {
        /// <summary>
        /// Evaluates the mathematical expression entered by the user.
        /// </summary>
        public static bool TryEvaluate(string expression, DataTable dataTable, out string result)
        {
            expression = expression.ToLowerInvariant();
            expression = expression.Replace('÷', '/');
            expression = expression.Replace('x', '*');
            expression = expression.Replace('=', '*');

            try
            {
                object resultObj = dataTable.Compute(expression, null);
                result = Convert.ToDouble(resultObj).ToString();
                return true;
            }
            catch (Exception exception)
            {
                result = exception.Message;
                return false;
            }
        }

    }
}