﻿using Moonglade.Core;
using Moonglade.Data.Entities;
using Moonglade.Data.Infrastructure;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Moonglade.Configuration;

namespace Moonglade.Core.Tests
{
    [TestFixture]
    public class BlogStatisticsTests
    {
        private MockRepository _mockRepository;
        private Mock<IRepository<PostExtensionEntity>> _mockPostExtensionRepo;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new(MockBehavior.Default);
            _mockPostExtensionRepo = _mockRepository.Create<IRepository<PostExtensionEntity>>();
        }

        private BlogStatistics CreateBlogStatistics()
        {
            return new(_mockPostExtensionRepo.Object);
        }

        [Test]
        public async Task GetStatisticAsync_StateUnderTest_ExpectedBehavior()
        {
            _mockPostExtensionRepo.Setup(p => p.GetAsync(It.IsAny<Guid>()))
                .Returns(ValueTask.FromResult(new PostExtensionEntity()
                {
                    Hits = 996,
                    Likes = 251
                }));

            // Arrange
            var blogStatistics = CreateBlogStatistics();
            Guid postId = Guid.Empty;

            // Act
            var result = await blogStatistics.GetStatisticAsync(postId);

            // Assert
            Assert.AreEqual(996, result.Hits);
            Assert.AreEqual(251, result.Likes);
        }

        [Test]
        public async Task UpdateStatisticAsync_Null()
        {
            // Arrange
            _mockPostExtensionRepo.Setup(p => p.GetAsync(It.IsAny<Guid>()))
                .Returns(ValueTask.FromResult((PostExtensionEntity)null));

            var blogStatistics = CreateBlogStatistics();
            Guid postId = Guid.Empty;
            int likes = 996;

            // Act
            await blogStatistics.UpdateStatisticAsync(postId, likes);

            // Assert
            _mockPostExtensionRepo.Verify(p => p.UpdateAsync(It.IsAny<PostExtensionEntity>()), Times.Never);
        }

        [Test]
        public async Task UpdateStatisticAsync_Like()
        {
            // Arrange
            var ett = new PostExtensionEntity
            {
                Hits = 996,
                Likes = 251
            };

            _mockPostExtensionRepo.Setup(p => p.GetAsync(It.IsAny<Guid>()))
                .Returns(ValueTask.FromResult(ett));
            var blogStatistics = CreateBlogStatistics();
            Guid postId = Guid.Empty;
            int likes = 35;

            // Act
            await blogStatistics.UpdateStatisticAsync(postId, likes);

            // Assert
            Assert.AreEqual(251 + 35, ett.Likes);
            _mockPostExtensionRepo.Verify(p => p.UpdateAsync(It.IsAny<PostExtensionEntity>()), Times.Once);
        }

        [Test]
        public async Task UpdateStatisticAsync_Hit()
        {
            // Arrange
            var ett = new PostExtensionEntity
            {
                Hits = 996,
                Likes = 251
            };

            _mockPostExtensionRepo.Setup(p => p.GetAsync(It.IsAny<Guid>()))
                .Returns(ValueTask.FromResult(ett));
            var blogStatistics = CreateBlogStatistics();
            Guid postId = Guid.Empty;
            int likes = 0;

            // Act
            await blogStatistics.UpdateStatisticAsync(postId, likes);

            // Assert
            Assert.AreEqual(996 + 1, ett.Hits);
            _mockPostExtensionRepo.Verify(p => p.UpdateAsync(It.IsAny<PostExtensionEntity>()), Times.Once);
        }
    }
}