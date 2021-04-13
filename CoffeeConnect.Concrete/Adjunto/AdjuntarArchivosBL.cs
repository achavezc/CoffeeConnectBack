using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using System.IO.IsolatedStorage;
using CoffeeConnect.DTO.Adjunto;

namespace CoffeeConnect.Service.Adjunto
{
    public class AdjuntarArchivosBL
    {

        private String getRutaFisica()
        {
            //return Helper.GetAppSetting("RUTAFISICA");
            //return "D:\\COMPARTIDO\\ArchivosDemo";
            return "D:\\COMPARTIDO\\ArchivosDemo";
        }

        public String getRutaLogica()
        {
            return "/AdjuntarArchivos/Descarga?Archivo=";
        }

        private String getNombreInterno(String FileName)
        {
            FileName = FileName.Replace(" ", "");
            String aleatorio = Math.Round(new Random().NextDouble() * 99999999, 0).ToString();
            String nuevofile = DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + aleatorio + FileName;
            return nuevofile;
        }

        public ResponseAdjuntarArchivoDTO AgregarArchivo(RequestAdjuntarArchivosDTO request)
        {
            var filtro = request.filtros;

            try
            {
                if (filtro.archivoStream.Length > 0)
                {
                    var fileName = Path.GetFileName(filtro.filename);
                    //filtro.filename = fileName;
                    //la ruta fisica donde se guardará
                    String nombreInterno = getNombreInterno(fileName);
                    String rutaReal = Path.Combine(getRutaFisica(), nombreInterno);

                    var memoryStream = new MemoryStream(filtro.archivoStream);

                    //----------------------------------------------------
                    try
                    {
                        FileStream file = new FileStream(rutaReal, FileMode.Create, System.IO.FileAccess.Write);
                        byte[] bytes = new byte[memoryStream.Length];
                        memoryStream.Read(bytes, 0, (int)memoryStream.Length);
                        file.Write(bytes, 0, bytes.Length);
                        file.Close();
                        memoryStream.Close();

                        return new ResponseAdjuntarArchivoDTO()
                        {
                            error = "",
                            ficheroReal = nombreInterno,
                            ficheroVisual = filtro.filename,
                            link = getRutaLogica() + "" + nombreInterno
                        };
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    //----------------------------------------------------
                }
                else
                {
                    return new ResponseAdjuntarArchivoDTO()
                    {
                        error = "El archivo no es válido o es corrupto",
                        ficheroReal = filtro.filename,
                        ficheroVisual = filtro.filename
                    };
                }
            }
            catch (Exception ex)
            {
              
                throw ex;
            }
        }

        public ResponseEliminarAdjuntarArchivoDTO EliminarArchivo(EliminarArchivoAdjuntoDTO request)
        {
            var filtro = request;
            String error = "";
            foreach (var item in request.Archivos)
            {
                try
                {
                    //String nombreInterno = getNombreInterno(request.SociedadPropietaria, item);
                    String rutaReal = Path.Combine(getRutaFisica(), item);

                    System.IO.File.Delete(rutaReal);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return new ResponseEliminarAdjuntarArchivoDTO()
            {
                Archivos = request.Archivos,
                error = error
            };
        }

        public ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request)
        {
            try
            {
                //using (var Contexto = new ContextoParaBaseDatos())
                //{
                //RepositorioDocumentoAdjunto repo = new RepositorioDocumentoAdjunto(Contexto);
                //var registro = repo.ObtenerPorFicheroVisual(request.ArchivoVisual);
                String rutaReal = Path.Combine(getRutaFisica(), request.ArchivoVisual.Replace("\\", ""));

                if (File.Exists(rutaReal))
                {

                    Byte[] archivoBytes = System.IO.File.ReadAllBytes(rutaReal);
                    return new ResponseDescargarArchivoDTO()
                    {
                        archivoBytes = archivoBytes,
                        errores = new Dictionary<string, string>(),
                        ficheroVisual = request.ArchivoVisual
                    };
                }
                else
                {
                    var resp = new ResponseDescargarArchivoDTO()
                    {
                        archivoBytes = null,
                        errores = new Dictionary<string, string>(),
                        ficheroVisual = ""
                    };
                    resp.errores.Add("Error", "El Archivo solicitado no existe");
                    return resp;
                }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
