using System;
using System.Web.Mvc;
using RazorComponentRenderer.Models.Components;

namespace RazorComponentRenderer.Controllers
{
    public class ComponentsController : Controller
    {
        ActionResult Render(object model) {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            if (actionName == null)
            {
                throw new Exception("If calling component controller from other controller, use RenderComponentByName");
            }
            return RenderComponentByName(actionName, model, Request.QueryString["view"] == "true");
        }

        public ActionResult RenderComponentByName(string componentName, object model, bool renderAsView = true)
        {
            if (renderAsView)
            {
                return View($"~/views/Shared/Components/{componentName}.cshtml", "_ComponentLayout", model);
            }
            else
            {
                return PartialView($"~/views/Shared/Components/{componentName}.cshtml", model);
            }
        }

        [HttpPost] public ActionResult Bigger(BiggerModel model) { return Render(model); }
        [HttpPost] public ActionResult Carousel(CarouselModel model) { return Render(model); }
    }
}