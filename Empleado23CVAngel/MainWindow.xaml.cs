using Empleado23CVAngel.Entities;
using Empleado23CVAngel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Empleado23CVAngel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        EmpleadoServices services = new EmpleadoServices();
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = new Empleado()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Correo = txtCorreo.Text,
                FechaRegistro = DateTime.Now,
            };
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("FALTAN CAMPOS POR LLENAR");
            }
            else
            {
                services.Add(empleado);
                txtNombre.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
                MessageBox.Show("REGISTRO EXITOSO");
            }
        }
        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {    //int Id = int.Parse(txtId.Text);
            //Empleado empleado = services.Read(Id);
            int Id;
            if (int.TryParse(txtId.Text, out Id))
            {
                Empleado empleado = services.Read(Id);
                if (empleado != null)
                { // Mostrar la información del empleado en controles de texto
                    txtNombre.Text = empleado.Nombre;
                    txtApellido.Text = empleado.Apellido;
                    txtCorreo.Text = empleado.Correo;
                    txtFecha.Text = empleado.FechaRegistro.ToString();
                    // Otros campos si los hay

                    // Puedes mostrar un mensaje de éxito si lo deseas
                    MessageBox.Show("Empleado encontrado");
                }
                else
                {  // Mostrar un mensaje si el empleado no se encontró
                    MessageBox.Show("Empleado no encontrado");
                }
            }
            else
            { // Mostrar un mensaje de error si el valor del Id no es un número válido
                MessageBox.Show("Ingrese un valor numérico válido para el Id");
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (int.TryParse(txtId.Text, out id))
            {
                Empleado empleadoExistente = services.Read(id);
                if (empleadoExistente != null)
                {
                    empleadoExistente.Nombre = txtNombre.Text;
                    empleadoExistente.Apellido = txtApellido.Text;
                    empleadoExistente.Correo = txtCorreo.Text;
                    services.Update(empleadoExistente);
                    MessageBox.Show("Empleado actualizado exitosamente");
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtCorreo.Clear();
                    txtFecha.Clear();
                }
                else
                {
                    MessageBox.Show("Empleado no encontrado");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido para el Id");
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int Id;
            if (int.TryParse(txtId.Text, out Id))
            {
                if (MessageBox.Show("¿Estás seguro de que deseas eliminar este empleado?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    bool result = services.Delete(Id);
                    if (result)
                    {
                        // Limpiar los controles de texto
                        txtNombre.Clear();
                        txtApellido.Clear();
                        txtCorreo.Clear();
                        txtFecha.Clear();

                        MessageBox.Show("Empleado eliminado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el empleado");
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido para el Id");
            }
        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtFecha.Clear();
        }
    }
}