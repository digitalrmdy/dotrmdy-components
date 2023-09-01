using System;
using System.Collections.Generic;
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