using UnityEngine;

namespace NG.AbstractFactoryExample
{
    // Must implement CreateProductA and CreateProductB methods
    public class PrimitiveFactory : AbstractPrimitiveFactory
    {
        public override AbstractPrimitiveProduct CreateProductA(Vector3 position)
        {
            return new Cube(position);
        }

        public override AbstractPrimitiveProduct CreateProductB(Vector3 position)
        {
            return new Sphere(position);
        }
    }

    public class Cube : PrimitiveA
    {
        // Constructor
        public Cube (Vector3 position)
        {
            Instantiate(PrimitiveType.Cube, position);
        }

        // Interact with another like product
        public override void Interact(PrimitiveA a)
        {
            CombineWith(a);
        }
    }


    public class Sphere : PrimitiveB
    {
        // Constructor
        public Sphere(Vector3 position)
        {
            Instantiate(PrimitiveType.Sphere, position);
        }

        // Combine with product A, destroying it and making a capsule
        public override void Interact(PrimitiveA a)
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
        public override void Interact(PrimitiveB b)
        {
            CombineWith(b);
        }

    }


    

    public class RColor
    {
        public static Color Random()
        {
            return new Color(
                    0.25f * UnityEngine.Random.value,
                    0.25f * UnityEngine.Random.value,
                    0.25f * UnityEngine.Random.value, 
                    1f
                    );
        }
    }
}
