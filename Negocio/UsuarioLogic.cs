using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        
        private Data.Database.UsuarioAdapter _UsuarioData;
        public Data.Database.UsuarioAdapter UsuarioData 
        { 
            get {return _UsuarioData;} 
            set {_UsuarioData = value;} 
        }
        
       public UsuarioLogic() 
       {
           _UsuarioData = new Data.Database.UsuarioAdapter();
       }
        
        public List <Usuario> GetAll()
        {
            return _UsuarioData.GetAll();
        }
        public Usuario GetOne(int ID)
        {
            return _UsuarioData.GetOne(ID);
        }
        public Boolean GetOne(string usuario, string pass)
        {
            return _UsuarioData.GetOne(usuario, pass);
        }
        public Usuario GetUser(string usuario, string pass)
        {
            return _UsuarioData.GetUser(usuario, pass);
        }

        public void Save(Usuario a)
        {
            _UsuarioData.Save(a);
        }
        public void Delete(int ID)
        {
            _UsuarioData.Delete(ID);
        }
    }
}
