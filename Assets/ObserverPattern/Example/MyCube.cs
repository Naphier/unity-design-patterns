using NG.Patterns.Structure.ObserverPattern;
using UnityEngine;

namespace NG.Patterns.Structure.ObserverPatternExample
{
    public class MyCube : BaseBehaviour
    {
        Rigidbody rigid;

        public int id;

        Observer observer;

        public void Awake()
        {
            observer = Observer.Instance;
            rigid = GetComponent<Rigidbody>();
        }

        // Use this for initialization
        void Start()
        {
            observer.AddListener(TestEvent.CHANGE_COLOR, this, ChangeColor);
        }

        private void ChangeColor(ObservParam obj)
        {
            if (id != 0)
            {
                GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1f), Random.Range(0.0f, 1f), Random.Range(0.0f, 1f));
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                observer.SendMessage(TestEvent.CHANGE_COLOR);
            }
        }

        public void Jump(ObservParam obj)
        {
            float param = (float)obj.data;
            rigid.AddForce(new Vector3(0, param, 0));
        }
    }

}

