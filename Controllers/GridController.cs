using Microsoft.AspNetCore.Mvc;

namespace GridOrganizerBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GridController : ControllerBase
    {
        private static List<Grid> grids = new List<Grid>
        {
            new Grid(),
            new Grid {
                Id = 1,
                Name = "Grid1"
            }
        };

        [HttpGet("GetAll")]
        public ActionResult<List<Grid>> Get()
        {
            return Ok(grids);
        }

        [HttpGet("{id}")]
        public ActionResult<Grid> GetSingle(int id)
        {
            return Ok(grids.FirstOrDefault(g => g.Id == id));
        }

        [HttpPost]
        public ActionResult<List<Grid>> AddGrid(Grid newGrid)
        {
            grids.Add(newGrid);
            return Ok(grids);
        }


    }
}