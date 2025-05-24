using UnityEngine;

namespace logandlp.StatesPattern.States.Machines
{
    /// <typeparam name="T">State data.</typeparam>
    public abstract class StatesMachine<T> : MonoBehaviour where T : struct
    {
        private IStates<T> _currentState;
        private T _currentStateData;

        protected virtual void Awake()
        {
            _currentStateData = DataImplementation();
            StatesTransition(FirstStatesCalled());
        }

        protected virtual void Update()
        {
            IStates<T> nextState = _currentState?.Update(_currentStateData);
            if (nextState != null)
            {
                StatesTransition(nextState);
            }
        }
        
        private void StatesTransition(IStates<T> nextState)
        {
            _currentState?.Exit(_currentStateData);
            _currentState = nextState;
            _currentState?.Enter(_currentStateData);
        }

        #region Abstract methode

            /// <summary>
            /// Implementation of current state data called in awake method.
            /// </summary>
            /// <returns>Current state data.</returns>
            protected abstract T DataImplementation();
            
            /// <summary>
            /// Set the first state to call.
            /// </summary>
            /// <returns>First state of the state machine.</returns>
            protected abstract IStates<T> FirstStatesCalled();

        #endregion
    }
}