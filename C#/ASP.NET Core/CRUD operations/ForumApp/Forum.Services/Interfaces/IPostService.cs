using Forum.ViewModels.Post;

namespace Forum.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostListViewModel>> ListAllAsync();

        Task AddPostAsync(PostAddFormModel postViewModel);

        Task<PostAddFormModel> GetForEditByIdAsync(string id);

        Task EditByIdAsync(string id, PostAddFormModel postEditedModel);

        Task DeleteByIdAsync(string id);
    }
}
