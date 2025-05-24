#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace logandlp.StatesPattern.Examples.Editor
{
    [CustomEditor(typeof(ExampleStatesMachine))]
    public class ExampleStatesMachineEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            GUI.enabled = Application.isPlaying;
            
            if (GUILayout.Button("Change Color State"))
            {
                ExampleStatesMachine stateMachine = (ExampleStatesMachine)target;
                stateMachine.InvokeChangeColor();
            }
            
            GUI.enabled = true;
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}

#endif