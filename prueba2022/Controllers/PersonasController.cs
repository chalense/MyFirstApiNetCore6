using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using prueba2022.Models;
using System.Threading.Tasks;

namespace prueba2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private Conexion dbConexion;
        public PersonasController()
        {
            dbConexion = Conectar.crearConexion();
        }
        [HttpGet]
        public ActionResult Get(){
            return Ok (dbConexion.Prueba.ToArray());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var prueba = await dbConexion.Prueba.FindAsync(id);
            if(prueba != null)
            {
                return Ok(prueba);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task< ActionResult> Post([FromBody] Prueba prueba)
        {
            if (ModelState.IsValid)
            {
                dbConexion.Prueba.Add(prueba);
                await dbConexion.SaveChangesAsync();
                return Ok (prueba);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut]
        public async Task <ActionResult> Put([FromBody] Prueba prueba)
        {
            var v_prueba = dbConexion.Prueba.SingleOrDefault(a => a.idpersona == prueba.idpersona);
            if (v_prueba != null && ModelState.IsValid)
            {
                dbConexion.Entry(v_prueba).CurrentValues.SetValues(prueba);
                await dbConexion.SaveChangesAsync();
                return Ok(v_prueba);
            }
            else 
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public async Task <ActionResult> Delete(int id)
        {
            var prueba = dbConexion.Prueba.SingleOrDefault(a => a.idpersona == id);
            if (prueba != null)
            {
                dbConexion.Prueba.Remove(prueba);
               await dbConexion.SaveChangesAsync();
                return Ok(prueba);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
