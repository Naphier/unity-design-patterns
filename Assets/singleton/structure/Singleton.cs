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
                return _instance;
            }
        }

        public virtual void Start()
        {
            //Check to make sure there isn't already an instance of this class.
            if (_instance == null)
            {
                //If there isn't find the instance and set it.
                _instance = FindObjectOfType<T>();
            }
            else
            {
                //If there is already an instance of this class, destroy the object we just created.
                print("Attempted to spawn another singleton object, destroying new instance of " + gameObject.ToString());
                Destroy(gameObject);
            }
        }
    }
}
