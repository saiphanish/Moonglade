using Moonglade.Comments;
using Moonglade.Configuration.Abstraction;
using Moonglade.Core.Notification;
using Moonglade.Web.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Moonglade.Tests.Controllers
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CommentControllerTests
    {
        private MockRepository _mockRepository;

        private Mock<ICommentService> _mockCommentService;
        private Mock<IBlogConfig> _mockBlogConfig;
        private Mock<IBlogNotificationClient> _mockBlogNotificationClient;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new(MockBehavior.Default);

            _mockCommentService = _mockRepository.Create<ICommentService>();
            _mockBlogConfig = _mockRepository.Create<IBlogConfig>();
            _mockBlogNotificationClient = _mockRepository.Create<IBlogNotificationClient>();
        }

        private CommentController CreateCommentController()
        {
            return new(
                _mockCommentService.Object,
                _mockBlogConfig.Object,
                _mockBlogNotificationClient.Object);
        }

        [Test]
        public async Task Delete_NoIds()
        {
            var ctl = CreateCommentController();
            var result = await ctl.Delete(Array.Empty<Guid>());

            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task Delete_ValidIds()
        {
            var ids = new[] { Guid.NewGuid(), Guid.NewGuid() };

            var ctl = CreateCommentController();
            var result = await ctl.Delete(ids);

            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.AreEqual(ids, ((OkObjectResult)result).Value);
        }
    }
}