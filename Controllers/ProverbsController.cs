using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProverbsController : ControllerBase
    {
        private static List<Proverb> proverbs = new List<Proverb>
        {
            new Proverb { Text = "Don’t judge a book by its cover" },
            new Proverb { Text = "Better late than never" }
        };

        [HttpGet(Name = "GetProverbs")]
        public List<Proverb> Get()
        {
            return proverbs;
        }

        [HttpPost(Name = "PostProverbs")]
        public ActionResult<Proverb> Post(Proverb proverb)
        {
            proverbs.Add(proverb);
            return Ok();
        }

        [HttpDelete(Name = "DeleteProverbs")]
        public IActionResult Delete(string text)
        {
            var proverb = proverbs.FirstOrDefault(p => p.Text == text);
            if (proverb == null)
            {
                return NotFound();
            }
            proverbs.Remove(proverb);
            return Ok();
        }

        [HttpPut(Name = "PutProverbs")]
        public IActionResult Put(string oldProverb, Proverb newProverb)
        {
            var proverb = proverbs.FirstOrDefault(p => p.Text == oldProverb);
            if (proverb == null)
            {
                return NotFound();
            }
            proverb.Text = newProverb.Text;
            return Ok();
        }
    }
}
