using Empleado23CVAngel.Context;
using Empleado23CVAngel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleado23CVAngel.Services
{
    public class EmpleadoServices
    {
        public void Add(Empleado request)
        {
            try
            {   //Habre la cadena de conexion y todo lo que se encuentre en using entrará a la DB
                using (var _context = new ApplicationDbContext())
                {
                    Empleado empleado = new Empleado()
                    {
                        Nombre = request.Nombre,
                        Apellido = request.Apellido,
                        Correo = request.Correo,
                        FechaRegistro = DateTime.Now,
                    };
                    _context.Empleados.Add(empleado);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        public Empleado Red(int Id)
        {
            try
            {
                Empleado empleado = new Empleado();
                using (var _context = new ApplicationDbContext())
                {
                    empleado = _context.Empleados.Find(Id);
                    return empleado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: " + ex.Message);
            }
        }
    }
}
/*hacer botton resetear los campos*/