using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.API.DTO;
using Sample.API.Mappers;
using Sample.DAL.Entities;
using Sample.DAL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly SampleService _sService;
        private readonly IWebHostEnvironment hosting;

        public SampleController(SampleService sService, IWebHostEnvironment hosting)
        {
            _sService = sService;
            this.hosting = hosting;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Samples> liste = _sService.Get();
                List<SampleDTO> result = liste.GroupBy(s => new { s.SampleId, s.Auteur, s.Titre, s.URL }).Select(s => new SampleDTO
                {
                    SampleId = s.Key.SampleId,
                    Auteur = s.Key.Auteur,
                    Titre = s.Key.Titre,
                    URL = s.Key.URL,
                    Categories = s?.Select(s => s.CategoryName).ToList()
                }).ToList();
                return Ok(result);
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(SampleAddDTO dto)
        {
            Samples s = new Samples
            {
                Auteur = dto.Auteur,
                Titre = dto.Titre,
            };
            // si je recois des bytes
            if(dto.Bytes != null)
            {
                string fileName = Guid.NewGuid().ToString() + "." + dto.MimeType.Split('/')[1];
                // envoyer les bytes dans un dossier //wwwroot/files
                System.IO.File.WriteAllBytes(Path.Combine(hosting.WebRootPath, "Files/" + fileName), dto.Bytes);
                s.URL = "/Files/" + fileName;
            }
            int id = _sService.Add(s);

            foreach (int idCat in dto.Categories)
            {
                _sService.AddCategoryToSample(id, idCat);
            }
            return NoContent();
        }

        [HttpDelete("{Sampleid:int}")]
         public IActionResult DeleteSample(int Sampleid)
         {
             try
             {
                return Ok(_sService.Delete(Sampleid));
             }
             catch (Exception e)
             {
                return Problem(e.Message);
             }
         }

        [HttpPut]

        public IActionResult Update(SampleDTO dto)
        {

            try
            {
                return Ok(_sService.Update(dto.ToDAL()));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
       