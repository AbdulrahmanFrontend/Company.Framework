using Core;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class clsBaseBusiness
    {
        public clsEnums.enMode Mode { get; protected set; } = clsEnums.enMode.enAddNew;
        protected abstract bool _AddNew();
        protected abstract bool _Update();
        public bool Save()
        {
            switch (Mode)
            {
                case clsEnums.enMode.enAddNew:
                    if (_AddNew())
                    {
                        Mode = clsEnums.enMode.enUpdate;
                        return true;
                    }
                    return false;
                case clsEnums.enMode.enUpdate:
                    return _Update();
                default:
                    return false;
            }
        }
    }
}
