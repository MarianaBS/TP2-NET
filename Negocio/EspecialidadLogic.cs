using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        private Data.Database.EspecialidadesAdapter _espData;
        public Data.Database.EspecialidadesAdapter espData
        { 
            get {return _espData;} 
            set {_espData = value;} 
        }
        
       public EspecialidadLogic() 
       {
           espData = new Data.Database.EspecialidadesAdapter();
       }
        
        public List <Especialidad> GetAll()
        {
            return espData.GetAll();
        }
        public Especialidad GetOne(int ID)
        {
            return espData.GetOne(ID);
        }

        public void Save(Especialidad a)
        {
            espData.Save(a);
        }
        public void Delete(int ID)
        {
            espData.Delete(ID);
        }
    }
}
