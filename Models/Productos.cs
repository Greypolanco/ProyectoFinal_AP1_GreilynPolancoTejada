public class Productos
{
    [Key]
    public int ProductoId { get; set; }
    [Required (ErrorMessage ="Descripcion es requerida")]
    public string  Descripcion { get; set; } = string.Empty;
    [Required (ErrorMessage ="costo es requerido")]
    [Range(5,3500,ErrorMessage ="El costo requerido es {1} a {2}$")]
    public float Costo { get; set; }
    [Required (ErrorMessage ="Precio es requerido")]
    [Range(5,4000,ErrorMessage ="El precio requerido es {1} a {2}$")]
    public float Precio { get; set; }

    [Required (ErrorMessage ="La existencia es requerida")]
    [Range(1,500,ErrorMessage ="la existencia requerida es {1} a {2}")]
    public int Existencia { get; set; }
    public int CategoriaId { get; set; }
}