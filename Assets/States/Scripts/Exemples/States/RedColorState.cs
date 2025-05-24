using UnityEngine;

namespace logandlp.StatesPattern.Examples.States
{
    using Data;
    using StatesPattern.States;
    
    public class RedColorState : IStates<ExampleStateData>
    {
        public void Enter(ExampleStateData data)
        {
            Debug.Log($"{nameof(RedColorState)} is Entered !");
            
            data.Renderer.material.color = Color.red;
        }

        public IStates<ExampleStateData> Update(ExampleStateData data)
        {
            Debug.Log($"{nameof(RedColorState)} is Updating !");
            
            if (data.IsColorChanged)
            {
                return new BlueColorState();
            }
            
            return null;
        }

        public void Exit(ExampleStateData data)
        {
            Debug.Log($"{nameof(RedColorState)} is Exiting !");
        }
    }
}