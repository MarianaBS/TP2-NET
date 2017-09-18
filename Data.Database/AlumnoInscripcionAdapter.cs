using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter :Adapter
    {
   
        private static List<AlumnoInscripcion> _AlumnoInscripcion;

        public List<AlumnoInscripcion> AlumnoInscripcion
        {
            get { return _AlumnoInscripcion; }
            set { _AlumnoInscripcion = value; }
        }

        public List<AlumnoInscripcion> GetAll()
        {

            AlumnoInscripcion = new List<AlumnoInscripcion>();

            this.OpenConnection();

            SqlCommand cmdAlumnoInscripcion = new SqlCommand("select * from alumnos_inscripciones", sqlConn);
          
            SqlDataReader drAlumnoInscripcion = cmdAlumnoInscripcion .ExecuteReader();

            while (drAlumnoInscripcion.Read())
            {
             
                AlumnoInscripcion ai = new AlumnoInscripcion();

                ai.ID = (int)drAlumnoInscripcion["id_inscripcion"];
                ai.IDAlumno = (int)drAlumnoInscripcion["id_alumno"];
                ai.IDCurso = (int)drAlumnoInscripcion["id_curso"];
                ai.Condicion = (string)drAlumnoInscripcion["condicion"];
                ai.Nota = (int)drAlumnoInscripcion["nota"];
                AlumnoInscripcion.Add(ai);
            }

            drAlumnoInscripcion.Close();
            this.CloseConnection();

            return AlumnoInscripcion;

        }

        public Business.Entities.AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion ai = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnoInscripcion = new SqlCommand("Select * from alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdAlumnoInscripcion.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnoInscripcion = cmdAlumnoInscripcion.ExecuteReader();

                if (drAlumnoInscripcion.Read())
                {
                    ai.ID = (int)drAlumnoInscripcion["id_inscripcion"];
                    ai.IDAlumno = (int)drAlumnoInscripcion["id_alumno"];
                    ai.IDCurso = (int)drAlumnoInscripcion["id_curso"];
                    ai.Condicion = (string)drAlumnoInscripcion["condicion"];
                    ai.Nota = (int)drAlumnoInscripcion["nota"];
                }
                drAlumnoInscripcion.Close();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos en inscripciones", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return ai;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("Delete alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar inscripcion", ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(AlumnoInscripcion alumnoInscripcion)
        {
            try
            {

                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones SET id_alumno = @id_alumno,  id_curso= @id_curso, " +
                    " condicion= @condicion,  nota= @nota " +
                    "WHERE id_inscripcion=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = alumnoInscripcion.ID;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumnoInscripcion.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumnoInscripcion.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumnoInscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alumnoInscripcion.Nota;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("Error al modificar datos de Inscripciones", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(AlumnoInscripcion alumnoInscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("Insert into alumnos_inscripciones(id_alumno,id_curso,condicion,nota) " +
                    "values(@id_alumno,@id_curso,@condicion,@nota) " +
                    "Select @@identity", 
                    sqlConn);
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumnoInscripcion.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumnoInscripcion.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumnoInscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alumnoInscripcion.Nota;
                alumnoInscripcion.ID = decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {

                Exception excepcionManejada = new Exception("Error al crear la inscripcion", ex);
                throw excepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion alumnoInscripcion)
        {
            if (alumnoInscripcion.State == BusinessEntity.States.New)
            {
                this.Insert(alumnoInscripcion);
            }
            else if (alumnoInscripcion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(alumnoInscripcion.ID);
            }
            else if (alumnoInscripcion.State == BusinessEntity.States.Modified)
            {
                this.Update(alumnoInscripcion);
            }
            alumnoInscripcion.State = BusinessEntity.States.Unmodified;
        }

    }
}
