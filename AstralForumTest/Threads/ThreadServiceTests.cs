using NUnit.Framework;
using Moq;
using AstralForum.Repositories;
using Thread = AstralForum.Data.Entities.Thread.Thread;
using CloudinaryDotNet.Actions;
using AstralForum.Services.Thread;
using MeTube.Service.Tests.Utilities;

namespace AstralForumTest.Threads
{
	public class ThreadServiceTests
	{
		private Mock<IThreadRepository> threadRepositoryMock;
		private IThreadService threadService;

		private List<Thread> GetTestThreadData()
		{
			return new List<Thread>()
			{
				new Thread()
				{
					Id = 1,
					Title = "Test thread 1"
				},
				new Thread()
				{
					Id = 2,
					Title = "Test thread 2"
				},
				new Thread()
				{
					Id = 3,
					Title = "Test thread 3"
				}
			};
		}

		[SetUp]
		public void BeforeEach()
		{
			this.threadRepositoryMock = new Mock<IThreadRepository>();

			this.threadService = new ThreadService(threadRepositoryMock.Object);
		}


		[Test]
		public async Task TestGetById_WithExistingId_ShouldCorrectlyReturnThread()
		{
			// Arrange
			var testThreadDataQueryable = this.GetTestThreadData().AsQueryable();
			var mockSet = MoqExtensions.MockQueryable(testThreadDataQueryable);
			mockSet.As<IQueryable<Thread>>().Setup(m => m.GetEnumerator()).Returns(() => testThreadDataQueryable.GetEnumerator());

			threadRepositoryMock.Setup(tr => tr.GetThreadById(2))
				.Returns(mockSet.Object.SingleOrDefault(o => o.Id == 2));

			var expectedThreadId = 2;
			var expectedThreadTitle = "Test thread 2";

			// Act
			var actualThread = threadService.GetThreadById(2);

			var actualThreadId = actualThread.Id;
			var actualThreadTitle = actualThread.Title;

			// Assert
			Assert.That(actualThreadId, Is.EqualTo(expectedThreadId), "Thread Ids differ.");
			Assert.That(actualThreadTitle, Is.EqualTo(expectedThreadTitle), "Thread Titles differ.");
		}

		[Test]
		public async Task TestGetById_WithNotExistingId_ShouldCorrectlyThrowAnException()
		{
			// Arrange
			var testThreadDataQueryable = this.GetTestThreadData().AsQueryable();
			var mockSet = MoqExtensions.MockQueryable(testThreadDataQueryable);
			mockSet.As<IQueryable<Thread>>().Setup(m => m.GetEnumerator()).Returns(() => testThreadDataQueryable.GetEnumerator());

			threadRepositoryMock.Setup(tr => tr.GetThreadById(4))
				.Returns(mockSet.Object.SingleOrDefault(o => o.Id == 4));

			// Act & Assert
			Assert.Throws<ArgumentException>(() => threadService.GetThreadById(4));
		}
	}
}