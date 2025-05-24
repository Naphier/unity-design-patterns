namespace logandlp.StatesPattern.States
{
    public interface IStates<T> where T : struct
    {
        /// <summary>
        /// State entry event.
        /// </summary>
        /// <param name="data">State data.</param>
        public void Enter(T data);
        
        /// <summary>
        /// State update event.
        /// </summary>
        /// <param name="data">State data.</param>
        /// <returns>Next state.</returns>
        public IStates<T> Update(T data);
        
        /// <summary>
        /// State exit event.
        /// </summary>
        /// <param name="data">State data.</param>
        public void Exit(T data);
    }
}