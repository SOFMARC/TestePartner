using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TesteApiPartner.Models;
using Newtonsoft.Json;
using System.Net;

namespace TesteApiPartner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatrimonioController : Controller
    {       

        PatrimonioDataAccesLayer obj = new PatrimonioDataAccesLayer();

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            List<Patrimonio> lstPatrimonio = new List<Patrimonio>();
            lstPatrimonio = obj.GetAllPatrimonios().ToList();

            return View(lstPatrimonio);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {   
            Patrimonio Patrimonio = obj.GetPatrimonio(id);

            if (Patrimonio == null)
            {
                return NotFound();
            }
            return View(Patrimonio);
        }

        // POST api/values
        [HttpPost]
        public void Post([Bind] Patrimonio Patrimonio)
        {
            if (ModelState.IsValid)
            {
                obj.PostPatrimonio(Patrimonio);               
            }         
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([Bind] Patrimonio Patrimonio)
        {
            if (ModelState.IsValid)
            {
                obj.PutPatrimonio(Patrimonio);              
            }           
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {            
            Patrimonio Patrimonio = obj.GetPatrimonio(id);           
        }
    }
}
