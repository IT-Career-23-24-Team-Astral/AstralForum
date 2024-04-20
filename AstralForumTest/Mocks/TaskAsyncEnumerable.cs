using System.Linq.Expressions;

namespace MeTube.Service.Tests.Mocks;

public class TestAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
{
	public TestAsyncEnumerable(IEnumerable<T> enumerable)
		: base(enumerable)
	{ }

	public TestAsyncEnumerable(Expression expression)
		: base(expression)
	{ }

	public IAsyncEnumerator<T> GetEnumerator()
	{
		return new TestAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
	}

	public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
	{
		return new TestAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
	}

	IQueryProvider IQueryable.Provider
	{
		get { return new TestAsyncQueryProvider<T>(this); }
	}
}