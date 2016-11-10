using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excepciones;
using Archivos;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    
    
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;


        #region Propiedades necesarias para serializar el xml
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            
        }

        public Gimnasio.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }
        
        public Instructor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }
        #endregion Propiedades necesarias para serializar el xml


        #region Constructores

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        #endregion Constructores


        #region Metodos

        public static bool Guardar(Jornada jornada)
        {

            Texto mitexto = new Texto();

            mitexto.guardar("Jornada.txt", jornada.ToString());

            return true;

        }

        public static string Leer()
        {

            Texto miTexto = new Texto();
            string contenido;

            miTexto.leer("Jornada.txt", out contenido);

            return contenido;

        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASE DE " + this._clase.ToString() + " POR " + this._instructor.ToString());

            sb.AppendLine("ALUMNOS: ");

            foreach (Alumno item in this._alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            sb.AppendLine("<------------------------------------------------>");

            return sb.ToString();
        }

        #endregion Metodos


        #region Sobrecargas

        public static bool operator ==(Jornada j, Alumno a)
        {
            if (!(a != j._clase))
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
            {
                j._alumnos.Add(a);
            }


            return j;
        }

        #endregion Sobrecargas
    }
}
