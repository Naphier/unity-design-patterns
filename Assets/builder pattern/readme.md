# Builder Pattern
A builder pattern assists in the creation of complex objects that share the same types of components. The builder uses the same process for each product, but each component in the product does not need to be the same. For instance consider a builder that will make vehicles. All vehicles have similar component types: body, wheels, doors, etc. 

### Structure
All classes can be found in **BuilderPattern.cs**.

- **Builder** - This defines our abstract interface that will construct the final product and has the ability to return the final product.
- **ConcreteBuilder** - This constructs and assembles the parts of the product by implementing the abstract Builder's methods and provides the ability to retrieve the actual final product.
- **Director** - This is responsible for running the creation of the final products using the abstract Builder.
- **Product** - The final object that will be created. It should include the references to the parts of the product and the ability to integrate the new parts.

### Example
The example sets up a vehicle builder that can make a car, a motorcycle, or a scooter. The pattern structures are contained in **BuilderExampleStructure.cs**. Here you'll find:

- **ShopForeman** (our 'director' class) is responsible for telling the builders the tasks needed to make a vehicle.
- **VehicleBuilder** (the 'abstract builder' class) will define the framework for all of the vehicle builders. We do need a reference to the vehicle being constructed in every concrete builder so those have been set up. An unfortunate side effect of this is that it forces us to use an abstract class and we cannot have an abstract constructor. Yet all of the concrete builders will need a constructor to instantiate the Vehicle that will be referenced in the concrete VehicleBuilders. I don't see a simple way around this. If you do, let me know!
- **Vehicle** (the 'product') - This will create an empty game object when constructed that will function as a parent to all of the parts we create. It also provides us with a method to add parts to the vehicle and finally a method to list the parts which is not necessary for the pattern, but just there so the class does a little more.
- **CarBuilder.cs**, **MotorCycleBuilder.cs**, and **ScooterBuilder.cs** - These are our concrete builders. Each has a constructor that will instantiate a Vehicle class and assign it to the _vehicle field so we can make references to it when adding parts. Then we have the required methods to add the parts. Here I'm just making some primitives and placing them so they look somewhat like the vehicle I'm trying to make (don't judge me :P). 
- **BuilderController.cs** - This is our MonoBehaviour that can be attached to a game object in the scene. It just makes the ShopForeman and builders, tells the foreman to put the builders to work. Then we can get references to our actual vehicles and do things with them.

