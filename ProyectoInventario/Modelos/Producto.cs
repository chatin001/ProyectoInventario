namespace ProyectoInventario.Modelos;

public class Producto
{
    private static int _nextId = 1;

    public int Id { get; private set; }
    public string sku { get; set; }
    public string Nombre { get; set; }
    public string descripcion { get; set; }
    public decimal precio { get; set; }
    public int stock { get; set; }
    public CategoriaProducto Categoria { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }

    public Producto()
    {
        Id = _nextId++;
    }


}
