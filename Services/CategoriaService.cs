using webapi;
using webapi.Models;

namespace webapidotnet.Services
{
    public class CategoriaService : ICategoriaService
    {
        TareasContext context;

        public CategoriaService(TareasContext dbContext) 
        {
            context = dbContext;
        }

        public IEnumerable<Categoria> Get() 
        {
            return context.Categorias;
        }

        public void Save(Categoria categoria)
        {
            context.Add(categoria);
            context.SaveChanges();
        }

        /// <summary>
        /// metodo guardar asincrono
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        public async Task SaveAsyn(Categoria categoria)
        {
            context.Add(categoria);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Categoria categoria)
        {
            var categoriaActual = context.Categorias.Find(id);

            if(categoriaActual != null) 
            {
                categoriaActual.Nombre = categoria.Nombre;
                categoriaActual.Descripcion = categoria.Descripcion;
                categoriaActual.Peso = categoria.Peso;

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var categoriaActual = context.Categorias.Find(id);

            if(categoriaActual != null) 
            {
                context.Remove(categoriaActual);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface ICategoriaService
    {
        IEnumerable<Categoria> Get();
        void Save(Categoria categoria);
        Task SaveAsyn(Categoria categoria);
        Task Update(Guid id, Categoria categoria);
        Task Delete(Guid id);
    }
}