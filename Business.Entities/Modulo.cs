using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Modulo : BusinessEntity
    {
        private String _Descripcion;
        private String _Ejecuta;
        public String Ejecuta 
        {
            get { return _Ejecuta;}
            set { _Ejecuta = value;} 
        }
        public String Descripcion
        {
            get { return _Descripcion;}
            set { _Descripcion = value;} 
        }

    
    }
}
