namespace ProyectoInventario.Modelos;

public class MovimientoStock
{

    private static int _nextId = 1;
    public int Id { get; private set; }
    public Producto Producto{ get;  set; }
    public Empleado Empleado{ get;  set; }
    public int cantidad { get; set; }   
    public TipoMovimiento TipoMovimiento{ get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }


    public MovimientoStock()
    {
        Id = _nextId++;
    }
}
