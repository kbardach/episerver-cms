using EPiServer.Web.Mvc;
using kim_episerver.Models.Blocks;
using kim_episerver.Models.Pages;
using Microsoft.AspNetCore.Mvc;

namespace kim_episerver.Business.Blocks.Slideshow
{
    public class SlideshowBlockComponent : AsyncBlockComponent<SlideshowBlock>
    {
        protected override async Task<IViewComponentResult> InvokeComponentAsync(SlideshowBlock currentContent)
        {
            var model = new SlideshowBlockViewModel();


            foreach (var item in currentContent.Slideshow.FilteredItems.Select(x => x.LoadContent()))
            {
                if (item is SlideshowPage)
                {
                    var page = item as SlideshowPage;

                    model.Pages.Add(page);
                }
            }

            return await Task.FromResult(View("~/business/blocks/slideshow/default.cshtml", model));
        }
    }
}
