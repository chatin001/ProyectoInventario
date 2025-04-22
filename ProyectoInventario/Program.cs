
using ProyectoInventario.Modelos;

namespace ProyectoInventario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Sistema de Inventario ===== \n");


            SistemaInventario sistema = new SistemaInventario();
            CargarDatosIniciales(sistema); // va cargar todos los Datos que vamos a necesitar

            // Menu de entrada
            bool salir = false;

            while (!salir)
            {
                // Menú
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n  MENÚ PRINCIPAL\n");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("  [1] Gestión de Empleados");
                Console.WriteLine("  [2] Gestión de Productos");
                Console.WriteLine("  [3] Movimientos de Stock");
                Console.WriteLine("  [4] Reportes e Informes");
                Console.WriteLine("  [0] Salir\n");


                Console.WriteLine("\nSeleciones una opcion");


                try
                {
                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            GestionEmpleados(sistema);
                            break;

                        case 2:
                            // GestionProductos(sistema);
                            break;
                        case 3:
                            // MovimientosStock(sistema);
                            break;
                        case 4:
                            //MostrarReportes(sistema);
                            break;
                        case 0:
                            salir = true;
                            break;
                        default:
                             Console.WriteLine("Opcion invalida");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        
        }

        //***************************************************************//
        static void GestionEmpleados(SistemaInventario sistema)
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;

                string titulo = "GESTIÓN DE EMPLEADOS";

                Console.WriteLine(titulo);



                Console.WriteLine("\n  MENU DE EMPLEADOS\n");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("  [1] Agregar Nuevo Empleado");
                Console.WriteLine("  [2] Buscar Empleado");
                Console.WriteLine("  [3] Listar Todos los Empleados");
                Console.WriteLine("  [4] Modificar Empleado");
                Console.WriteLine("  [5] Cambiar Estado de Empleado");
                Console.WriteLine("  [6] Gestión de Tipos de Empleado");
                Console.WriteLine("  [0] Volver al Menú Principal\n");


                try
                {
                    ConsoleKeyInfo tecla = Console.ReadKey(true);

                    switch (tecla.KeyChar)
                    {
                        case '1':
                            //AgregarEmpleado(sistema);
                            break;
                        case '2':
                            //BuscarEmpleado(sistema);
                            break;
                        case '3':
                            // ListarEmpleados(sistema);
                            break;
                        case '4':
                            //ModificarEmpleado(sistema);
                            break;
                        case '5':
                            // CambiarEstadoEmpleado(sistema);
                            break;
                        case '6':
                            //GestionTiposEmpleado(sistema);
                            break;
                        case '0':
                            volver = true;
                            break;
                        default:
                            Console.WriteLine("Opcion invalida");
                            break;
                    }
                } 
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
        }




        static void CargarDatosIniciales(SistemaInventario sistema)
        {
            //Agregar tipos empleados
            var tipoAdmin = new TipoEmpleado { Nombres = "Administrador", Descripcion = "Acceso total al Sistema" };
            var tipoAlmacen = new TipoEmpleado { Nombres = "Almacenero", Descripcion = "Gestion de Almacen" };
            var tipoVendedor = new TipoEmpleado { Nombres = "Vendedor", Descripcion = "Registro de Ventas" };

            sistema.AgregarTipoEmpleado(tipoAdmin);
            sistema.AgregarTipoEmpleado(tipoAlmacen);
            sistema.AgregarTipoEmpleado(tipoVendedor);

            //Agregar los empleados
            var empleado1 = new Empleado
            {
                Nombres = "Juan Manuel",
                TipoEmpleados = tipoAdmin ,
                Estado = EstadoEmpleado.ACTIVO,
                FechaIngreso = DateTime.Now,
                Edad = 52,
                Genero = Genero.MASCULINO,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
            };

            var empleado2 = new Empleado
            {
                Nombres = "Carlos Ramos",
                TipoEmpleados = tipoVendedor,
                Estado = EstadoEmpleado.ACTIVO,
                FechaIngreso = DateTime.Now,
                Edad = 26,
                Genero = Genero.MASCULINO,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
            };


            sistema.AgregarEmpleado(empleado1);
            Console.WriteLine("Empleado");

        }
    }
}
