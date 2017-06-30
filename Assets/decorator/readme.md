# Decorator Pattern
Decorators attach additional responsibilities to an object dynamically. They provide a flexible alternative for extending functionality.

## Participants
- **Component** - defines the interface for objects that can have responsibilities added to them dynamically.
- **ConcreteComponent** - defines an object to which additional responsibilities can be attached.
- **Decorator** - maintains a reference to a Component object and defines an interface that conforms to the Component's interface.
- **ConcreteDecorator** adds responsibilities to the Component.

## Advantages

- Allows behavior to be extended without modifying existing code.	
- Provides an alternative to subclassing for extending behavior.
- Mirrors the type of components they decorate (they are actually the same type either through inheritance or interface implementation).
- Alters the behavior of their components by adding new functionality before and / or after (or replaces) method calls to the components.
- Components can be wrapped with any number of decorators.
- They are typically transparent to the client of the component - unless the client is relying on the component's concrete type. 

## Disadvantages

- Can results in many small objects in the design and overuse can be complex making the API hard to understand.
- If some code needs to be dependent on specific concrete types then the decorator's hiding of the concrete type can be a problem.
- Instantiation of the component can be complex due to multiple layers of wrapping.

## Common Uses

- Data streams are often wrapped by another stream to get added functionality (i.e. GZipStream around a FileStream).
- Altering the sprite sheet used by an actor in the game based on any game state <http://www.codeproject.com/Articles/690410/Decorator-pattern-usage-on-a-simplified-Pacman-gam>
- Adding objects to an object while maintaining the base functionality (coffee shop example).


## Melee Attack Example

**MeleeAttack.cs**  

- **MeleeAttack** - The **Component** class of the pattern, a very simple abstract class defining the Attack() method (the behavior). In the Decorator pattern the **Component** will often be an abstract class since we will need to override the behavior method with new methods in each decorator class.
- **BaseMelee** - This is the **Concrete Component** class of the pattern inheriting from the abstract component. This is the component that will be decorated. Here I have defined the most basic form of attack.
- **MeleeDecorator** - This is the **Decorator** class of the pattern, an abstract implementation of the component. It maintains a reference to the component class and overrides the Attack() method with a call to the referenced component class's Attack() method.
- **HardPunch** and **KiPunch** - These are our **Concrete Decorators**. These inherit from the MeleeDecorator and override the Attack() method with additional behavior. In HardPunch, that is simply adding 10 to the attack. In KiPunch it is adding 100 to the attack as well as activating a particle system for the special effect.

**MeleeAttackClient.cs**  
This is our MonoBehaviour class that will actually run the example. I have a public property, kiParticles, which is used to assign a particle system in the inspector that the ki punch will fire. Then there are some fields that will retain reference to the type of each attack so that we can call them specifically later. Note that the baseMeleeAttack needs to be of the type MeleeAttack. The others need to be of the type MeleeDecorator since that class contains the method to set the melee attack that is being decorated.  
In the Start() method I set up each of the attacks by decorating the same baseMelee attack since I want the other attacks to only add to the base attack. You can use the decorator to create many different attack combinations very easily.  
In the Update() method I have a some simple input handling so that we can see the differences logged for each attack / decorated attack. 

#### Notes

Notice how building the Super Ki Punch is starting to make the process of decorating complicated and a little hard to follow. This is one of the disadvantages of the pattern as it has multiple layers wrapping the base component. This also may make it more difficult to tell what behaviors have been added to the base component later on in the code. Also the component and decorator abstractions seem to need to be abstract classes and can't be interfaces. This is due to the need to be able to override the behavior method and add the base to it. Therefore our concrete decorators are limited to inheritance instead of interface implementation and they're closely coupled to the concrete component.

