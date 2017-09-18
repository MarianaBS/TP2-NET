using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ModuloLogic : BusinessLogic
    {
        private Data.Database.ModuloAdapter _ModuloData;
        public Data.Database.ModuloAdapter ModuloData 
        { 
            get {return _ModuloData;} 
            set {_ModuloData = value;} 
        }
        
       public ModuloLogic() 
       {
           ModuloData = new Data.Database.ModuloAdapter();
       }

       public List<Modulo> GetAll()
        {
            return ModuloData.GetAll();
        }
       public Modulo GetOne(int ID)
        {
            return ModuloData.GetOne(ID);
        }
       public void Save(Modulo a)
        {
            ModuloData.Save(a);
        }
        public void Delete(int ID)
        {
            ModuloData.Delete(ID);
        }

    }
}
