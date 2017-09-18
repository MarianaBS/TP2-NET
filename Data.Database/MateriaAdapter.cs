using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        private static List<Materia> _Materias;
        public List<Materia> Materias
        {
            get { return _Materias; }
            set { _Materias = value; }
        }
        public List<Materia> GetAll()
        {
            Materias = new List<Materia>();
            this.OpenConnection();
            SqlCommand cmdMaterias = new SqlCommand("select * from materias", sqlConn);
            SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
            while (drMaterias.Read())
            {
                Materia mat = new Materia();
                mat.ID = (int)drMaterias["id_materia"];
                mat.Descripcion = (string)drMaterias["desc_materia"];
                mat.HSSemanales = (int)drMaterias["hs_semanales"];
                mat.HSTotales = (int)drMaterias["hs_totales"];
                mat.IdPlan = (int)drMaterias["id_plan"];
                Materias.Add(mat);
            }
            drMaterias.Close();
            this.CloseConnection();

            return Materias;
        }

        public Business.Entities.Materia GetOne(int ID)
        {
            Materia mat = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("Select * from materias where id_materia=@id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdUsuarios.ExecuteReader();

                if (drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IdPlan = (int)drMaterias["id_plan"];
                }
                drMaterias.Close();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de materia", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mat;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("Delete materias where id_materia=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar materia", ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }        
        protected void Update(Materia mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET desc_materia = @desc_materia, hs_semanales = @hs_semanales , " +
                    "hs_totales = @hs_totales , id_plan = @id_plan WHERE id_materia=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = mat.ID;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = mat.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = mat.HSSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = mat.HSTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.IdPlan;              
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("Error al modificar datos de materia", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Materia mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("Insert into materias(desc_materia,hs_semanales,hs_totales,id_plan)" +
                    "values(@desc_materia,@hs_semanales,@hs_totales,@id_plan)" +
                    "Select @@identity", //esta linea es para recuperar el Id que asigno el sql automaticamente
                    sqlConn);

                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = mat.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = mat.HSSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = mat.HSTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.IdPlan;  
                mat.ID = decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {

                Exception excepcionManejada = new Exception("Error al crear materia", ex);
                throw excepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Materia mat)
        {
            if (mat.State == BusinessEntity.States.New)
            {
                this.Insert(mat);
            }
            else if (mat.State == BusinessEntity.States.Deleted)
            {
                this.Delete(mat.ID);
            }
            else if (mat.State == BusinessEntity.States.Modified)
            {
                this.Update(mat);
            }
            mat.State = BusinessEntity.States.Unmodified;
        }

    }
}
