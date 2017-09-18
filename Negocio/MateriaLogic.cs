using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        private Data.Database.MateriaAdapter _MateriaData;
        public Data.Database.MateriaAdapter MateriaData
        { 
            get {return _MateriaData;} 
            set {_MateriaData = value;} 
        }
        
       public MateriaLogic() 
       {
           MateriaData = new Data.Database.MateriaAdapter();
       }

       public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }
        public Materia GetOne(int ID)
        {
            return MateriaData.GetOne(ID);
        }
        public void Save(Materia a)
        {
            MateriaData.Save(a);
        }
        public void Delete(int ID)
        {
            MateriaData.Delete(ID);
        }
    }
}
