using System.Collections;
using UnityEngine;

namespace NG.PrimitiveFactory
{
    // Must implement CreateProductA and CreateProductB methods
    public class PrimitiveFactory : AbstractPrimitiveFactory
    {
        public override AbstractPrimitiveA CreateProductA(Vector3 position)
        {
            return new PrimitiveCube(position);
        }

        public override AbstractProductAB CreateProductB(Vector3 position)
        {
            return new PrimitiveSphere(position);
        }
    }

    public class PrimitiveCube : AbstractPrimitiveA
    {
        // Constructor
        public PrimitiveCube (Vector3 position)
        {
            Instantiate(PrimitiveType.Cube, position);
        }

        // Interact with another like product
        public override void Combine(AbstractPrimitiveA a)
        {
            CombineWith(a);
        }
    }


    public class PrimitiveSphere : AbstractProductAB
    {
        // Constructor
        public PrimitiveSphere(Vector3 position)
        {
            Instantiate(PrimitiveType.Sphere, position);
        }

        // Combine with product A, destroying it and making a capsule
        public override void Combine(AbstractPrimitiveA a)
        {
            CombineWith(a);

            ReplaceWithCapsule();
        }

        private void ReplaceWithCapsule()
        {
            Vector3 position = gameObject.transform.position;
            Vector3 scale = gameObject.transform.localScale;
            GameObject.Destroy(gameObject);

            gameObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            gameObject.transform.position = position;
            gameObject.transform.localScale = scale;

            meshRenderer = gameObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                // Do not generate a new color, but use the combined one
                //color = RColor.Random();
                meshRenderer.material.color = color;
            }
        }


        // Interaction with non-like products
        public override void Combine(AbstractProductAB b)
        {
            CombineWith(b);
        }

    }


    public class PrimitiveClient
    {
        private AbstractPrimitiveA[] _abstractProductsA = new AbstractPrimitiveA[2];   
        private AbstractProductAB[] _abstractProductsB = new AbstractProductAB[2];

        public PrimitiveClient(AbstractPrimitiveFactory factory)
        {
            _abstractProductsA[0] = factory.CreateProductA(new Vector3(-1f , -0.5f , 0f));
            _abstractProductsA[1] = factory.CreateProductA(new Vector3(-1f , 0.5f , 0f));

            _abstractProductsB[0] = factory.CreateProductB(new Vector3(1f, -0.5f, 0f));
            _abstractProductsB[1] = factory.CreateProductB(new Vector3(1f, 0.5f, 0f));
        }

        public IEnumerator Run()
        {
            Debug.Log("Run starts");
            yield return new WaitForSeconds(5f);

            Debug.Log("Combine Products A");
            _abstractProductsA[0].Combine(_abstractProductsA[1]);
            yield return new WaitForSeconds(2f);

            Debug.Log("Combine Products B");
            _abstractProductsB[0].Combine(_abstractProductsB[1]);
            yield return new WaitForSeconds(2f);

            Debug.Log("Product B absorbs A");
            _abstractProductsB[0].Combine(_abstractProductsA[0]);


        }
    }

    public class RColor
    {
        public static Color Random()
        {
            return new Color(
                    UnityEngine.Random.value,
                    UnityEngine.Random.value,
                    UnityEngine.Random.value, 
                    1f
                    );
        }
    }
}
