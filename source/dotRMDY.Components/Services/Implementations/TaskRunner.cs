using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace dotRMDY.Components.Services.Implementations;

public class TaskRunner: ITaskRunner
{
	public virtual Task Run(Action action)
	{
		return Task.Run(action);
	}

	public virtual Task Run(Func<Task> action)
	{
		return Task.Run(action);
	}

	public Task Run(Action action, CancellationToken cancellationToken)
	{
		return Task.Run(action, cancellationToken);
	}

	public Task Run(Func<Task> action, CancellationToken cancellationToken)
	{
		return Task.Run(action, cancellationToken);
	}

	public Task Delay(int milliSecondsDelay, CancellationToken cancellationToken)
	{
		return Task.Delay(milliSecondsDelay, cancellationToken);
	}	

	public Task Delay(TimeSpan delay, CancellationToken cancellationToken)
	{
		return Task.Delay(delay, cancellationToken);
	}

	public virtual Task WhenAll(params Task[] tasks)
	{
		return Task.WhenAll(tasks);
	}

	public virtual Task<TResult[]> WhenAll<TResult>(params Task<TResult>[] tasks)
	{
		return Task.WhenAll(tasks);
	}

	public Task<TResult[]> WhenAll<TResult>(IEnumerable<Task<TResult>> tasks)
	{
		return Task.WhenAll(tasks);
	}
}