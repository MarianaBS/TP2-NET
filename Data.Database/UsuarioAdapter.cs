using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;


namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {

        private static List<Usuario> _Usuarios;
        public List<Usuario> Usuarios {
            get {return _Usuarios ;}
            set { _Usuarios = value; }
        }
        public List<Usuario> GetAll()
        {
            //instaciamos el objeto lista a retornar
            Usuarios = new List<Usuario>();
            //abrimos la conexion a la base de datos con el metodo que creamos antes
            this.OpenConnection();

            /*
             * creamos un objeto SQLCommand que será la sentencia SQL
             * que vamos a ejecutar contra la base de datos
             * (los datos de la BD usuario,contraseña,servidor, etc.
             * están en el connection string)
             */
            SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", sqlConn);
            /*
             * instanciamos un objeto DataReader que será
             * el que recuperará los datos de la bd
             */
            SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

            /* 
             * Read() lee una fila de las devueltas por el comando sql
             * carga los datos en drUsuarios para poder accederlos,
             * devuelve verdadero mientras haya podido leer datos
             * y avanza a la fila siguiente para el próximo read
             */
            while (drUsuarios.Read())
            {
                /*
                 * creamos un objeto Usuario de la capa entidades para copiar 
                 * los datos de la fila del DATAReader al objeto de entidades
                 */
                Usuario usr = new Usuario();
                //ahora copiamos los datos de la fila al objeto
                usr.ID = (int)drUsuarios["id_usuario"];
                usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                usr.Clave = (string)drUsuarios["clave"];
                usr.Habilitado = (bool)drUsuarios["habilitado"];
                usr.Nombre = (string)drUsuarios["nombre"];
                usr.Apellido = (string)drUsuarios["apellido"];
                usr.Email = (string)drUsuarios["email"];
                //usr.CambiaClave = (bool)drUsuarios["cambia_clave"];
                usr.IDPersona = (int)drUsuarios["id_persona"];
                Usuarios.Add(usr);
            }
            //cerramos la coneccion
            drUsuarios.Close();
            this.CloseConnection();
            //devolvemos el objeto
            return Usuarios;

        }      

        public Business.Entities.Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("Select * from usuarios where id_usuario=@id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usr.IDPersona = (int)drUsuarios["id_persona"];
                    //usr.CambiaClave = (bool)drUsuarios["cambia_clave"];
                }
                drUsuarios.Close();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }
      
        public Boolean GetOne(string usuario,string pass)
        {
            Usuario usr = new Usuario();
            bool valida = false;
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuario = new SqlCommand("Select * from usuarios where nombre_usuario=@usuario and clave=@pass", sqlConn);
                cmdUsuario.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmdUsuario.Parameters.Add("@pass", SqlDbType.VarChar, 50).Value = pass;
                
                SqlDataReader drUsuario = cmdUsuario.ExecuteReader();
                if (drUsuario.Read())
                {
                    usr.ID = (int)drUsuario["id_usuario"];
                    usr.NombreUsuario = (string)drUsuario["nombre_usuario"];
                    usr.Clave = (string)drUsuario["clave"];
                    usr.Habilitado = (bool)drUsuario["habilitado"];
                    usr.Nombre = (string)drUsuario["nombre"];
                    usr.Apellido = (string)drUsuario["apellido"];
                    usr.Email = (string)drUsuario["email"];
                    usr.IDPersona = (int)drUsuario["id_persona"];
                    //usr.CambiaClave = (bool)drUsuario["cambia_clave"];
                    
                    valida = true;
                }
                drUsuario.Close();
                
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return valida;
        }
        public Usuario GetUser(string usuario, string pass)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuario = new SqlCommand("Select * from usuarios where nombre_usuario=@usuario and clave=@pass", sqlConn);
                cmdUsuario.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmdUsuario.Parameters.Add("@pass", SqlDbType.VarChar, 50).Value = pass;

                SqlDataReader drUsuario = cmdUsuario.ExecuteReader();
                if (drUsuario.Read())
                {
                    usr.ID = (int)drUsuario["id_usuario"];
                    usr.NombreUsuario = (string)drUsuario["nombre_usuario"];
                    usr.Clave = (string)drUsuario["clave"];
                    usr.Habilitado = (bool)drUsuario["habilitado"];
                    usr.Nombre = (string)drUsuario["nombre"];
                    usr.Apellido = (string)drUsuario["apellido"];
                    usr.Email = (string)drUsuario["email"];
                    usr.IDPersona = (int)drUsuario["id_persona"];
                    //usr.CambiaClave = (bool)drUsuario["cambia_clave"];  
                }
                drUsuario.Close();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }      
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("Delete usuarios where id_usuario=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar usuario", ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }       
        protected void Update(Usuario usuario)
        {
            try
            {  
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave, " +
                    "habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email,id_persona = @id_persona  WHERE id_usuario=@id", sqlConn); //cambia_clave = @cambia_clave, " 
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IDPersona;
                //cmdSave.Parameters.Add("@cambia_clave", SqlDbType.Bit).Value = usuario.CambiaClave;
                
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("Error al modificar datos de usuario", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }      
        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                //, cambia_clave,id_persona)"
                SqlCommand cmdSave = new SqlCommand("Insert into usuarios(nombre_usuario,clave,habilitado,nombre,apellido,email,id_persona)"  +
                    "values(@nombre_usuario,@clave,@habilitado,@nombre,@apellido,@email,@id_persona)" +
                    "Select @@identity", //esta linea es para recuperar el Id que asigno el sql automaticamente
                    sqlConn);
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                //cmdSave.Parameters.Add("@cambia_clave", SqlDbType.Bit).Value = usuario.CambiaClave;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IDPersona;
                usuario.ID = decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {

                Exception excepcionManejada = new Exception("Error al crear usuario", ex);
                throw excepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;            
        }
    }
    
}
