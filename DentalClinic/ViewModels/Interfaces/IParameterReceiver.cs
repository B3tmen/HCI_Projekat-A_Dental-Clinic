using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Interfaces
{
    public interface IParameterReceiver
    {
        void OnReceiveParameter(object parameter);
    }
}
