using System;

namespace StrategyPattern.structure
{
    abstract class Strategy
    {
        public abstract void AlgorithmInterface();
    }

    class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("ConcreteStrategyA.AlgorithmInterface()");
        }
    }

    class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("ConcreteStrategyB.AlgorithmInterface()");
        }
    }

    class ConcreteStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("ConcreteStrategyC.AlgorithmInterface()");
        }
    }

    class Context
    {
        private Strategy _strategy;

        public Context(Strategy strategy)
        {
            this._strategy = strategy;
        }

        public void ContextInterface()
        {
            _strategy.AlgorithmInterface();
        }
    }

    class MainApp
    {
        static void Main()
        {
            Context context;
            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();
        }
    }
}
