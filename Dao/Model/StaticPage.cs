using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Model
{
    public class StaticPage : BaseModel
    {
        public string Name { get; set; }
        [Required]
        public StaticPageType Type { get; set; }
        public string Html { get; set; }
    }

    public enum StaticPageType
    {
        AboutCollection = 1,
        AboutAuthor = 2
    }
}
