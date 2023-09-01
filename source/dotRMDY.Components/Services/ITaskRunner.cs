using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace dotRMDY.Components.Services;

[PublicAPI]
public interface ITaskRunner
{
	Task Run(Action action);
	Task Run(Func<Task> action);
	Task WhenAll(params Task[] tasks);
	Task<TResult[]> WhenAll<TResult>(params Task<TResult>[] tasks);
	Task<TResult[]> WhenAll<TResult>(IEnumerable<Task<TResult>> tasks);
}