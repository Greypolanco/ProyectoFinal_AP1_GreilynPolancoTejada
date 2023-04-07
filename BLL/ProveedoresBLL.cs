public class ProveedoresBLL
{
    private ApplicationDbContext _contexto;

    public ProveedoresBLL(ApplicationDbContext _contexto)
    {
        this._contexto = _contexto;
    }

    public bool Existe(int id){
        return _contexto.Proveedores.Any(p => p.ProveedorId == id);
    }

    public bool Insertar(Proveedores proveedor){
        bool paso = false;
        _contexto.Proveedores.Add(proveedor);
        paso= _contexto.SaveChanges()>0;
        _contexto.Entry(proveedor).State = EntityState.Detached;
        return paso;
    }

    public bool Modificar(Proveedores proveedor){
        bool paso = false;
        _contexto.Entry(proveedor).State = EntityState.Modified;
        paso = _contexto.SaveChanges()>0;
        _contexto.Entry(proveedor).State = EntityState.Detached;
        return paso;
    }

    public bool Eliminar(Proveedores proveedor){
        bool paso = false;
        _contexto.Entry(proveedor).State = EntityState.Deleted;
        paso = _contexto.SaveChanges() >0;
        _contexto.Entry(proveedor).State = EntityState.Detached;
        return paso;
    }

    public bool Guardar(Proveedores proveedor){
        if(!Existe(proveedor.ProveedorId))
            return this.Insertar(proveedor);
        else
            return this.Modificar(proveedor);
    }

    public Proveedores? Buscar(int id){
        return _contexto.Proveedores.Where(p => p.ProveedorId == id).AsNoTracking().SingleOrDefault();
    }

    public List<Proveedores> GetList(Expression<Func<Proveedores, bool>>criterios){
        return _contexto.Proveedores.AsNoTracking().Where(criterios).ToList();
    }
}