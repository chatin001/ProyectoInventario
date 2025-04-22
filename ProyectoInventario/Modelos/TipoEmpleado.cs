
namespace ProyectoInventario.Modelos;

public class TipoEmpleado
{
    private static int _nextid = 1;
    public int Id { get; private set; }
    public string Nombres { get; set; }
    public string Descripcion { get; set; }

    public TipoEmpleado()
    { 
        Id = _nextid++;
    }




}
