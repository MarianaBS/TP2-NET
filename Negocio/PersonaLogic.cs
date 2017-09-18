using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {

        private Data.Database.PersonaAdapter _PersonaData;
        public Data.Database.PersonaAdapter PersonaData
        {
            get { return _PersonaData; }
            set { _PersonaData = value; }
        }

        public PersonaLogic()
        {
            PersonaData = new Data.Database.PersonaAdapter();
        }

        public List<Persona> GetAll()
        {
            return PersonaData.GetAll();
        }
        public Persona GetOne(int ID)
        {
            return PersonaData.GetOne(ID);
        }
       
        public void Save(Persona w)
        {
            PersonaData.Save(w);
        }
        public void Delete(int ID)
        {
            PersonaData.Delete(ID);
        }
    }
}
