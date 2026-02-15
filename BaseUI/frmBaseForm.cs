using Core;
using LL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseControls
{
    public partial class frmBaseForm : Form
    {
        public frmBaseForm()
        {
            InitializeComponent();
        }

        protected void _ShowMessage(string Message, clsEnums.enMessageType Type)
        {
            MessageBoxIcon Icon = MessageBoxIcon.Information;

            switch (Type)
            {
                case clsEnums.enMessageType.enError:
                    Icon = MessageBoxIcon.Error;
                    break;
                case clsEnums.enMessageType.enWarning:
                    Icon = MessageBoxIcon.Warning;
                    break;
                case clsEnums.enMessageType.enSuccess:
                    Icon = MessageBoxIcon.Information;
                    break;
            }

            MessageBox.Show(Message, "System", MessageBoxButtons.OK, Icon);
        }

        protected void _ShowResult(clsResult Result)
        {
            if (Result.IsSuccess)
            {
                _ShowMessage(Result.Message, clsEnums.enMessageType.enSuccess);
            }
            else
            {
                _ShowMessage(Result.Message, clsEnums.enMessageType.enError);
            }
        }

        protected void ExecuteSafely(clsResult Result)
        {
            try
            {
                _ShowResult(Result);
            }
            catch(Exception ex)
            {
                Logger.LogError("Unhandled UI Exception", ex);
                _ShowMessage("Unexcepted error occurred",
                    clsEnums.enMessageType.enError);
            }
        }
    }
}
