using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DAL.Entities
{
    public class Samples
    {
        public int SampleId { get; set; }
        public string? Auteur { get; set; }
        public string Titre { get; set; }
        public string? Description { get; set; }
        public string? Format { get; set; }
        public string? URL { get; set; }
        public bool? IsTelechargeable { get; set; }
        public string CategoryName { get; set; }

    }
}
