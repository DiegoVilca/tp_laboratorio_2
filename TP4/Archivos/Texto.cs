using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string archivo;
        public Texto(string archivo)
        {
            this.archivo = archivo;
        }

        public bool guardar(string datos)
        {
            bool bandera = true;
            StreamWriter escritor = null; 

            try
            {
                escritor = new StreamWriter(this.archivo, true);  
                escritor.WriteLine(datos);              


                bandera = true;
            }
            catch (Exception)
            {

                bandera = false;
            }
            finally
            {
                escritor.Close();
            }

            return bandera;
        }

        public bool leer(out List<string> datos)
        {
            bool bandera;
            datos = new List<string>();

            try
            {
                using (StreamReader lector = new StreamReader(this.archivo))  
                {
                    while (!lector.EndOfStream)
                    {
                        datos.Add(lector.ReadLine());
                    }

                    bandera = true;
                }

            }
            catch (Exception)
            {
                bandera = false;
            }

            return bandera;
        }
    }
}
