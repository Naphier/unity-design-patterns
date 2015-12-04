using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NG.AbstractFactoryExample
{
    public class PrimitiveClient
    {
        private List<PrimitiveA> _abstractProductsA = new List<PrimitiveA>();
        private List<PrimitiveB> _abstractProductsB = new List<PrimitiveB>();

        private AbstractPrimitiveFactory factory;

        private Vector3 productPositionStep = new Vector3(0, 1f, 0f);
        private Vector3 productAPosition = new Vector3(-2f, -0.5f, 0f);
        private Vector3 productBPosition = new Vector3(2f, -0.5f, 0f);


        public PrimitiveClient(AbstractPrimitiveFactory factory)
        {
            this.factory = factory;
        }

        public void CreateProducts(System.Type type)
        {
            if (type == typeof(PrimitiveA))
            {
                _abstractProductsA.Add(factory.CreateProductA(productAPosition) as PrimitiveA);
                productAPosition += productPositionStep;
            }

            if (type == typeof(PrimitiveB))
            {
                _abstractProductsB.Add(factory.CreateProductB(productBPosition) as PrimitiveB);
                productBPosition += productPositionStep;
            }
        }

        public bool isRunning { get; private set; }
        public string runState { get; private set; }

        public IEnumerator Run()
        {
            isRunning = true;
            runState = "Run starts";
            yield return new WaitForSeconds(2f);


            if (_abstractProductsA.Count > 1)
            {
                runState = "Combine all product A with A";
                for (int i = 0; i < _abstractProductsA.Count; i++)
                {
                    _abstractProductsA[0].Interact(_abstractProductsA[i]);
                    yield return new WaitForSeconds(0.5f);
                }
            }


            if (_abstractProductsB.Count > 1)
            {
                runState = "Combine all product B with B";
                for (int i = 0; i < _abstractProductsB.Count; i++)
                {
                    _abstractProductsB[0].Interact(_abstractProductsB[i]);
                    yield return new WaitForSeconds(0.5f);
                }
            }

            if (_abstractProductsA.Count > 0 && _abstractProductsB.Count > 0)
            {
                runState = "Last B absorbs last A";
                _abstractProductsB[0].Interact(_abstractProductsA[0]);
            }

            yield return new WaitForSeconds(2f);

            if (_abstractProductsB.Count > 0)
            {
                if (_abstractProductsB[0].gameObject != null)
                    GameObject.Destroy(_abstractProductsB[0].gameObject);
            }
            isRunning = false;
        }

        
    }
}
