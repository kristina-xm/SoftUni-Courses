using Forum.Services.Interfaces;
using Forum.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;

namespace ASP_ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<PostListViewModel> allPost=
                await this.postService.ListAllAsync();

            return View(allPost);
        }

        public IActionResult Add()
        {
            return View();
        }

        //By default all are GET requests
        [HttpPost]
        public async Task<IActionResult> Add(PostAddFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await this.postService.AddPostAsync(model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error while adding your post");
                return View(model);
            }

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(string id)
        {
            //We should find the post with the id and load a form for editing
            try
            {
                PostAddFormModel postModel = await 
                    this.postService.GetForEditByIdAsync(id);

                return View(postModel);
            }
            catch (Exception)
            {
                return this.RedirectToAction("All", "Post");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, PostAddFormModel postModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(postModel);
            }

            try
            {
                await this.postService.EditByIdAsync(id, postModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error while updating your post");
                return View(postModel);
            }

            return RedirectToAction("All", "Post");
        }
    }
}
