using System;

namespace NG.factory_method_pattern.structure
{
    abstract class Product { }

    class ConcreteProductA : Product { }

    class ConcreteProductB : Product { }

    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }


    class MainApp
    {
        void Run()
        {
            Creator[] creators = new Creator[2];
            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}", product.GetType().Name);
            }

            Console.Read();
        }

    }
}
