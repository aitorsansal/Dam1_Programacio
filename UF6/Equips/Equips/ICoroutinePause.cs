namespace Pituivan.CoroutineSystem
{
    public interface ICoroutinePause
    {
        /// <summary>
        /// Has the coroutine pause finished?
        /// </summary>
        public bool HasFinished { get; }
    }
}
