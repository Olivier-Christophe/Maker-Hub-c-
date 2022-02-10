using Sample.API.DTO;
using Sample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.Mappers
{
    public static class SampleMapper
    {
        public static Samples ToDAL(this SampleDTO dto)
        {
            return new Samples
            {
                SampleId = dto.SampleId,
                Auteur = dto.Auteur,
                Titre = dto.Titre,
                URL = dto.URL
            };
        }
    }
}
