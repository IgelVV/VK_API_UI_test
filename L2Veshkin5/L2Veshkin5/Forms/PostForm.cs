using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using L2Veshkin5.Constants;
using L2Veshkin5.Extetions;
using L2Veshkin5.Utilities;
using OpenQA.Selenium;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;

namespace L2Veshkin5.Forms
{
    public class PostForm : Form
    {
        private readonly int _postId;
        private ILabel PostText =>
            FormElement.FindChildElement<ILabel>(By.ClassName("wall_post_text"), $"{nameof(PostText)} {_postId}");
        private IButton PostAuthorButton =>
            FormElement.FindChildElement<IButton>(By.XPath("//*[contains(@class, 'post_author')]/a"), $"{nameof(PostAuthorButton)} {_postId}");
        private ILabel PostPicture => 
            FormElement.FindChildElement<ILabel>(By.XPath("//*[contains(@href,'photo')]"), $"{nameof(PostPicture)} {_postId}");
        private IButton ShowNextRepliesButton =>
            FormElement.FindChildElement<IButton>(By.ClassName("js-replies_next_label"), $"{nameof(ShowNextRepliesButton)} {_postId}");

        private IButton Comment(int commentId) =>
            FormElement.FindChildElement<IButton>(By.Id($"post{ConfigManager.UserId}_{commentId}"), $"{nameof(Comment)}{commentId} {_postId}");

        public PostForm(int postId): base (By.Id($"post{ConfigManager.UserId}_{postId}"), $"{nameof(PostForm)} {postId}") 
        {
            _postId = postId;
        }

        public string GetPostText() => PostText.Text;

        public int GetAuthorOfPostId() => GetIdFromElementHref(PostAuthorButton);

        public int GetPictureId() => GetIdFromElementHref(PostPicture);

        private int GetIdFromElementHref(IElement element)
        {
            var pattern = new Regex(@"\d+$");
            var value = pattern.Match(element.GetHref()).Value;
            int id = int.Parse(value);
            return id;
        }

        public void ScrollToTheCenter() => FormElement.JsActions.ScrollToTheCenter();

        public int GetAuthorOfCommentId(int commentId)
        {
            if (ShowNextRepliesButton.State.WaitForExist())
            {
                ShowNextRepliesButton.JsActions.ScrollToTheCenter();
                ShowNextRepliesButton.Click();
            };
            var comment = Comment(commentId);
            var authorId = int.Parse(comment.GetAttribute(HtmlAttributes.AUTHOR_OF_POST_ID));
            return authorId;
        }
    }
}