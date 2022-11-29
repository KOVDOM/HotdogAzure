using Microsoft.AspNetCore.Mvc;

namespace HotdogAzure.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HotdogController : Controller
    {
        public static List<Hotdog> hotdogok = new List<Hotdog>();
        [HttpGet]
        public IActionResult GetHotdogok()
        {
            Hotdog hotdog1= new Hotdog();
            hotdog1.Id = 1;
            hotdog1.Nev = "Hagyományos";
            hotdog1.Szósz= "Majonéz";
            hotdog1.Virsli = "kolbász";
            hotdog1.Zoldseg = "paradicsom";

            Hotdog hotdog2 = new Hotdog();
            hotdog2.Id = 2;
            hotdog2.Nev = "Párizsis";
            hotdog2.Szósz = "Zala felváhott";
            hotdog2.Virsli = "rama";
            hotdog2.Zoldseg = "paprika";
            hotdogok.Add(hotdog1);
            hotdogok.Add(hotdog2);
            //return Ok(Szendvicsek);
            return StatusCode(200, hotdogok);
        }

        [HttpPost]
        public IActionResult PostHotdog()
        {
            Hotdog hotdog = new Hotdog();
            hotdog.Id = 3;
            hotdog.Nev = "Post teszt hotdog";
            hotdog.Szósz = "téli";
            hotdog.Virsli = "bords eve";
            hotdog.Zoldseg = "uborka";
            try
            {
                hotdogok.Add(hotdog);
                return Ok("A szendvics hozzá adása megtörtént");
            }
            catch (Exception ex)
            {
                return BadRequest("A szendvics hozzáadása sikertelen " + ex.Message);
                //return StatusCode(401, "A szendvics hozzáadása sikertelen "+ex.Message);
            }

        }

        [HttpPut]
        public IActionResult PutHotdog()
        {
            try
            {
                hotdogok[0].Nev = "Gőzőm sincs";
                return Ok("Adat modósítás megtörtént");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteHotdog()
        {
            try
            {
                hotdogok.RemoveAt(0);
                return Ok("Adat törlése sikeres volt.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
