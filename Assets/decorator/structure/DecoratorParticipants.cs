using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.decorator.structure
{
    abstract class Component
    {
        public abstract void Operation();
    }

    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation()");
        }
    }

    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }

    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
        }

        void AddedBehavior()
        {
            Console.WriteLine("ConcreteDecoratorB.AddedBehavior()");
        }

    }

    class App
    {
        static void Main()
        {
            // Create ConcreteComponent and 2 decorators
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            /*
            Will output:
                ConcreteComponent.Operation()
                ConcreteDecoratorA.Operation()
                ConcreteDecoratorB.AddedBehavior()
                ConcreteDecoratorB.Operation()
            */

        }
    }
}
