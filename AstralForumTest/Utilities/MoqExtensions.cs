using MeTube.Service.Tests.Mocks;
using Moq;

namespace MeTube.Service.Tests.Utilities;

public static class MoqExtensions
{
	public static Mock<IQueryable<TEntity>> MockQueryable<TEntity>(IQueryable<TEntity> mockCollection)
	{
		var mockQueryable = new Mock<IQueryable<TEntity>>();

		mockQueryable.As<IAsyncEnumerable<TEntity>>()
			.Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
			.Returns(new TestAsyncEnumerator<TEntity>(mockCollection.GetEnumerator()));

		mockQueryable.As<IQueryable<TEntity>>()
			.Setup(m => m.Provider)
			.Returns(new TestAsyncQueryProvider<TEntity>(mockCollection.Provider));

		mockQueryable.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(mockCollection.Expression);
		mockQueryable.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(mockCollection.ElementType);
		mockQueryable.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(() => mockCollection.GetEnumerator());

		return mockQueryable;
	}

	public static bool CompareCollections<TEntity>(
		IEnumerable<TEntity> firstCollection,
		IEnumerable<TEntity> secondCollection,
		Func<TEntity, TEntity, bool> comparer)
	{
		if (firstCollection.Count() != secondCollection.Count()) return false;

		foreach (var expectedItem in firstCollection)
		{
			bool isPresent = false;

			foreach (var actualItem in secondCollection)
			{
				if (comparer.Invoke(actualItem, expectedItem))
				{
					isPresent = true;
					break;
				}
			}

			if (!isPresent)
			{
				return false;
			}
		}

		return true;
	}
}