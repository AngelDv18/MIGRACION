using Empleado23CVAngel.Context;
using Empleado23CVAngel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public Empleado Read(int Id)
        {
            try
            {

                using (var _context = new ApplicationDbContext())
                {
                    Empleado empleado = _context.Empleados.Find(Id);
                    return empleado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un Error: " + ex.Message);
            }
        }
        public void Update(Empleado empleado)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    _context.Entry(empleado).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error al actualizar el empleado: " + ex.Message);
            }
        }
        public bool Delete(int Id)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Empleado empleado = _context.Empleados.Find(Id);
                    if (empleado != null)
                    {
                        _context.Empleados.Remove(empleado);
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }
    }
}
/*hacer botton resetear los campos*/