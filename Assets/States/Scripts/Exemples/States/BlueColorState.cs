using UnityEngine;

namespace logandlp.StatesPattern.Examples.States
{
    using Data;
    using StatesPattern.States;
    
    public class BlueColorState : IStates<ExampleStateData>
    {
        public void Enter(ExampleStateData data)
        {
            Debug.Log($"{nameof(BlueColorState)} is Entered !");
            
            data.Renderer.material.color = Color.blue;
        }

        public IStates<ExampleStateData> Update(ExampleStateData data)
        {
            Debug.Log($"{nameof(BlueColorState)} is Updating !");
            
            if (data.IsColorChanged)
            {
                return new RedColorState();
            }
            
            return null;
        }

        public void Exit(ExampleStateData data)
        {
            Debug.Log($"{nameof(BlueColorState)} is Exiting !");
        }
    }
}