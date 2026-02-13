using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class clsEnums
    {
        public enum enMode { enAddNew, enEdit, enUpdate, enDelete }
        public enum enMessageType { enSuccess, enWarning, enError, enInfo }
        public enum enStatus { Active, Inactive }
    }
}
