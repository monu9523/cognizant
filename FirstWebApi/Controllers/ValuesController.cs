using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static List<string> values = new List<string>()
        {"Kolkata",
    "Pune",
    "Jaipur",
    "Lucknow",
    "Ahmedabad"
        };

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(values);
        }

        // GET: api/values/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= values.Count)
                return BadRequest("Invalid Id");

            return Ok(values[id]);
        }

        // POST: api/values?value=Banana
        [HttpPost]
        public IActionResult Post(string value)
        {
            values.Add(value);
            return Ok(values);
        }

        // PUT: api/values/1?value=Grapes
        [HttpPut("{id}")]
        public IActionResult Put(int id, string value)
        {
            if (id < 0 || id >= values.Count)
                return BadRequest("Invalid Id");

            values[id] = value;

            return Ok(values);
        }

        // DELETE: api/values/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= values.Count)
                return BadRequest("Invalid Id");

            values.RemoveAt(id);

            return Ok(values);
        }
    }
}