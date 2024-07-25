using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WatchesController : ControllerBase
    {
        private static List<Watch> watches = new List<Watch>
        {
            new Watch
            {
                Brand = "Rolex",
                Name = "Submariner",
                Color = "Black",
                Price = 10000,
                Weight = 150
            },
            new Watch
            {
                Brand = "Casio",
                Name = "G-Shock",
                Color = "Red",
                Price = 150,
                Weight = 80
            },
            new Watch
            {
                Brand = "Seiko",
                Name = "Presage",
                Color = "Blue",
                Price = 500,
                Weight = 120
            }
        };

        [HttpGet(Name = "GetWatches")]
        public List<Watch> Get()
        {
            return watches;
        }

        [HttpPost(Name = "PostWatches")]
        public ActionResult<Watch> Post(Watch watch)
        {
            watches.Add(watch);
            return Ok();
        }

        [HttpDelete(Name = "DeleteWatches")]
        public IActionResult Delete(string brand, string name)
        {
            var watch = watches.FirstOrDefault(p => p.Brand == brand && p.Name == name);
            if (watch == null)
            {
                return NotFound();
            }
            watches.Remove(watch);
            return Ok();
        }
        
        [HttpPut(Name = "PutWatches")]
        public IActionResult Put(string brand, string name, [FromBody] Watch newWatch)
        {
            var oldWatch = watches.FirstOrDefault(p => p.Brand == brand && p.Name == name);
            if (oldWatch == null)
            {
                return NotFound();
            }
            oldWatch.Brand = newWatch.Brand;
            oldWatch.Name = newWatch.Name;
            oldWatch.Color = newWatch.Color;
            oldWatch.Price = newWatch.Price;
            oldWatch.Weight = newWatch.Weight;
            return Ok();
        }
    }
}
