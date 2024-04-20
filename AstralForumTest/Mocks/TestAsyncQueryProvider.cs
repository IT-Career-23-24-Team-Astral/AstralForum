using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace MeTube.Service.Tests.Mocks;

public class TestAsyncQueryProvider<TEntity> : IAsyncQueryProvider
{
	private readonly IQueryProvider _inner;

	internal TestAsyncQueryProvider(IQueryProvider inner)
	{
		_inner = inner;
	}

	public IQueryable CreateQuery(Expression expression)
	{
		return new TestAsyncEnumerable<TEntity>(expression);
	}

	public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
	{
		return new TestAsyncEnumerable<TElement>(expression);
	}

	public object Execute(Expression expression)
	{
		return _inner.Execute(expression);
	}

	public TResult Execute<TResult>(Expression expression)
	{
		return _inner.Execute<TResult>(expression);
	}

	public IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression)
	{
		return new TestAsyncEnumerable<TResult>(expression);
	}

	public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
	{
		return Task.FromResult(Execute<TResult>(expression));
	}

	TResult IAsyncQueryProvider.ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
	{
		return (TResult)(object)Task.FromResult(Execute<TEntity>(expression));
	}
}