using ArtLib2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ArtREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtsController : Controller
    {
        private IArtRepository _repo;
        public ArtsController(IArtRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public ActionResult<IEnumerable<Art>> GetAll()
        {
            var arts = _repo.GetAll();
            if (arts == null || arts.Count == 0)
            {
                return NoContent();
            }
            return Ok(arts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Art> GetById(int id)
        {
            var art = _repo.GetById(id);
            if (art == null)
            {
                return NotFound();
            }
            return Ok(art);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult<Art> Post(Art art)
        {
            try
            {
                _repo.AddArt(art);
                string uri = Url.RouteUrl(RouteData.Values) + "/" + art.Id;
                return Created(uri, art);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Art> Delete(int id)
        {
            var deletedArt = _repo.DeleteArt(id);
            if (deletedArt == null)
            {
                return NotFound();
            }
            return Ok(deletedArt);
        }



        }
}
