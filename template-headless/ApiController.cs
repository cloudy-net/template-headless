using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace template_headless
{
    public class ApiController
    {
        [Route("/api/books")]
        public async Task<IEnumerable<Book>> Books([FromServices] MyContext context)
        {
            return await context.Books.ToListAsync();
        }
    }
}
