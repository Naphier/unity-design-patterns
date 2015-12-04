using System;
using UnityEngine;

namespace NG.AbstractFactoryExample
{
    public class PrimitiveFactory2 : PrimitiveFactory
    {
        public override AbstractPrimitiveProduct CreateProductA(Vector3 position)
        {
            return new Cylinder(position);
        }

        public override AbstractPrimitiveProduct CreateProductB(Vector3 position)
        {
            return new Cylinder2(position);
        }
    }

    public class Cylinder : PrimitiveA
    {
        public Cylinder(Vector3 position)
        {
            Instantiate(PrimitiveType.Cylinder, position);
        }

        public override void Interact(PrimitiveA a)
        {
            gameObject.transform.Rotate(new Vector3(0f, 0f, a.gameObject.transform.eulerAngles.z + 45f));
            CombineWith(a);
            
        }
    }

    public class Cylinder2 : PrimitiveB
    {
        public Cylinder2(Vector3 position)
        {
            Instantiate(PrimitiveType.Cylinder, position);
        }

        public override void Interact(PrimitiveA a)
        {
            
            CombineWith(a);
            
        }

        public override void Interact(PrimitiveB b)
        {
            gameObject.transform.Rotate(new Vector3(0f, 0f, b.gameObject.transform.eulerAngles.z - 45f));
            CombineWith(b);
        }
    }
}
