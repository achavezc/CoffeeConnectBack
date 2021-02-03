using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Logger
{
    public interface ILog
    {
        void RegistrarEvento(string message);
        void RegistrarEvento(List<string> values);
        void RegistrarEvento(ErrorMessage errorMessage, params string[] values);
        void RegistrarEvento(Exception ex, params string[] values);
        void RegistrarEvento(ServiceMessage serviceMessage, params string[] values);
    }
}
