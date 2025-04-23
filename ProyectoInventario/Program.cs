
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
                            Console.ReadKey();
                            Console.Clear();
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

                Console.WriteLine("********** GESTIÓN DE EMPLEADOS **********");

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
                    //ConsoleKeyInfo tecla = Console.ReadKey(true);
                    int tecla = int.Parse(Console.ReadLine());

                    switch (tecla)
                    {
                        case 1:
                            AgregarEmpleado(sistema);
                            break;
                        case 2:
                            BuscarEmpleado(sistema);
                            break;
                        case 3:
                            ListarEmpleados(sistema);
                            break;
                        case 4:
                            //ModificarEmpleado(sistema);
                            break;
                        case 5:
                            // CambiarEstadoEmpleado(sistema);
                            break;
                        case 6:
                            //GestionTiposEmpleado(sistema);
                            break;
                        case 0:
                            volver = true;
                            break;
                        default:
                            Console.WriteLine("Opcion invalida");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
        }

        //***************************************

        static void AgregarEmpleado(SistemaInventario sistema)
        {
            Console.Clear();

            Console.WriteLine("\n  AGREGAR NUEVO EMPLEADO\n");

            try
            {

                // Solicita datos del empleado
                Console.WriteLine("\n  Ingrese los siguientes datos:\n");

                Console.Write("  Nombre completo: ");
                string nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre)) //Especificada que no, este vacía o consta únicamente de caracteres de espacio en blanco.
                {
                    throw new Exception("El nombre no puede estar vacío."); //La instrucción throw produce una excepción:
                }

                // Mostrar tipos de empleado disponibles
                Console.WriteLine("\n  Tipos de empleado disponibles:");
                var tipos = sistema.ObtenerTipoEmpleados();

                if (tipos.Count == 0)
                {
                    throw new Exception("No hay tipos de empleado registrados. Debe crear al menos uno.");
                }

                foreach (var tipo in tipos)
                {
                    Console.WriteLine($"  [{tipo.Id}] {tipo.Nombres} - {tipo.Descripcion}");
                }

                Console.Write("\n  Seleccione el tipo de empleado (ID): ");
                int tipoId = int.Parse(Console.ReadLine());

                var tipoEmpleado = sistema.ObtenerTipoEmpleadosporId(tipoId);



                if (tipoEmpleado == null)
                {
                    throw new Exception("El tipo de empleado seleccionado no existe.");
                }

                // Solicitar más datos
                Console.Write("\n  Fecha de ingreso (DD/MM/AAAA): ");
                string fechaStr = Console.ReadLine();
                DateTime fechaIngreso;
                if (!DateTime.TryParse(fechaStr, out fechaIngreso))
                {
                    fechaIngreso = DateTime.Now;
                }

                Console.Write("\n  Edad: ");
                int edad = int.Parse(Console.ReadLine());

                Console.WriteLine("\n  Género:");
                Console.WriteLine("  [1] Masculino");
                Console.WriteLine("  [2] Femenino");
                Console.Write("  Seleccione una opción: ");

                int generoOp = int.Parse(Console.ReadLine());
                Genero genero = (generoOp == 1) ? Genero.MASCULINO : Genero.FEMENINO;



                Console.WriteLine("\n  Estado:");
                // int estado = int.Parse(Console.ReadLine());

                Console.WriteLine("  [1] Activo");
                Console.WriteLine("  [2] Inactivo");
                Console.Write("  Seleccione una opción: ");

                int estadoOp = int.Parse(Console.ReadLine());
                EstadoEmpleado Estado = (estadoOp == 1) ? EstadoEmpleado.ACTIVO : EstadoEmpleado.INACTIVO;



                // Crear el empleado
                var empleado = new Empleado
                {
                    Nombres = nombre,
                    TipoEmpleados = tipoEmpleado,
                    Estado = EstadoEmpleado.ACTIVO,
                    FechaIngreso = fechaIngreso,
                    Edad = edad,
                    Genero = genero,
                    FechaCreacion = DateTime.Now
                };

                sistema.AgregarEmpleado(empleado);



                Console.WriteLine("\n  Presione cualquier tecla para volver...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.ReadKey();
            }
        }


        static void ListarEmpleados(SistemaInventario sistema)
        {
            Console.Clear();
            Console.WriteLine("\n  LISTA DE EMPLEADOS\n");

            try
            {


                var empleados = sistema.ObtenerEmpleado();

                if (empleados.Count == 0)
                {
                    Console.WriteLine("\n  No hay empleados registrados en el sistema.");
                }
                else
                {
                    // Opciones de filtrado
                    Console.WriteLine("\n  Filtros:");
                    Console.WriteLine("  [1] Todos los empleados");
                    Console.WriteLine("  [2] Solo empleados activos");
                    Console.WriteLine("  [3] Solo empleados inactivos");
                    Console.Write("\n  Seleccione un filtro: ");

                    ConsoleKeyInfo tecla = Console.ReadKey(true);
                    Console.WriteLine(tecla.KeyChar);


                    List<Empleado> filtrados;

                    switch (tecla.KeyChar)
                    {
                        case '1':
                            filtrados = empleados;
                            break;
                        case '2':
                            filtrados = empleados.Where(e => e.Estado == EstadoEmpleado.ACTIVO).ToList();
                            break;
                        case '3':
                            filtrados = empleados.Where(e => e.Estado != EstadoEmpleado.INACTIVO).ToList();
                            break;
                        default:
                            filtrados = empleados;
                            break;
                    }

                    // Mostrar tabla de empleados
                    MostrarTablaEmpleados(filtrados);

                    static void MostrarTablaEmpleados(List<Empleado> empleados)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n  ID | Nombre | Tipo | Estado | Fecha Ingreso | Edad | Género");
                        Console.WriteLine("  " + new string('-', 80));

                        Console.ForegroundColor = ConsoleColor.White;
                        foreach (var emp in empleados)
                        {
                            // Colorear según estado
                            if (emp.Estado == EstadoEmpleado.ACTIVO)
                                Console.ForegroundColor = ConsoleColor.Green;
                            else if (emp.Estado == EstadoEmpleado.INACTIVO)
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            else
                                Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine($"  {emp.Id} | {emp.Nombres} | {emp.TipoEmpleados.Nombres} | {emp.Estado} | {emp.FechaIngreso.ToShortDateString()} | {emp.Edad} | {emp.Genero}");
                        }

                        Console.ReadKey();
                    }
                }

                Console.WriteLine("\n  Presione cualquier tecla para volver...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }



        static void BuscarEmpleado(SistemaInventario sistema)
        {
            Console.Clear();
            Console.WriteLine("\n  BUSCAR EMPLEADO\n");

            try
            {
                Console.WriteLine("  [1] Buscar por ID");
                Console.WriteLine("  [2] Buscar por Nombre");
                int opcion = LeerEntero("\n  Seleccione una opción: ");

                Empleado empleado = null;

                if (opcion == 1)
                {
                    int id = LeerEntero("  Ingrese el ID del empleado: ");
                    empleado = sistema.ObtenerEmpleadoPorId(id);
                }
                else if (opcion == 2)
                {
                    string nombre = LeerTexto("  Ingrese el nombre del empleado: ");
                    var empleados = sistema.ObtenerEmpleado().Where(e => e.Nombres.ToLower().Contains(nombre.ToLower())).ToList();

                    if (empleados.Count > 1)
                    {
                        Console.WriteLine("\n  Se encontraron varios empleados:");
                        foreach (var emp in empleados)
                        {
                            Console.WriteLine($"  [{emp.Id}] {emp.Nombres}");
                        }
                        int id = LeerEntero("\n  Seleccione el ID específico: ");
                        empleado = sistema.ObtenerEmpleadoPorId(id);
                    }
                    else if (empleados.Count == 1)
                    {
                        empleado = empleados[0];
                    }
                }

                if (empleado != null)
                {
                    MostrarDetalleEmpleado(empleado);
                }
                else
                {
                    Console.WriteLine("  No se encontró ningún empleado con esos criterios.");
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Write("  Seleccione una opción: ");
            }
        }

        static string LeerTexto(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static void MostrarDetalleEmpleado(Empleado empleado)
        {
            Console.Clear();
            Console.WriteLine($"\n  DETALLE DEL EMPLEADO - ID: {empleado.Id}\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  Nombre: {empleado.Nombres}");
            Console.WriteLine($"  Tipo: {empleado.TipoEmpleados.Nombres}");
            Console.WriteLine($"  Estado: {empleado.Estado}");
            Console.WriteLine($"  Fecha de Ingreso: {empleado.FechaIngreso.ToShortDateString()}");
            Console.WriteLine($"  Edad: {empleado.Edad}");
            Console.WriteLine($"  Género: {empleado.Genero}");
            Console.WriteLine($"  Fecha de Creación: {empleado.FechaCreacion}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }


        static int LeerEntero(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int valor))
            {
                return valor;
            }
            throw new FormatException("Debe ingresar un número válido.");
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
                TipoEmpleados = tipoAdmin,
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
                Estado = EstadoEmpleado.INACTIVO,
                FechaIngreso = DateTime.Now,
                Edad = 26,
                Genero = Genero.MASCULINO,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
            };

            sistema.AgregarEmpleado(empleado1);
            sistema.AgregarEmpleado(empleado2);

            Console.WriteLine("Empleado");

        }
    }
}
