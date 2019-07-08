using System;
using System.Threading;
using System.Threading.Tasks;

namespace AssertHelper.Utils
{
    /// <summary>
    /// SOURCE : https://www.ryadel.com/en/asyncutil-c-helper-class-async-method-sync-result-wait/
    /// </summary>
    public static class AsyncUtil
    {
        private static readonly TaskFactory _taskFactory = new
            TaskFactory(CancellationToken.None,
                        TaskCreationOptions.None,
                        TaskContinuationOptions.None,
                        TaskScheduler.Default);

        /// <summary>
        /// Executes an async Task method which has a void return value synchronously
        /// USAGE: AsyncUtil.RunSync(() => AsyncMethod());
        /// </summary>
        /// <param name="p_Task">Task method to execute</param>
        public static CancellationTokenSource RunSync(Func<Task> p_Task, TimeSpan? p_TimeOut = null)
        {
            CancellationTokenSource v_Source = p_TimeOut.HasValue
                                                ? new CancellationTokenSource(p_TimeOut.Value)
                                                : new CancellationTokenSource();
            RunSunc(p_Task, v_Source.Token);
            return v_Source;
        }

        /// <summary>
        /// Executes an async Task<T> method which has a T return type synchronously
        /// USAGE: T result = AsyncUtil.RunSync(() => AsyncMethod<T>());
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="p_Task">Task<T> method to execute</param>
        /// <returns></returns>
        public static TResult RunSync<TResult>(Func<Task<TResult>> p_Task)
            => _taskFactory
                .StartNew(p_Task)
                .Unwrap()
                .GetAwaiter()
                .GetResult();

        /// <summary>
        /// Executes an async Task<T> method which has a T return type synchronously
        /// USAGE: T result = AsyncUtil.RunSync(() => AsyncMethod<T>());
        /// </summary>
        /// <typeparam name="TResult">Return Type</typeparam>
        /// <param name="p_Task">Task<T> method to execute</param>
        /// <paramref name="p_Token"> token to apply cancellation of the task </paramref>
        public static TResult RunSync<TResult>(Func<Task<TResult>> p_Task, CancellationToken p_Token)
            => _taskFactory
                .StartNew(p_Task, p_Token)
                .Unwrap()
                .GetAwaiter()
                .GetResult();

        /// <summary>
        /// Executes an async Task method which has a void return value synchronously
        /// USAGE: AsyncUtil.RunSync(() => AsyncMethod());
        /// </summary>
        /// <param name="p_Task">Task method to execute</param>
        /// <paramref name="p_Token"> token to apply cancellation of the task </paramref>
        private static void RunSunc(Func<Task> p_Task, CancellationToken p_Token)
            => _taskFactory
                .StartNew(p_Task, p_Token)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
    }
}
