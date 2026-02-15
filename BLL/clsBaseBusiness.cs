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
        public clsEnums.enMode Mode { get; protected set; }
        public virtual clsResult Validate() => clsResult.Success();
        protected abstract bool _AddNew();
        protected abstract bool _Update();
        public clsResult Save()
        {
            if (!Validate().IsSuccess)
            {
                return clsResult.Failure(Validate().Message);
            }
            switch (Mode)
            {
                case clsEnums.enMode.enAddNew:
                    if (_AddNew())
                    {
                        Mode = clsEnums.enMode.enUpdate;
                        return clsResult.Success("Saved Successfully");
                    }
                    return clsResult.Failure("Insert Failed");
                case clsEnums.enMode.enUpdate:
                    return _Update() ? 
                        clsResult.Success("Updated Successfully") : 
                        clsResult.Failure("Update Failed");
                default:
                    return clsResult.Failure("Invalid Mode");
            }
        }
    }
}
