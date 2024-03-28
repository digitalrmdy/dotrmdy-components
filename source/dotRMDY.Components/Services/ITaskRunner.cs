using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace dotRMDY.Components.Services;

[PublicAPI]
public interface ITaskRunner
{
	Task Run(Action action);
	Task Run(Func<Task> action);
	Task Run(Action action, CancellationToken cancellationToken);
	Task Run(Func<Task> action, CancellationToken cancellationToken);
	Task Delay(TimeSpan delay, CancellationToken cancellationToken);
	Task Delay(int milliSecondsDelay, CancellationToken cancellationToken);
	Task WhenAll(params Task[] tasks);
	Task<TResult[]> WhenAll<TResult>(params Task<TResult>[] tasks);
	Task<TResult[]> WhenAll<TResult>(IEnumerable<Task<TResult>> tasks);
}