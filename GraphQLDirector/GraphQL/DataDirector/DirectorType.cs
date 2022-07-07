using GraphQLDirector.Data;
using GraphQLDirector.Models;

namespace GraphQLDirector.GraphQL.DataDirector
{
    public class DirectorType : ObjectType<Director>
    {
        protected override void Configure(IObjectTypeDescriptor<Director> descriptor)
        {
            descriptor.Description("Este modelo representa la data del director");

            descriptor.Field(x => x.Videos)
                .ResolveWith<Resolvers>(x => x.GetVideos(default!, default!))
                .UseDbContext<ApiDbContext>()
                .Description("Representa la collecion de Videos del director");

            descriptor
                .Field("otroNombrecompleto")
                .ResolveWith<Resolvers>(p => p.GetNombreConpleto(default!, default!))
                .UseDbContext<ApiDbContext>()
                .Description("Otro nombre completo directos");

            //descriptor.Ignore(x => x.Id);
        }

        private class Resolvers
        {
            public IQueryable<Video> GetVideos([Parent] Director director, [ScopedService] ApiDbContext context)
            {
                return context.Videos!.Where(x => x.DirectorId == director.Id);
            }

            public string GetNombreConpleto([Parent] Director director, [ScopedService] ApiDbContext context)
            {
                return $"{director.Nombre} {director.Apellido}";
            }
        }
    }
}
