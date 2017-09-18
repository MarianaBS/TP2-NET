using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
   public class AlumnoInscripcionLogic :BusinessLogic
    {
       private Data.Database.AlumnoInscripcionAdapter _AlumnoInscripcionData;
        public Data.Database.AlumnoInscripcionAdapter AlumnoInscripcionData 
        { 
            get {return _AlumnoInscripcionData;} 
            set {_AlumnoInscripcionData = value;} 
        }

        public AlumnoInscripcionLogic() 
       {
           AlumnoInscripcionData = new Data.Database.AlumnoInscripcionAdapter();
       }

        public List<AlumnoInscripcion> GetAll()
        {
            return AlumnoInscripcionData.GetAll();
        }
        public AlumnoInscripcion GetOne(int ID)
        {
            return AlumnoInscripcionData.GetOne(ID);
        }

        public void Save(AlumnoInscripcion d)
        {
            AlumnoInscripcionData.Save(d);
        }
        public void Delete(int ID)
        {
            AlumnoInscripcionData.Delete(ID);
        }
    }
}
