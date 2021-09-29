using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiSystem.Helpers.Utils
{
    public partial class Utils
    {
        public static bool IsNullOrDefaultValue(Object value)
        {
            if( value == null)
            {
                return true;
            }

            try
            {
                float checkedNumber = float.Parse(value.ToString());
                return checkedNumber == 0.0f;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
