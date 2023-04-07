public class Categorias
{
    [Key]
    public int CategoriaId { get; set; }
    public string Nombre { get; set; }= string.Empty;
    public int Total { get; set; }

}