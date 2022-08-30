using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRequisition.Core.Utilities
{
    public static class Helpers
    {
        public static long GenerateRequisitionNumber(long id)
        {
            
            string v = $"{DateTime.Now.Year}{DateTime.Now.Month}{id}";
            return long.Parse(v);
        }

        public static string GetInnerMessage(this Exception original)
        {
            if (original == null)
            {
                return null;
            }

            var ex = original;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            return ex.Message;
        }
    }
}
