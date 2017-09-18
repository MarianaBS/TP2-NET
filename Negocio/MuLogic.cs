using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MuLogic : BusinessLogic
    {
        private Data.Database.MuAdapter _MuData;
        public Data.Database.MuAdapter MuData 
        { 
            get {return _MuData;} 
            set {_MuData = value;} 
        }
        
       public MuLogic() 
       {
           MuData = new Data.Database.MuAdapter();
       }
        
        public List <ModuloUsuario> GetAll()
        {
            return MuData.GetAll();
        }
        public ModuloUsuario GetOne(int ID)
        {
            return MuData.GetOne(ID);
        }

        public void Save(ModuloUsuario a)
        {
            MuData.Save(a);
        }
        public void Delete(int ID)
        {
            MuData.Delete(ID);
        }
    }
}
