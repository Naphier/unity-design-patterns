# Abstract Factory
The abstract factory is pretty cool. What this does is sets up an interface for creating families of related or dependent objects and you don't need to specify what their concrete class is.  
The structure is broken down like this (see AbstractFactory.cs):
- AbstractFactory class - this defines what abstract products can be created. For example, Mazda factory would create Mazda vehicles.
- AbstractProduct classes - these define an interface for each of the products and any required methods that would be used to define interaction between the other products that can be created by the factory.
- ConcreteProduct classes - these define the actual product that will be created by our ConcreteFactory class and modifies the methods that define interaction with other products.
- ConcreteFactory class - this is the class that is responsible for creating the ConcreteProducts.
- Client class - the client makes use of the factories, tells them to create products, and tells the products to interact.

In the example I have fleshed out an abstract factory, abstract products, 2 concrete factories each with 2 concrete products, and a client that can easily run either factory.
- PrimitiveFactoryAbstracts.cs
  - AbstractPrimitiveFactory - tells us that each concrete primitive factory is able to create 2 product type.
  - AbstractPrimitiveProduct - this is the base class for any product for the factory. It defines some common varaibles and functionality that all products will inherit. Each product will have a GameObject, Color, and MeshRenderer. 
      - Instantiate will create the game object and fill out the required fields.
      - CombineWith will allow this product to "absorb" another product. What products it can combine with will be defined in the concrete definitions.
  - PrimitiveA and PrimitiveB - these are the final abstract products that will be created by the factory. Note how some behaviour has been set up for them. PrimitiveA can only interact with other PrimitiveA products, PrimitiveB can interact with either.
  
- PrimitiveFactory.cs - in this file we define our concrete factory and concrete products. I've also added a class RColor to get a random color.
 - PrimitiveFactory - Now we're finally setting up the factory and defining the concrete products it will create.
 - Cube - This is our first product, pretty basic. It has a constructor that will instantiate the game object at the input position and set up all of the fields in the abstract class. It also defines interaction.
 - Sphere - Similar to the Cube product, but when it interacts with PrimitiveA (in this case a cube) it will be replaced with a capsule. When combining with another PrimitiveB it will just use the default combine behaviour. Note how these concrete product classes are now quite compact making it easy for us to write lots of them.

- PrimitiveFactory2.cs - This is similar to our first factory, but it now creates 2 types of cylinders that have slightly different behaviour than the primitives in the first factory.

- PrimitiveClient.cs - This class is responsible for running the factories. Note how it doesn't care what type of concrete factory or concrete products are being made. It leaves that up to the factories and the products. It maintains a list of the products so that it can Run() the behaviour on them after they've been created. It also keeps track of a position to place the products at. We'll be able to view the behaviour in progress with the Run() coroutine and I've set up a publically accessible string so that our Monobehaviour class can report the state via OnGUI.

- PrimitiveFactoryController.cs - This is our final endpoint, our "app". It sets up the factories and the clients, tells them to create products, and shows us the client state in OnGUI. Note how this class is really bare minimum. It takes just a few lines of code to create the factory, client, the products, and run the client to make the products interact. Really streamlined at this point.

That's all there is to it! See it in action by loading up the example scene and hitting play. Explore the code lots and tinker with your own factories and products with varying behaviour. I hope this is a helpful example. If anyone has another I'd love to see it!


