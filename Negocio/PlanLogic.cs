using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
         private Data.Database.PlanAdapter _PlanData;
        public Data.Database.PlanAdapter  PlanData
        { 
            get {return _PlanData;} 
            set {_PlanData = value;} 
        }
        
       public PlanLogic() 
       {
           PlanData = new Data.Database.PlanAdapter();
       }
        
        public List <Plan> GetAll()
        {
            return PlanData.GetAll();
        }
        public Plan GetOne(int ID)
        {
            return PlanData.GetOne(ID);
        }

        public void Save(Plan a)
        {
            PlanData.Save(a);
        }
        public void Delete(int ID)
        {
            PlanData.Delete(ID);
        }
    }
}
