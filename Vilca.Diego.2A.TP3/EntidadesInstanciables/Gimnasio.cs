using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excepciones;
using Archivos;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
     [XmlInclude(typeof(Alumno))]
     [XmlInclude(typeof(Instructor))]
     [XmlInclude(typeof(Jornada))]
    public class Gimnasio
    {
        private List<Instructor> _instructores;
        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;

        
        #region Enumerados
        public enum EClases
        {
            CrossFit,
            Natacion,
            Pilates,
            Yoga
        }


        #endregion Enumerados


        #region Propiedades necesarias para serializar xml

        
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }

        }

        public List<Instructor> Instructores
        {
            get { return this._instructores; }

        }

        public List<Jornada> Jornada
        {
            get { return this._jornada; }

        }

        #endregion Propiedades necesarias para serializar xml


        #region Indexador

        public Jornada this[int i]
        {
            get
            {
                return this._jornada[i];
            }

        }
        #endregion Indexador


        #region Constructor

        public Gimnasio()
        {
            this._jornada = new List<Jornada>();
            this._instructores = new List<Instructor>();
            this._alumnos = new List<Alumno>();

        }

        #endregion Constructor


        #region Metodos

        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Jornada: ");


            for (int i = 0; i < gim._jornada.Count; i++)
            {
                sb.AppendLine(gim[i].ToString());
            }

            return sb.ToString();
        }


        public override string ToString()
        {

            return MostrarDatos(this);

        }

        public static bool Guardar(Gimnasio gim)
        {

            Xml<Gimnasio> miXml = new Xml<Gimnasio>();

            miXml.guardar("Gimnasio.xml", gim);

            return true;

            
        }


        public static Gimnasio Leer()
        {
            Xml<Gimnasio> miXml = new Xml<Gimnasio>();
            Gimnasio nuevoGimnasio;

            miXml.leer("Gimnasio.xml", out nuevoGimnasio);

            return nuevoGimnasio;
        }



        #endregion Metodos


        #region Sobrecargas

        public static bool operator ==(Gimnasio g, Alumno a)
        {
            foreach (Alumno item in g._alumnos)
            {
                if (item.Equals(a))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item == clase)
                {
                    return item;
                }
            }

            throw new SinInstructorException(); 
        }

        public static Instructor operator !=(Gimnasio g, EClases clase)
        {


            foreach (Instructor item in g._instructores)
            {
                if (item != clase)
                {
                    return item;
                }
            }

            return null;
        }

        public static bool operator ==(Gimnasio g, Instructor i)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item.Equals(i))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (g == a)
            {
                throw new AlumnoRepetidoException();
            }

            g._alumnos.Add(a);

            return g;
        }

        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            Jornada nuevaJornada = new Jornada(clase, g == clase);


            for (int i = 0; i < g._alumnos.Count; i++)
            {
                if (g._alumnos[i] == clase)
                {
                    nuevaJornada = nuevaJornada + g._alumnos[i];
                }
            }

            g._jornada.Add(nuevaJornada);

            return g;

        }

        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (g == i)
            {
                return g;
            }

            g._instructores.Add(i);

            return g;
        }

        #endregion Sobrecargas



    }
}
