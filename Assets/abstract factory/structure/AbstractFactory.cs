using System;

namespace NG.Patterns.Structure.AbstractFactory
{
    #region Abstractions
    public abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    public abstract class AbstractProductA{}

    public abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }
    #endregion

    #region concretes
    public class ProductA1 : AbstractProductA {}

    public class ProductA2 : AbstractProductA { }

    public class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
        }
    }

    public class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
        }
    }

    public class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    public class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }
    #endregion

    
    public class Client
    {
        private AbstractProductA _abstractProductA;
        private AbstractProductB _abstractProductB;

        public Client (AbstractFactory factory)
        {
            _abstractProductA = factory.CreateProductA();
            _abstractProductB = factory.CreateProductB();
        }

        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }

    }   

    // construct factories, clients, and run functionality.
    public class MainApp
    {
        public void Main()
        {
            AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);
            client1.Run();

            AbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new Client(factory2);
            client2.Run();
        }
    }
}
