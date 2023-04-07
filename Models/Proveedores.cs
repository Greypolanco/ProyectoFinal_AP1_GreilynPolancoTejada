
public class Proveedores
{
    [Key]
    public int ProveedorId { get; set; }

    public DateTime Fecha { get; set; }
    [Required (ErrorMessage ="Nombre del Proveedor es requerido")]
    public string Nombre { get; set; }= string.Empty;
     [Required (ErrorMessage ="Empresa del Proveedor es requerida")]
    public string Empresa { get; set; } = string.Empty;

    [Required (ErrorMessage ="La RNC de la empresa es requerida")]
    [Range(1000,20000000,ErrorMessage ="La RNC de la empresa es requerida")]
    public double RNC { get; set; }
}