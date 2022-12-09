using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling
{
    public class MaximumAttempt : Exception
    {
        public override string Message => "MAXIMUM_ATTEMPT";
    }

    public class NoDeviceFound : Exception
    {
        public override string Message => "NO_DEVICE_FOUND";
    }
}
