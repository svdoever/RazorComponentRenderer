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