using System;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Ultilities
{
    public class EMException :Exception
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public EMException()
        {

        }
        public EMException(string message) : base(message)
        {
            log.Error(message);
        }
    }
}
