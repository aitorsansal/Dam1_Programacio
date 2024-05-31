using System;
using System.Threading.Tasks;

namespace Pituivan.CoroutineSystem
{
    public class WaitForTime : ICoroutinePause
    {
        bool ICoroutinePause.HasFinished { get => hasFinished; }
        private bool hasFinished;

        /// <summary>
        /// Stops a coroutine for the number of seconds indicated.
        /// </summary>
        public WaitForTime(double seconds) => _ = Wait(TimeSpan.FromSeconds(seconds));

        /// <summary>
        /// Stops a coroutine for the indicated time.
        /// </summary>
        public WaitForTime(TimeSpan time) => _ = Wait(time);

        private async Task Wait(TimeSpan time)
        {
            await Task.Delay(time);

            hasFinished = true;
        }
    }
}
