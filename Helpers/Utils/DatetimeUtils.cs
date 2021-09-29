using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.Utils
{
    public partial class Utils
    {
        public static DateTime GetDateTimeUTCNow()
        {
            return DateTime.UtcNow.AddHours(7);
        }
    }
}
