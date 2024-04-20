using NUnit.Framework;
using Moq;
using AstralForum.Repositories;
using Thread = AstralForum.Data.Entities.Thread.Thread;
using CloudinaryDotNet.Actions;
using AstralForum.Services.Thread;
using MeTube.Service.Tests.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using AstralForum.Data;
using AstralForum.ServiceModels;
using AstralForum.Data.Entities.Comment;
using AstralForum.Data.Entities.Thread;
using AstralForum.Data.Entities.ThreadCategory;
using static System.Collections.Specialized.BitVector32;
using AstralForum.Data.Entities;

namespace AstralForumTest.Threads
{
	public class ThreadServiceTestsWithInMemoryDatabase
	{
		private IThreadService threadService;
		private IThreadRepository threadRepository;
		private ApplicationDbContext _dbContext;

		private List<Thread> GetTestThreadData()
		{
			return new List<Thread>()
			{
				new Thread()
				{
					Id = 1,
					Title = "Test thread 1",
					Text = "Test text 1",
					ThreadCategory = new ThreadCategory()
					{
						Id = 1,
						CategoryName = "Cool test category",
						Description = "Description for testing"
					},
					ThreadCategoryId = 1,
					IsHidden = false,
					IsDeleted  = false,
					CreatedBy = new User()
					{
						Id = 1,
						UserName = "TestUser"
					},
					CreatedById = 1
				},
				new Thread()
				{
					Id = 2,
					Title = "Test thread 2",
					Text = "Test text 2",
					ThreadCategory = new ThreadCategory()
					{
						Id = 2,
						CategoryName = "Cool second test category",
						Description = "Description for another testing"
					},
					ThreadCategoryId = 2,
					IsHidden = false,
					IsDeleted  = false,
					CreatedBy = new User()
					{
						Id = 2,
						UserName = "TestNewUser"
					},
					CreatedById = 2
				},
				new Thread()
				{
					Id = 3,
					Title = "Test thread 3",
					Text = "Test text 3",
					ThreadCategoryId = 1,
					IsHidden = false,
					IsDeleted  = false,
					CreatedById = 1,
					Comments = new List<Comment>()
					{
						new Comment()
						{
							Id = 1,
							Text = "Random comment 1",
							CreatedById = 1,
							IsDeleted = false,
							IsHidden = false,
							ThreadId = 3
						},
						new Comment()
						{
							Id = 2,
							Text = "Another comment 2",
							CreatedById = 1,
							IsDeleted = false,
							IsHidden = false,
							ThreadId = 3
						},
						new Comment()
						{
							Id = 3,
							Text = "Random comment 3",
							CreatedById = 1,
							IsDeleted = false,
							IsHidden = false,
							ThreadId = 3
						}
					}
				}
			};
		}

		[SetUp]
		public async Task BeforeEach()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDb")
				.Options;
			this._dbContext = new ApplicationDbContext(options);
			_dbContext.Threads.AddRange(this.GetTestThreadData());
			await _dbContext.SaveChangesAsync();
			this.threadRepository = new ThreadRepository(_dbContext);
			this.threadService = new ThreadService(this.threadRepository);
		}

		[TearDown]
		public void TearDown()
		{
			_dbContext.Database.EnsureDeleted();
		}

		[Test]
		public async Task CreateThread_WithValidData_ShouldCreateThreadCorrectly()
		{
			// Act
			ThreadDto threadDto = await threadService.CreateThread(new AstralForum.ServiceModels.ThreadDto()
			{
				Title = "Hello world",
				Text = "Hello text"
			}, new AstralForum.Data.Entities.User()
			{
				Id = 3,
				UserName = "TestUserNew"
			});

			List<Thread> threads = threadRepository.GetAll().ToList();

			Assert.That(threads.Single(t => t.Id == 4).Title == "Hello world");
			Assert.That(threads.Single(t => t.Id == 4).Text == "Hello text");

			// Assert that other thread did not change
			Assert.That(threads.Single(t => t.Id == 1).Title == "Test thread 1");
		}

		[Test]
		public void HideThread_WithExistingId_ShouldChangeHiddenField()
		{
			// Act
			threadService.HideThread(3);

			List<Thread> threads = threadRepository.GetAll().ToList();

			Assert.That(threads.Single(t => t.Id == 3).IsHidden == true);

			// Assert that other thread did not change
			Assert.That(threads.Single(t => t.Id == 2).IsHidden == false);
		}

		[Test]
		public async Task HideThread_WithNonExistingId_ShouldThrowException()
		{
			// Act & Assert

			Assert.Throws<ArgumentException>(() => threadService.HideThread(-1));
		}

		[Test]
		public async Task DeleteThread_WithExistingId_ShouldChangeDeletedField()
		{
			// Act
			threadService.DeleteThread(3);

			List<Thread> threads = threadRepository.GetAll().ToList();

			Assert.That(threads.Single(t => t.Id == 3).IsDeleted == true);

			// Assert that other thread did not change
			Assert.That(threads.Single(t => t.Id == 2).IsDeleted == false);
		}

		[Test]
		public async Task DeleteAllThreadsByUserId_WithExistingId_ShouldSoftDeleteAllThreadsOfTheUser()
		{
			// Act
			threadService.DeleteAllThreadsByUserId(1);

			List<Thread> threads = threadRepository.GetAll().ToList();
			Assert.That(threads.Where(t => t.IsDeleted == true).Count() == 2);
			Assert.That(threads.Where(t => t.CreatedById != 1 && t.IsDeleted == true).Count() == 0);
		}

		[Test]
		public async Task GetDeletedThreadBack_WithExistingId_ShouldRevertPreviousSoftDelete()
		{
			// Act
			threadService.DeleteThread(2);
			threadService.GetDeletedThreadBack(2);

			List<Thread> threads = threadRepository.GetAll().ToList();

			// Assert
			Assert.That(threads.Single(t => t.Id == 2).IsDeleted == false);
		}

		[Test]
		public async Task GetDeletedThreadBack_WithNotExistingId_ShouldThrowException()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => threadService.GetDeletedThreadBack(15));
		}

		[Test]
		public async Task SearchPostsByText_WithValidData_ShouldReturnMatchingResults()
		{
			// Act & Assert
			Assert.That(threadService.SearchPostsByText(3, "Random").Count, Is.EqualTo(1));
			Assert.That(threadService.SearchPostsByText(3, "Nothing").Count, Is.EqualTo(0));
		}
	}
}