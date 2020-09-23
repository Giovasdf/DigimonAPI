using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiDigimon2.Conexion;
using ApiDigimon2.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDigimon2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DigimonController : ControllerBase
    {

        // GET /api/digimon/all
        [HttpGet("all")]
        public JsonResult GetDigimons()
        {
            var list = DigimonAzure.getAllDigimons();
            return new JsonResult(list);
        }

        // GET /api/digimon/{5}-{Name}
        [HttpGet("{id}")]
        public JsonResult Digimon(string id)
        {
            bool success = Int32.TryParse(id, out int idDigimon);
            var list = new List<Digimon>();
            if (success)
            {
                list = DigimonAzure.getDigimon(idDigimon);
            }
            else
            {
                list = DigimonAzure.getDigimon(id);
            }
            return new JsonResult(list);
        }

        //GET /api/digimon
        [HttpGet]
        public JsonResult DigimonRandom()
        {
            var list = DigimonAzure.getDigimonRandom();
            return new JsonResult(list);
        }

        //POST /api/digimon
        [HttpPost]
        public void AddDigimon([FromBody] Digimon digimon)
        {
            DigimonAzure.InsertDigimon(digimon);
        }


    }
}
