using UnityEngine;

namespace NG.Patterns.Structure.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        //The instance of the class type that has been specified
        private static T _instance;

        //The public accessor for other classes to access the Singleton. Simply by typing the <ClassName>.Instance
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    //If there isn't find the instance and set it.
                    _instance = FindObjectOfType<T>();
                }
                return _instance;
            }
        }

        //Making this a virtual function let's the programmer know that there is a function they must override
        //It allows the programmer to make the decision to override the call completely, or to include the base call with its new functionality.
        //In C# this is done by calling base.Awake() in the new class
        public virtual void Awake()
        {
            //Check to make sure there isn't already an instance of this class.
            if(Instance != this)
            {
                //If there is already an instance of this class, destroy the object we just created.
                Debug.LogWarning("Attempted to spawn more then one singleton object. destroying new instance of " + gameObject.ToString() + "\nIf you would like more than one instance, ensure that the class you have written does not Inherit from a Singleton class.");
                Destroy(gameObject);
            }
        }
    }
}
