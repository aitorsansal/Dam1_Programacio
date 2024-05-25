using System;
using System.Collections;
using System.Threading.Tasks;

namespace Pituivan.CoroutineSystem
{
    public class Coroutine
    {
        private bool isRunning = true;

        private Coroutine() { }

        /// <summary>
        /// Starts running the code of a coroutine asynchronously.
        /// </summary>
        /// <returns>
        /// The coroutine corresponding to the code which is being executed.
        /// </returns>
        public static Coroutine StartCoroutine(IEnumerator enumerator)
        {
            Coroutine coroutine = new();

            Task.Run(() =>
            {
                while (enumerator.MoveNext() && enumerator.Current is ICoroutinePause pause)
                {
                    while (!pause.HasFinished)
                    {
                        if (!coroutine.isRunning) return;
                    }
                }
            });

            return coroutine;
        }

        /// <summary>
        /// Stops a coroutine, if it is still running.
        /// </summary>
        public static void StopCoroutine(Coroutine coroutine)
        {
            coroutine.isRunning = false;
        }
    }
}

