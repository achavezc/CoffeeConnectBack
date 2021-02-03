using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Logger
{
    public class Log : ILog
    {
        public void RegistrarEvento(string message)
        {
            (new LogText()).RegistrarEvento(message);
        }

        public void RegistrarEvento(List<string> values)
        {
            (new LogText()).RegistrarEvento(values);
        }

        public void RegistrarEvento(ErrorMessage errorMessage, params string[] values)
        {
            (new LogText()).RegistrarEvento(errorMessage, values);
        }

        public void RegistrarEvento(Exception ex, params string[] values)
        {
            (new LogText()).RegistrarEvento(ex, values);
        }

        public void RegistrarEvento(ServiceMessage serviceMessage, params string[] values)
        {
            (new LogText()).RegistrarEvento(serviceMessage);
        }
    }
}
