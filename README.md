# RazorComponentRenderer

This is an example of defining ASP.NET MVC components written in Razor syntax that can be rendered:

* within an ASP.NET MVC website
* as a "bare" component using a http post request
* as an "in context" component using a http post request
* as an "in context" example component with sample data

With "in context" we mean that the component is rendered within a complete web page containing all required css and javascript files, 
but containing only the component.

This sample site is also deployed on http://razorcomponentrenderer.azurewebsites.net/, and this website is used in the examples below.

## Example component Carousel

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
