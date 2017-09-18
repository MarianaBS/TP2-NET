using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {
        private Data.Database.DocenteCursoAdapter _DcData;
        public Data.Database.DocenteCursoAdapter DcData 
        {
            get { return _DcData; }
            set { _DcData = value; } 
        }

       public DocenteCursoLogic() 
       {
           DcData = new Data.Database.DocenteCursoAdapter();
       }
        
        public List <DocenteCurso> GetAll()
        {
            return DcData.GetAll();
        }
        public DocenteCurso GetOne(int ID)
        {
            return DcData.GetOne(ID);
        }

        public void Save(DocenteCurso a)
        {
            DcData.Save(a);
        }
        public void Delete(int ID)
        {
            DcData.Delete(ID);
        }
    }
}
