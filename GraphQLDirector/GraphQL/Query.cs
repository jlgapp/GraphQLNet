using GraphQLDirector.Data;
using GraphQLDirector.Models;

namespace GraphQLDirector.GraphQL
{
    /// <summary>
    /// Esta clase es el entry ponit o puntos de entrada de nuestros clientes
    /// SE esta creando multihilos para diversas conexiones a la base de datos
    /// ScopeService, y la Notacion UseDbContext con typeof
    /// aqui igual use projections para las realaciones entre tablas u objetos
    /// OJO UsePaging ya no se puede hacer la consulta normal hay que usar las columnas de pagination
    /// si quieres usar la consulta normal quitar el usepagin
    /// </summary>
    public class Query
    {
        [UseDbContext(typeof(ApiDbContext))]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Video> GetVideos([ScopedService] ApiDbContext context)
        {
            return context.Videos!;
        }

        [UseDbContext(typeof(ApiDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Director> GetDirector([ScopedService] ApiDbContext context)
        {
            return context.Directores!;
        }
    }
}
