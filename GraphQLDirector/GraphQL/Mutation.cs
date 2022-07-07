using GraphQLDirector.Data;
using GraphQLDirector.GraphQL.Streamers;
using GraphQLDirector.Models;

namespace GraphQLDirector.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(ApiDbContext))]
        public async Task<AddStreamerPayLoad> AddStreamerAsync(AddStreamerInput input,
            [ScopedService] ApiDbContext context)
        {
            var streamer = new Streamer
            {
                Nombre = input.nombre,
                Url = input.url,
            };
            
            context.Streamers!.Add(streamer);
            await context.SaveChangesAsync();

            return new AddStreamerPayLoad(streamer);
        }
    }
}
