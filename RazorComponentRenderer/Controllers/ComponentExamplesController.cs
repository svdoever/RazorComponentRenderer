using System.IO;
using System.Web.Mvc;
using Newtonsoft.Json;
using RazorComponentRenderer.Models.Components;


namespace RazorComponentRenderer.Controllers
{
    public class ComponentExamplesController : Controller
    {
        public ActionResult Carousel()
        {
            var jsonData = System.IO.File.ReadAllText(Path.Combine(Server.MapPath(@"..\bin"), "Controllers/data/carousel-data.json"));
            return new ComponentsController().RenderComponentByName("Carousel", JsonConvert.DeserializeObject<CarouselModel>(jsonData));
        }
    }
}