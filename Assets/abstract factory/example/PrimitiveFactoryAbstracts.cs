using UnityEngine;

// Defines our abstract classes to force implementation of abstract methods
namespace NG.AbstractFactoryExample
{
    public abstract class AbstractPrimitiveFactory
    {
        public abstract AbstractPrimitiveProduct CreateProductA(Vector3 position);
        public abstract AbstractPrimitiveProduct CreateProductB(Vector3 position);
    }


    public abstract class AbstractPrimitiveProduct
    {
        public GameObject gameObject { get; protected set; }
        public Color color { get; protected set; }
        public MeshRenderer meshRenderer { get; protected set; }

        public void Instantiate(PrimitiveType primitiveType , Vector3 position)
        {
            color = RColor.Random();
            gameObject = GameObject.CreatePrimitive(primitiveType);
            gameObject.transform.position = position;

            meshRenderer = gameObject.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
                meshRenderer.material.color = color;
        }

        public void CombineWith(AbstractPrimitiveProduct other)
        {
            // prevent self interaction
            if (other == this)
                return;

            if (other.gameObject == null)
                return;

            if (other.meshRenderer != null)
            {
                // Combine colors onto this product.
                Color newColor = other.color + this.color;
                this.color = newColor;
                this.meshRenderer.material.color = newColor;
            }

            gameObject.transform.localScale *= 1.1f;

            Vector3 newPosition = 0.5f * (other.gameObject.transform.position - gameObject.transform.position);
            gameObject.transform.position += newPosition;

            GameObject.Destroy(other.gameObject);
            other = null;
        }
    }

    /// <summary>
    /// Can only interact with like products
    /// </summary>
    public abstract class PrimitiveA : AbstractPrimitiveProduct
    {
        public abstract void Interact(PrimitiveA a);
    }

    /// <summary>
    /// Can interact with either product
    /// </summary>
    public abstract class PrimitiveB : AbstractPrimitiveProduct
    {
        public abstract void Interact(PrimitiveA a);
        public abstract void Interact(PrimitiveB b);
    }
}