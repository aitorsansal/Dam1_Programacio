using System;
using System.Threading.Tasks;

namespace Pituivan.CoroutineSystem
{
    public class WaitUntil : ICoroutinePause
    {
        bool ICoroutinePause.HasFinished { get => hasFinished; }
        private bool hasFinished;

        /// <summary>
        /// Stops a coroutine until the indicated condition is met.
        /// </summary>
        public WaitUntil(Func<bool> predicate) => Task.Run(() =>
        {
            while (!predicate.Invoke()) { }

            hasFinished = true;
        });
    }
}
