using UnityEngine;

namespace NG.Patterns.Structure.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        //The instance of the class type that has been specified
        private static T _instance;

        // Lock object, will prevent other threads from modifying _instance once one thread begins setting it
        private static object _instLock = new object();

        // Boolean variable to prevent accessing a singleton in the process of being disposed/destroyed
        bool _disposing = false;

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

                if (!_disposing)
                    return _instance;
                else
                    return null;    
            }

            set
            {
                lock(_instLock) // Ensures thread safety
                {
                    if (_instance == null)  // Only set it if it's null
                        _instance = value;
                    else if (_instance == this) // Only the current Instance can modify the _instance variable, for example, to set it null
                        _instance = value;
                }
            }
        }

        //Making this a virtual function let's the programmer know that there is a function they must override
        //It allows the programmer to make the decision to override the call completely, or to include the base call with its new functionality.
        //In C# this is done by calling base.Awake() in the new class
        public virtual void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)  //Check to make sure there isn't already an instance of this class.
            {
                //If there is already an instance of this class, destroy the object we just created.
                Debug.LogWarning("Attempted to spawn more then one singleton object. destroying new instance of " + gameObject.ToString() + "\nIf you would like more than one instance, ensure that the class you have written does not Inherit from a Singleton class.");
                Dispose();
            }
        }

        // Proper cleanup of a Singleton instance includes nullifying any references to it in order to allow Garbage Collection
        private virtual void Dispose()
        {
            _disposing = true;
            Instance = null;

            Destroy(gameObject);
        }

        // In case it is destroyed in an improper manner
        public virtual void OnDestroy()
        {
            if (!_disposing)
                _disposing = true;

            if (Instance != null)
                Instance = null;
        }
    }
}
