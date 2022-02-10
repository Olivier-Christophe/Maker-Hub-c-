using Sample.API.DTO;
using Sample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.Mappers
{
    public static class CategoryMapper
    {
        public static Category ToDAL (this CategoryDTO dto)
        {
            return new Category
            {
                CategoryId = dto.CategoryId,
                Name = dto.Name
            };
        }
    }
}
