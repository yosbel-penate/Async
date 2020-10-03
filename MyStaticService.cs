using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
public static class MyStaticService
{
    public static async Task<int> CountBytesInUrlAsync(string url)
    {
        // Artificial delay to show responsiveness.
        await Task.Delay(TimeSpan.FromSeconds(3)).ConfigureAwait(false);
        // Download the actual data and count it.
        using (var client = new HttpClient())
        {
            var data = await client.GetByteArrayAsync(url).ConfigureAwait(false);
            return data.Length;
        }
    }

    public static async Task<int> UsingEntity()
    {
        using (var context = new BloggingContext())
        {
            var query = await (from blog in context.Blogs select blog).CountAsync();
            return query;
        }
    }

    public static async Task<int> AddUsingEntity(Blog entity)
    {
        using (var context = new BloggingContext())
        {
            context.Blogs.Add(entity);
            await context.SaveChangesAsync();
            return 0;
        }
    }
}