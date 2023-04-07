
public class CategoriaBLL
{
    private ApplicationDbContext _contexto;

    public CategoriaBLL(ApplicationDbContext _contexto)
    {
        this._contexto = _contexto;
    }

    public Categorias? Buscar(int id){
        return _contexto.Categorias.Where(c => c.CategoriaId == id).AsNoTracking().SingleOrDefault();
    }
    public List<Categorias> GetList(Expression<Func<Categorias, bool>>criterio){
        return _contexto.Categorias.AsNoTracking().Where(criterio).ToList();
    }

}