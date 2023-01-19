﻿using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using L2Veshkin5.Utilities;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace L2Veshkin5.Forms
{
    public class PostForm : Form
    {
        private readonly int _postId;
        private ILabel WallPostText =>
            FormElement.FindChildElement<ILabel>(By.ClassName("wall_post_text"), $"{nameof(WallPostText)} {_postId}");

        private IButton WallPostAuthorButton =>
            FormElement.FindChildElement<IButton>(By.XPath("//*[contains(@class, 'post_author')]/a"), $"{nameof(WallPostAuthorButton)} {_postId}");

        public PostForm(int postId): this(By.Id($"post{ConfigManager.UserId}_{postId}"), postId) { }

        public PostForm(By locator, int postId) : base(locator, $"{nameof(PostForm)} {postId}")
        {
            _postId = postId;
        }

        public string GetPostText() => WallPostText.Text;

        public int GetAuthorId()
        {
            var href = WallPostAuthorButton.GetAttribute("href");
            var pattern = new Regex(@"\d+");
            var value = pattern.Match(href).Value;
            int id = int.Parse(value);
            return id;
        }
    }
}