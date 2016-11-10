using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;


namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {

        public bool guardar(string archivo, T datos)
        {
            
            try
            {

                using (XmlTextWriter escritor = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    serializador.Serialize(escritor, datos);

                    return true;
                }

            }
            catch (Exception ex)
            {

                throw new ArchivosException(ex);
            }

           
        }

        public bool leer(string archivo, out T datos)
        {
            try
            {

                using (XmlTextReader lector = new XmlTextReader(archivo))
                {

                    XmlSerializer deserializador = new XmlSerializer(typeof(T));
                    datos = (T)deserializador.Deserialize(lector);

                    return true;
                }

            }
            catch (Exception ex)
            {

                throw new ArchivosException(ex);
            }
        }
    }
}
