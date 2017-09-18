using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;


namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
        private static List<Curso> _Curso;

        public List<Curso> Curso
        {
            get { return _Curso; }
            set { _Curso = value; }
        }
        public List<Curso> GetAll()
        {

            Curso = new List<Curso>();

            this.OpenConnection();

            /*
             * creamos un objeto SQLCommand que será la sentencia SQL
             * que vamos a ejecutar contra la base de datos
             * (los datos de la BD usuario,contraseña,servidor, etc.
             * están en el connection string)
             */
            SqlCommand cmdCurso = new SqlCommand("select * from cursos", sqlConn);
            /*
             * instanciamos un objeto DataReader que será
             * el que recuperará los datos de la bd
             */
            SqlDataReader drCurso = cmdCurso.ExecuteReader();

            /* 
             * Read() lee una fila de las devueltas por el comando sql
             * carga los datos en drCurso para poder accederlos,
             * devuelve verdadero mientras haya podido leer datos
             * y avanza a la fila siguiente para el próximo read
             */
            while (drCurso.Read())
            {
                /*
                 * creamos un objeto Curso de la capa entidades para copiar 
                 * los datos de la fila del DATAReader al objeto de entidades
                 */
                Curso cr = new Curso();
                //ahora copiamos los datos de la fila al objeto
                cr.ID = (int)drCurso["id_curso"];
                cr.Cupo = (int)drCurso["cupo"];
                cr.IDComision = (int)drCurso["id_comision"];
                cr.IDMateria = (int)drCurso["id_materia"];
                cr.AnioCalendario = (int)drCurso["anio_calendario"];
                Curso.Add(cr);
            }
            //cerramos la coneccion
            drCurso.Close();
            this.CloseConnection();
            //devolvemos el objeto
            return Curso;

        }
        public Business.Entities.Curso GetOne(int ID)
        {
            Curso cr = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("Select * from cursos where id_curso=@id", sqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCurso = cmdCurso.ExecuteReader();

                if (drCurso.Read())
                {
                    cr.ID = (int)drCurso["id_curso"];
                    cr.Cupo = (int)drCurso["cupo"];
                    cr.IDComision = (int)drCurso["id_comision"];
                    cr.IDMateria = (int)drCurso["id_materia"];
                    cr.AnioCalendario = (int)drCurso["anio_calendario"];
                }
                drCurso.Close();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de Curso", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cr;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("Delete cursos where id_curso=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar curso", ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Curso curso)
        {
            try
            {

                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET cupo = @cupo,  id_comision= @id_comision, " +
                    " id_materia = @id_materia,anio_calendario = @anio_calendario " +
                    "WHERE id_curso=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("Error al modificar datos de Curso", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("Insert into cursos(cupo,id_comision,id_materia,anio_calendario)" +
                    "values(@cupo,@id_comision,@id_materia,@anio_calendario)" +
                    "Select @@identity", //esta linea es para recuperar el Id que asigno el sql automaticamente
                    sqlConn);
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                curso.ID = decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {

                Exception excepcionManejada = new Exception("Error al crear curso", ex);
                throw excepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }
    }
}
