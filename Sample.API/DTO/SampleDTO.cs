using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.DTO
{
    public class SampleDTO
    {
        public int SampleId { get; set; }
        public string? Auteur { get; set; }
        public string Titre { get; set; }
        public string? Description { get; set; }
        public string? Format { get; set; }
        public string? URL { get; set; }
        public bool? IsTelechargeable { get; set; }
        public List<string> Categories { get; set; }
    }
}
