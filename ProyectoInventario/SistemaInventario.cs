

using ProyectoInventario.Modelos;

namespace ProyectoInventario
{
    public class SistemaInventario
    {
        private List<TipoEmpleado> _tiposempleados = new List<TipoEmpleado>();
        private List<Empleado> _empleados = new List<Empleado>();
        private List<Producto> _productos = new List<Producto>();
        private List<MovimientoStock> _movimientos = new List<MovimientoStock>();

        //public List<Modelos.TipoEmpleado> TiposEmpleados { get; set; } = new List<Modelos.TipoEmpleado>();

        //metodo para agregar un tipo de empleado
        public void AgregarTipoEmpleado(TipoEmpleado tipoEmpleado)
        {
            _tiposempleados.Add(tipoEmpleado);

        }
        //Metodo para agregar empleados 
        public void AgregarEmpleado(Empleado empleado)
        {
            _empleados.Add(empleado);
        }

        //Metodo para listar todos los tipos de empleados
        public List<Modelos.TipoEmpleado> ObtenerTipoEmpleados()
        {
            return _tiposempleados.ToList();
        }


        public Empleado ObtenerEmpleadoPorId(int id) 
        {
            return _empleados.FirstOrDefault(t => t.Id == id);
        }


        public List<Modelos.Empleado> ObtenerEmpleado()
        {
            return _empleados.ToList();
        }





        //Metodo para obtener un solo empleado  yquiero que sea por Id
        public Modelos.TipoEmpleado ObtenerTipoEmpleadosporId(int id)
        {
            return _tiposempleados.FirstOrDefault(t => t.Id == id);
        }

        //Metodos para agregar productos
        public void AgregarProducto(Producto producto)
        {
            _productos.Add(producto);
        }


    }

}
