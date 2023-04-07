public class ProductosBLL
{
    private ApplicationDbContext _contexto;

    public ProductosBLL(ApplicationDbContext _contexto)
    {
            this._contexto = _contexto;
    }

    public bool Existe(int id){
        return _contexto.Productos.Any(p => p.ProductoId == id);
    }

    public bool Insertar(Productos producto){
        
        var paso = false;
        try{
            Categorias? categoria;
                categoria = _contexto.Categorias.SingleOrDefault(p => p.CategoriaId == producto.CategoriaId);
                if(producto != null){
                    if(categoria != null){
                        categoria.Total += producto.Existencia;
                        _contexto.Entry(categoria).State = EntityState.Modified;
                    }
                    _contexto.Entry(producto).State = EntityState.Added;
                    paso = _contexto.SaveChanges() >0;
                    _contexto.Entry(producto).State = EntityState.Detached;
                }   
        }
        catch(Exception)
        {
            return false;
        }
        return paso;
    }

    public bool Modificar(Productos producto){
        bool paso = false;
        _contexto.Entry(producto).State = EntityState.Modified;
        paso = _contexto.SaveChanges() >0;
        _contexto.Entry(producto).State = EntityState.Detached;
        return paso;
    }

    public bool Eliminar(Productos producto){
        var paso = false;
        try{
            Categorias? categoria;
            categoria = _contexto.Categorias.SingleOrDefault(p => p.CategoriaId == producto.CategoriaId);
            if(producto != null){
                if(categoria != null){
                    categoria.Total -= producto.Existencia;
                    _contexto.Entry(categoria).State = EntityState.Modified;
                }
                _contexto.Entry(producto).State = EntityState.Deleted;
                paso = _contexto.SaveChanges() >0;
                _contexto.Entry(producto).State = EntityState.Detached;
            }   
        }
        catch(Exception)
        {
            return false;
        }
        return paso;
    }

    public bool Guardar(Productos producto){
        if(!Existe(producto.ProductoId))
            return this.Insertar(producto);
        else
            return this.Modificar(producto);
    }

    public Productos? Buscar(int id){
        return _contexto.Productos.Where(p => p.ProductoId == id).AsNoTracking().SingleOrDefault();
    }

    public List<Productos> GetList(Expression<Func<Productos, bool>>criterio){
        return _contexto.Productos.AsNoTracking().Where(criterio).ToList();
    }

}