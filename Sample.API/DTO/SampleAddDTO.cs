using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.DTO
{
    public class SampleAddDTO
    {
        public string Auteur { get; set; }
        public string Titre { get; set; }
        public byte[] Bytes { get; set; }
        public string MimeType { get; set; }
        public List<int> Categories { get; set; }

    }
}
