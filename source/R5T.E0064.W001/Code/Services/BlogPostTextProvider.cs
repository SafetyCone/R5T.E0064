using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Components;

using R5T.F0079;
using R5T.T0064;

using R5T.E0064.W001.Blog;


namespace R5T.E0064.W001
{
    /// <summary>
    /// Provides the HTML text of a blog post based on the blog post's name.
    /// </summary>
    [DraftServiceImplementationMarker]
    public class BlogPostTextProvider : IDraftServiceImplementation
    {
        #region Static

        private static async Task<string> GetComponentBlogPostText<TBlogPostComponent>(
            Action<ComponentRenderer<TBlogPostComponent>> configureComponentRenderer = default)
            where TBlogPostComponent : IComponent
        {
            var componentRender = ComponentOperator.Instance.NewRenderer<TBlogPostComponent>(BlogPostTextProvider.ComponentRenderingContext)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<NotificationService>();
                });

            F0000.ActionOperator.Instance.Run_OkIfDefault(
                configureComponentRenderer,
                componentRender);

            var html = await componentRender.Render();
            return html;
        }

        //private static Lazy<Task<string>> GetCachedComponentBlogPostText<TBlogPostComponent>(
        //    Action<ComponentRenderer<TBlogPostComponent>> configureComponentRenderer = default)
        //    where TBlogPostComponent : IComponent
        //{
        //    var output = new Lazy<Task<string>>(() =>
        //        BlogPostTextProvider.GetComponentBlogPostText<TBlogPostComponent>(
        //            configureComponentRenderer));

        //    return output;
        //}

        private static ComponentRenderingContext ComponentRenderingContext { get; } = ComponentOperator.Instance.NewRenderingContext();
        //private static Dictionary<string, Lazy<Task<string>>> GettingBlogPostTextByName { get; } = new()
        //{
        //    { "BlogPost1", BlogPostTextProvider.GetCachedComponentBlogPostText<BlogPost1>() },
        //    { "BlogPost2", BlogPostTextProvider.GetCachedComponentBlogPostText<BlogPost2>() },
        //    { "BlogPost3", BlogPostTextProvider.GetCachedComponentBlogPostText<BlogPost3>() },
        //};

        private static Dictionary<string, Func<Task<string>>> GettingBlogPostTextByName { get; } = new()
        {
            { "BlogPost1", () => BlogPostTextProvider.GetComponentBlogPostText<BlogPost1>() },
            { "BlogPost2", () => BlogPostTextProvider.GetComponentBlogPostText<BlogPost2>() },
            { "BlogPost3", () => BlogPostTextProvider.GetComponentBlogPostText<BlogPost3>() },
            { "BlogPost4", () => BlogPostTextProvider.GetComponentBlogPostText<BlogPost4>() },
            { "BlogPost5", () => BlogPostTextProvider.GetComponentBlogPostText<BlogPost5>() },
        };

        #endregion


        public async Task<string> GetBlogPostText(string blogPostName)
        {
            var gettingBlogPostText = BlogPostTextProvider.GettingBlogPostTextByName[blogPostName]();

            //var blogPostText = await gettingBlogPostText.Value;
            var blogPostText = await gettingBlogPostText;
            return blogPostText;
        }

        public bool HasBlogPost(string blogPostName)
        {
            var output = BlogPostTextProvider.GettingBlogPostTextByName.ContainsKey(blogPostName);
            return output;
        }
    }
}
