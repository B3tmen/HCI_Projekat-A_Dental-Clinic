using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Models.Util
{
    internal class GenderUtil
    {
        public static Gender GetByName(string genderName)
        {
            bool isMale = string.Equals(genderName, Gender.Male.ToString(), StringComparison.OrdinalIgnoreCase);

            return isMale ? Gender.Male : Gender.Female;
        }
    }
}
