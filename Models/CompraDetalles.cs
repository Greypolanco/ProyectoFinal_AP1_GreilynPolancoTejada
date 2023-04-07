public class CompraDetalles
{
    [Key]
    public int CompraDetalleId { get; set; }
    public int ProductoId { get; set; }
    [Required(ErrorMessage ="Este campo es requerido")]
    [Range(1,10000,ErrorMessage ="la cantidad es requerida es {1} a {2}")]
    public int Cantidad { get; set; }
    public int CompraId { get; set; }
}