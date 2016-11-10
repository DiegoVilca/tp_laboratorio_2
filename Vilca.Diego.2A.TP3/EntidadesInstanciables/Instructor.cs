using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    
    
    public sealed class Instructor : PersonaGimnasio
    {

        private Queue<Gimnasio.EClases> _claseDelDia;
        private static Random _random;

        #region Constructores

        static Instructor()
        {
            _random = new Random();
        }


        //Constructor por defecto necesario para serializar xml
        private Instructor()
        {

        }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseDelDia = new Queue<Gimnasio.EClases>();

            this._randomClases();
            this._randomClases();
        }

        #endregion Constructores


        #region Sobrecargas

        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            foreach (Gimnasio.EClases item in i._claseDelDia)
            {
                if (item == clase)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }


        #endregion Sobrecargas


        #region Metodos

        private void _randomClases()
        {
            this._claseDelDia.Enqueue((Gimnasio.EClases)_random.Next(0, 3));
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");

            foreach (Gimnasio.EClases item in this._claseDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();

        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion Metodos

    }
}
