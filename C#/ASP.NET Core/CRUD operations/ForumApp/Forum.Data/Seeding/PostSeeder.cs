using ASP_ForumApp.Data.Models;

namespace Forum.Data.Seeding
{
    class PostSeeder
    {
        internal Post[] GeneratePosts()
        {
            ICollection<Post> posts = new HashSet<Post>();

            Post currentPost;

            currentPost = new Post()
            {
                Title = "Title 1",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed tempor mattis quam, at porttitor metus."
            };

            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "Title 2",
                Content = "Lorem ipsum dolor sit amet, con."
            };

            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "Title 3",
                Content = "Lorem ipsum dolor sit amet, con.rem ipsum dolor si piscing el ed tempor mattis quam, at porttit"
            };

            posts.Add(currentPost);

            return posts.ToArray();
        }
    }
}
