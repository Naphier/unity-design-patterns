using UnityEngine;

namespace logandlp.StatesPattern.Examples
{
    using Data;
    using States;
    
    using StatesPattern.States;
    using StatesPattern.States.Machines;
    
    public class ExampleStatesMachine : StatesMachine<ExampleStateData>
    {
        [ContextMenu("Change State")]
        public void InvokeChangeColor()
        {
            _currentStateData.IsColorChanged = true;
        }
        
        protected override ExampleStateData DataImplementation()
        {
            return new ExampleStateData
            {
                IsColorChanged = false,
                Renderer = GetComponent<Renderer>(),
            };
        }

        protected override IStates<ExampleStateData> FirstStatesCalled()
        {
            return new RedColorState();
        }

        protected override void OnNextStateEvent()
        {
            _currentStateData.IsColorChanged = false;
        }
    }
}