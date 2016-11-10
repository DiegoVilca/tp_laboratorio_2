using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excepciones;


namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        public bool guardar(string archivo, string datos)
        {
            StreamWriter escritor = null;
            bool bandera = false;

            try
            {
                escritor = new StreamWriter(archivo, true);

                escritor.WriteLine(datos);

                bandera = true;
            }
            catch (Exception ex)
            {

                throw new ArchivosException(ex);
            }
            finally
            {
                escritor.Close();
            }

            return bandera;
        }

        public bool leer(string archivo, out string datos)
        {
            StreamReader lector = null;
            bool bandera = false;

            try
            {
                lector = new StreamReader(archivo, true);

                datos = lector.ReadToEnd();

                bandera = true;
            }
            catch (Exception ex)
            {

                throw new ArchivosException(ex);
            }
            finally
            {
                lector.Close();
            }

            return bandera;

            
        }
    }
}
