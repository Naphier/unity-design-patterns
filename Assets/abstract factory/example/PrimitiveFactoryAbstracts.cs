using UnityEngine;

// Defines our abstract classes to force implementation of abstract methods
namespace NG.PrimitiveFactory
{
    public abstract class AbstractPrimitiveFactory
    {
        public abstract AbstractPrimitiveA CreateProductA(Vector3 position);
        public abstract AbstractProductAB CreateProductB(Vector3 position);
    }


    public abstract class AbstractPrimitive
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

        public void CombineWith(AbstractPrimitive other)
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

            gameObject.transform.localScale += other.gameObject.transform.localScale;

            GameObject.Destroy(other.gameObject);
        }
    }

    /// <summary>
    /// Can only interact with like products
    /// </summary>
    public abstract class AbstractPrimitiveA : AbstractPrimitive
    {
        public abstract void Combine(AbstractPrimitiveA a);
    }

    /// <summary>
    /// Can interact with either product
    /// </summary>
    public abstract class AbstractProductAB : AbstractPrimitive
    {
        public abstract void Combine(AbstractPrimitiveA a);
        public abstract void Combine(AbstractProductAB b);
    }
}