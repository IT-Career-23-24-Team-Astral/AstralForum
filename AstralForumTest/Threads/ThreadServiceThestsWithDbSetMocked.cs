using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Thread = AstralForum.Data.Entities.Thread.Thread;
using AstralForum.Repositories;
using AstralForum.Services.Thread;
using AstralForum.Data;
using System.Xml;
using AstralForum.ServiceModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AstralForumTest.Threads;

public class FakeEntityEntry<T> : EntityEntry<T> where T : class
{
	private readonly T _entity;

	public FakeEntityEntry(T entity) : base(null)
	{
		_entity = entity;
	}

	public override T Entity => _entity;

	// Implement other members of EntityEntry<T> as needed
}

// Your test class
public class ThreadServiceThestsWithDbSetMocked
{
	private IThreadRepository threadRepository;
	private IThreadService threadService;

	Mock<DbSet<Thread>> mockSet = new Mock<DbSet<Thread>>();
	Mock<ApplicationDbContext> mockContext = new Mock<ApplicationDbContext>();

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
				Title = "Test thread 2",
				Text = "Text text thread 2"
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
		var myList = this.GetTestThreadData();

		mockSet.As<IQueryable<Thread>>().Setup(t => t.Provider).Returns(myList.AsQueryable().Provider);
		mockSet.As<IQueryable<Thread>>().Setup(t => t.Expression).Returns(myList.AsQueryable().Expression);
		mockSet.As<IQueryable<Thread>>().Setup(t => t.ElementType).Returns(myList.AsQueryable().ElementType);
		mockSet.As<IQueryable<Thread>>().Setup(t => t.GetEnumerator()).Returns(() => myList.GetEnumerator());
		mockSet.Setup(m => m.Add(It.IsAny<Thread>())).Callback<Thread>(myList.Add);

		mockSet.Setup(m => m.AddAsync(It.IsAny<Thread>(), It.IsAny<CancellationToken>()))
			.Returns((Thread entity, CancellationToken cancellationToken) =>
			{
				// Add the entity to your in-memory list or any other data structure
				myList.Add(entity);

				// Create a completed ValueTask<EntityEntry<Thread>> with the appropriate result
				return new ValueTask<EntityEntry<Thread>>(new FakeEntityEntry<Thread>(entity));
			});
		mockContext.Setup(c => c.Threads).Returns(mockSet.Object);

		this.threadRepository = new ThreadRepository(mockContext.Object);
		this.threadService = new ThreadService(threadRepository);
	}


	[Test]
	public async Task CreateThread_WithValidData_ShouldReturnThreadCorrectly()
	{
		// Act
		ThreadDto threadDto = await threadService.CreateThread(new AstralForum.ServiceModels.ThreadDto()
		{
			Id = 4,
			Title = "Hello world",
			Text = "Hello text"
		}, new AstralForum.Data.Entities.User()
		{
			Id = 1,
			UserName = "TestUser"
		});

		List<Thread> threads = mockSet.Object.ToList();

		Assert.That(threadDto.Title == "Hello world");
		Assert.That(threadDto.Text == "Hello text");

		// Assert that other thread did not change
		Assert.That(threads.Single(t => t.Id == 1).Title == "Test thread 1");
	}
}
