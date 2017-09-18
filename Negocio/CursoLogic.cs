using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
     public class CursoLogic : BusinessLogic
    {
         private Data.Database.CursoAdapter _CursoData;
        public Data.Database.CursoAdapter CursoData 
        { 
            get {return _CursoData;} 
            set {_CursoData = value;} 
        }
        
       public CursoLogic() 
       {
           CursoData = new Data.Database.CursoAdapter();
       }
        
        public List <Curso> GetAll()
        {
            return CursoData.GetAll();
        }
        public Curso GetOne(int ID)
        {
            return CursoData.GetOne(ID);
        }
        
        public void Save(Curso c)
        {
            CursoData.Save(c);
        }
        public void Delete(int ID)
        {
            CursoData.Delete(ID);
        }
    }
}
