using NG.Patterns.Structure.ObserverPattern;
using UnityEngine;

namespace NG.Patterns.Structure.ObserverPatternExample
{
    public class CubeController : MonoBehaviour
    {
        Observer observer;

        public MyCube myCube0;
        public MyCube myCube1;

        public void Awake()
        {
            observer = Observer.Instance;
        }

        // Use this for initialization
        void Start()
        {
            observer.AddListener(TestEvent.JUMP, myCube0, myCube0.Jump);
            observer.AddListener(TestEvent.JUMP, myCube1, myCube1.Jump);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                observer.SendMessage(TestEvent.JUMP, 200f);
            }
        }
    }

}
