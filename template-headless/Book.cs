using Cloudy.CMS.ContentSupport;
using System.ComponentModel.DataAnnotations.Schema;

namespace template_headless
{
    public class Book : INameable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public string? Name { get; set; }
    }
}
