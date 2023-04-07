public class ComprasBLL
{
    private ApplicationDbContext _contexto;
    public ComprasBLL(ApplicationDbContext _contexto)
    {
        this._contexto = _contexto;
    }

    public bool Existe(int Id){
        return _contexto.Compras.Any(c => c.CompraId == Id);
    }

     public bool Insertar(Compras compra)
    {
        var paso = false;
        try{
            Productos? producto;
            foreach(var detalle in compra.CompraDetalles)
            {
                producto = _contexto.Productos.SingleOrDefault(p => p.ProductoId == detalle.ProductoId);
                if(producto != null){
                    producto.Existencia -= detalle.Cantidad;
                    _contexto.Entry(producto).State = EntityState.Modified;
                    _contexto.Entry(detalle).State = EntityState.Added;
                }
            }
            _contexto.Entry(compra).State = EntityState.Added;
            paso = _contexto.SaveChanges() >0;
            _contexto.Entry(compra).State = EntityState.Detached;
        }
        catch(Exception)
        {
            return false;
        }
        return paso;
    }
    public bool Modificar(Compras compra)
    {
        var paso = false;
        try{
            var CompraAnterior = Buscar(compra.CompraId);
            Productos? producto;
            if(CompraAnterior != null){
                foreach(var detalle in CompraAnterior.CompraDetalles){
                    producto = _contexto.Productos.Find(detalle.CompraDetalleId);

                    if(producto !=null)
                        producto.Existencia += detalle.Cantidad;
                }
            }
            _contexto.Database.ExecuteSqlRaw($"DELETE FROM CompraDetalles WHERE CompraId = {compra.CompraId}");
            foreach (var New in compra.CompraDetalles)
            {
                producto = _contexto.Productos.Find(New.CompraDetalleId);
                if(producto != null)
                    producto.Existencia -= New.Cantidad;
                _contexto.Entry(New).State = EntityState.Added;
            }
            _contexto.Entry(compra).State = EntityState.Modified;
            paso= _contexto.SaveChanges() > 0;
            _contexto.Entry(compra).State = EntityState.Detached;
            
        }
        catch(Exception)
        {
            return false;
        }
        return paso;
    }
    public bool Guardar(Compras compra)
    {
        try{
            if(!Existe(compra.CompraId))
                return Insertar(compra);
            else
                return Modificar(compra);
        }
        catch(Exception)
        {
            return false;
        }
    }
    public bool Eliminar(Compras compra)
    {
        var paso = false;
        try{
            Productos? producto;
            foreach (var detalle in compra.CompraDetalles)
            {
                producto = _contexto.Productos.SingleOrDefault(p => p.ProductoId == detalle.ProductoId);
                if(producto != null)
                {
                    producto.Existencia += detalle.Cantidad;
                    _contexto.Entry(producto).State = EntityState.Modified;
                }
            }
            _contexto.Entry(compra).State = EntityState.Deleted;
            paso =  _contexto.SaveChanges() > 0;
            _contexto.Entry(compra).State = EntityState.Detached;
            
        }
        catch(Exception)
        {
            return false;
        }
        return paso;
    }
    public Compras? Buscar(int Id){
        return _contexto.Compras.Include(c => c.CompraDetalles).Where(c => c.CompraId == Id).AsNoTracking().SingleOrDefault();
    }

    public List<Compras> GetList(Expression<Func<Compras, bool>> criterio){
        return _contexto.Compras.Include(c => c.CompraDetalles).AsNoTracking().Where(criterio).ToList();
    }
}