# RazorComponentRenderer

This is an example of defining ASP.NET MVC components written in Razor syntax that can be rendered:

* within an ASP.NET MVC website
* as a "bare" component using a http post request
* as an "in context" component using a http post request
* as an "in context" example component with sample data

With "in context" we mean that the component is rendered within a complete web page containing all required css and javascript files, 
but containing only the component.

This sample site is also deployed on http://razorcomponentrenderer.azurewebsites.net/, and this website is used in the examples below.

## Testing example component Carousel

For example the component **Carousel**.

### Bare component rendering

The bare rendered component can be requested with:
* HTTP POST request on url http://razorcomponentrenderer.azurewebsites.net/Components/Carousel
* Header **Content-Type** with value **application/json**
* Body with the following contents
```javascript
{
  "Id": "my-carousel",
  "Items": [
    {
      "Title": "Example headline.",
      "Text": "<p>Note: If you're viewing this page via a <code>file://</code> URL, the \"next\" and \"previous\" Glyphicon buttons on the left and right might not load/display properly due to web browser security rules.</p>",
      "LinkTitle": "Sign up today",
      "LinkUrl": "#"
    },
    {
      "Title": "Another example headline.",
      "Text": "<p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>",
      "LinkTitle": "Learn more",
      "LinkUrl": "#"
    },
    {
      "Title": "One more for good measure.",
      "Text": "<p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>",
      "LinkTitle": "Browse gallery",
      "LinkUrl": "#"
    }    
  ]
}
```

### In context component rendering

As above, but use the url http://razorcomponentrenderer.azurewebsites.net/Components/Carousel?view=true

### Example component with data

Open the url http://razorcomponentrenderer.azurewebsites.net/ComponentExamples/Carousel

### Useage of the component on a page

Open the url http://razorcomponentrenderer.azurewebsites.net/Home/About

## Writing a component - for example Carousel

In this section we describe how to write a component that lives within the RazorComponentRenderer. As example component the **Carousel** component
as showcased above will be used.

A component must be seen as a pure function: given a data object, the model, the component will render HTML. All data to be rendered by the 
component is contained within the model.

### The component model

The model is defined in the file ```Models\Components\CarouselModel.cs```. The model contains a simple class with all fields defined as public properties.
Whe properties are used, ASP.NET MVC controllers can automatically convert a POST body in JSon formt to the required model object.

The CarouselModel is defined as follows:

```c#
namespace RazorComponentRenderer.Models.Components
{
    public class CarouselModel
    {
        public string Id { get; set; }
        public CarouselItem[] Items { get; set; }
    }

    public class CarouselItem
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string LinkTitle { get; set; }
        public string LinkUrl { get; set; }
    }
}
```

### The component partial view

The component itself is defined as an ASP.NET MVC partial view in the file ```Views\Shared\Components\Carousel.cshtml```.
This location is important: patial views MUST be defined in the folder ```Views\Shared```.

The Carousel component view is defined as follows:

```cshtml
@model RazorComponentRenderer.Models.Components.CarouselModel
<div id="@Model.Id" class="carousel slide" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
        <li data-target="#myCarousel" data-slide-to="1"></li>
        <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>
    <div class="carousel-inner" role="listbox">
        <div class="item active">
            <img class="first-slide" src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" alt="First slide">
            <div class="container">
                <div class="carousel-caption">
                    <h1>Example headline.</h1>
                    <p>Note: If you're viewing this page via a <code>file://</code> URL, the "next" and "previous" Glyphicon buttons on the left and right might not load/display properly due to web browser security rules.</p>
                    <p><a class="btn btn-lg btn-primary" href="#" role="button">Sign up today</a></p>
                </div>
            </div>
        </div>
        <div class="item">
            <img class="second-slide" src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" alt="Second slide">
            <div class="container">
                <div class="carousel-caption">
                    <h1>Another example headline.</h1>
                    <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
                    <p><a class="btn btn-lg btn-primary" href="#" role="button">Learn more</a></p>
                </div>
            </div>
        </div>
        <div class="item">
            <img class="third-slide" src="data:image/gif;base64,R0lGODlhAQABAIAAAHd3dwAAACH5BAAAAAAALAAAAAABAAEAAAICRAEAOw==" alt="Third slide">
            <div class="container">
                <div class="carousel-caption">
                    <h1>One more for good measure.</h1>
                    <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
                    <p><a class="btn btn-lg btn-primary" href="#" role="button">Browse gallery</a></p>
                </div>
            </div>
        </div>
    </div>
    <a class="left carousel-control" href="#@Model.Id" role="button" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#@Model.Id" role="button" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
    </a>
</div>
```

### A sample data file for the Carousel component

To test the component we added a data file with sample data at ```Controllers\data\carousel-data.json```. We will use this sample data
for rendering the component on the about page (see http://razorcomponentrenderer.azurewebsites.net/Home/About).

```cshtml
@using Newtonsoft.Json
@using RazorComponentRenderer.Models.Components
@{
    var jsonData = System.IO.File.ReadAllText(Path.Combine(Server.MapPath(@"..\bin"), "Controllers/data/carousel-data.json"));
    var carouselModel = JsonConvert.DeserializeObject<CarouselModel>(jsonData);
}

@Html.Partial(@"Components\Carousel", carouselModel);
```

### Making the Carousel component available for rendering

The component can be rendered as bare component and as  an in-context component. For in-context rendering we need to define a
layout page ```views\Shared\_ComponentLayout.html``` which is defined as follows:

```cshtml
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Component rendering</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    @RenderBody()

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required: false)
</body>
</html>
```

The component itself must be added as a method to the Components controller in the file ```Controllers\ComponentsController.cs```:

```c#
[HttpPost] public ActionResult Carousel(CarouselModel model) { return Render(model); }
```

This is all that is required for bare and in-context rendering.

### Carousel component with sample data

The file ```Controllers\ComponentExamplesController.cs``` contains an in-context rendering of the component with sample data:

```c#
public ActionResult Carousel()
{
    var jsonData = System.IO.File.ReadAllText(Path.Combine(Server.MapPath(@"..\bin"), "Controllers/data/carousel-data.json"));
    return new ComponentsController().RenderComponentByName("Carousel", JsonConvert.DeserializeObject<CarouselModel>(jsonData));
}
```