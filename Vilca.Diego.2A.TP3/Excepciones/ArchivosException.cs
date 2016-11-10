﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException)
            : base("Se ha producido un error con el archivo", innerException)
        {
            Console.WriteLine(innerException.Message);
            Console.WriteLine(innerException.InnerException.Message);
            
        }
    }
}
