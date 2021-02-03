using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Logger
{
    public class WriterText
    {
        static readonly object _locker = new object();

        public void RegistrarEvento(string ruta, string mensaje)
        {
            try
            {
                lock (_locker)
                {
                    StreamWriter log;

                    if (!File.Exists(ruta))
                        log = new StreamWriter(ruta, true, Encoding.Default);
                    else
                        log = File.AppendText(ruta);

                    using (log)
                    {
                        log.WriteLine(mensaje);
                        log.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //LogEntry Event Windows
            }
        }
    }
}
