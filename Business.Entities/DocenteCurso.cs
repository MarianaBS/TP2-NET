using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        private int _IDCurso; 
        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; } 
        }
        private int _IDDocente;
        public int IDDocente
        {
            get { return _IDDocente ;}
            set { _IDDocente = value; }
        }
        
        private TiposCargos _TiposCargos;
        public TiposCargos TiposCargo
        {
            get { return _TiposCargos; }
            set { _TiposCargos = value ; }
        }

        public enum TiposCargos
        {
            Titular,
            Auxiliar,
        }
    }
}
