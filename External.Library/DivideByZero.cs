using System;
using Serilog;

namespace External.Library
{
    public class DivideByZero : IDivideByZero
    {
        readonly ILogger log;

        public DivideByZero(ILogger logger) 
            => log = logger.ForContext<DivideByZero>();

        public void CrashThyself(int dividend)
        {
            int divisor = 0;
            try
            {
                log.Debug("Dividing {dividend} by {divisor}", dividend, divisor);
                Console.WriteLine(dividend / divisor);
            }
            catch(Exception ex)
            {
                log.Error(ex, ex.Message);
            }
        }

    }
}
