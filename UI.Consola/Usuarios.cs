using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {
        private UsuarioLogic _UsuarioNegocio;
        
        public UsuarioLogic UsuarioNegocio 
        {
            get {return _UsuarioNegocio ;}
            set {_UsuarioNegocio = value ; }
        }
        
        public Usuarios()
        {
            _UsuarioNegocio = new UsuarioLogic();
        }

        public void Menu()
        {
            
            string op;
            do
            {
                Console.Clear();
                Console.WriteLine("1– Listado General");
                Console.WriteLine("2– Consulta");
                Console.WriteLine("3– Agregar");
                Console.WriteLine("4- Modificar");
                Console.WriteLine("5- Eliminar");
                Console.WriteLine("6- Salir");
                Console.Write("Opcion Elegida:");
                op = Console.ReadLine();
                switch (op)
                {
                case "1": ListadoGeneral();
                    break;
                case "2": Consultar();
                    break;
                case "3": Agregar();
                    break;
                case "4": Modificar();
                    break;
                case "5": Eliminar();
                    break; 
                case "6": Console.WriteLine("fin");
                    break;
                default: Console.WriteLine("error");
                    break;
                }
            } while (op != "6");
        }
        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr); 
            }
            Console.ReadKey();
        }
        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese ID de usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
           
        }
        public void Agregar()
        {
            
          Usuario usuario = new Usuario();

          Console.Clear();
          Console.Write("ingrese Nombre:");
          usuario.Nombre = Console.ReadLine();
          Console.Write("ingrese Apellido:");
          usuario.Apellido = Console.ReadLine();
          Console.Write("ingrese Nombre de usuario:");
          usuario.NombreUsuario = Console.ReadLine();
          Console.Write("ingrese Clave:");
          usuario.Clave = Console.ReadLine();
          Console.Write("ingrese Email:");
          usuario.Email = Console.ReadLine();
          Console.Write("Ingrese Habilitacion de usuario (1-SI/2-NO):");
          usuario.Habilitado = (Console.ReadLine() == "1");
          usuario.State = BusinessEntity.States.New;
          UsuarioNegocio.Save(usuario);
          Console.WriteLine();
          Console.WriteLine("ID: {0}",usuario.ID);
           
        
        }
        public void Modificar()
        {
          try
          {
              Console.Clear();
              Console.Write("ingrese ID de usuario a modificar:");
              int ID = int.Parse(Console.ReadLine());
              Usuario usuario = UsuarioNegocio.GetOne(ID);
              Console.Write("ingrese Nombre:");
              usuario.Nombre = Console.ReadLine();
              Console.Write("ingrese Apellido:");
              usuario.Apellido = Console.ReadLine();
              Console.Write("ingrese Nombre de usuario:");
              usuario.NombreUsuario = Console.ReadLine();
              Console.Write("ingrese Clave:");
              usuario.Clave = Console.ReadLine();
              Console.Write("ingrese Email:");
              usuario.Email = Console.ReadLine();
              Console.Write("Ingrese Habilitacion de usuario (1-SI/2-NO):");
              usuario.Habilitado = (Console.ReadLine() == "1");
              usuario.State = BusinessEntity.States.Modified;
              UsuarioNegocio.Save(usuario);
          }
          catch (FormatException)
          {
              Console.WriteLine("La ID ingresada debe ser un numero entero"); 
          }
          catch (Exception e)
          {
              Console.WriteLine();
              Console.WriteLine(e.Message);
          }
          finally
          {
              Console.WriteLine("Presione una tecla para continuar");
              Console.ReadKey();
          }
        }
        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("ingrese el ID del usuario a eliminar");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero"); 
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
           
        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.WriteLine();
        }
        
    
   }
}
