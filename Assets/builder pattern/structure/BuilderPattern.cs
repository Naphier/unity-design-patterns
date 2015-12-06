using System;
using System.Collections.Generic;

namespace NG.builder_pattern.structure
{
    class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }

    abstract class Builder
    {
        protected Product _product;
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetProduct();
    }

    class ConcreteBuilder1 : Builder
    {
        public ConcreteBuilder1()
        {
            _product = new Product();
        }

        public override void BuildPartA()
        {
            _product.Add("PartA");
        }

        public override void BuildPartB()
        {
            _product.Add("PartB");
        }

        public override Product GetProduct()
        {
            return _product;
        }
    }

    class ConcreteBuilder2 : Builder
    {
        public ConcreteBuilder2()
        {
            _product = new Product();
        }

        public override void BuildPartA()
        {
            _product.Add("PartX");
        }

        public override void BuildPartB()
        {
            _product.Add("PartY");
        }

        public override Product GetProduct()
        {
            return _product;
        }
    }

    class Product
    {
        private List<string> _parts = new List<string>();
        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("\nProduct Parts --- ");
            foreach (string part in _parts)
            {
                Console.WriteLine("\t" + part);
            }
        }
    }

    // Note how simple it is to make the products at the endpoint.
    // Also the director doesn't care what builders it is fed.
    class ExampleApp
    {
        void Run()
        {
            // Instantiate the director and builders
            Director director = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            // Construct the two products
            director.Construct(b1);
            Product p1 = b1.GetProduct();
            p1.Show();

            director.Construct(b2);
            Product p2 = b2.GetProduct();
            p2.Show();

            Console.Read();
        }
    }
}
