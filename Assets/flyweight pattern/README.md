# Flyweight Pattern

The flyweight pattern is useful when you will have many objects that share a lot of the same base data. Nystrom shows a great example [here][1] which I can't really do any better of an explanation. I can see this pattern being really useful in game engine design or some app where you need tons of objects containing a majority of the same data. In engines like Unity the usefulness is still there, but a bit more restricted to objects that will just share data. As Nystrom shows in his example it looks like it might work best for objects that all have the same material and mesh but vary in location and size. Unity already really takes care of this for us with batching. I do suppose we could use this to share a material manually between many meshes. I'd love to see a good use of this in Unity that goes beyond just handling of primitive data.


### Structure
At any rate let's go through the structure (namespace NG.Flyweight.Structure):

- FlyweightBase.cs - This is our basic abstraction defining that a flyweight can receive and act on some state (StatefulOperation). Pretty open ended.
- ConcreteFlyweight.cs - This is our actual implementation of the abstract class. In the structure namespace it's quite dull and just throws a log message.
- UnsharedFlyweight.cs - The flyweights don't need to share the same state, so I guess we can just define a separate class to not share the state. Seems to defeat the purpose a little, but I suppose the point is more about sharing the properties than the state.
- FlyweightFactory.cs - This will create the flyweights and maintain a list of them. This way if one has been created then we don't make a new one, but get a reference the already created flyweight.
- FlyweightClient - I didn't write a structure for this because it basically just creates the factory then looks to it for a reference of the ConcreteFlyweight. 

### Insects Flyweight Example
The example scenario consists of 2 files:

- Insects.cs - This defines all of the classes needed for the pattern.
  - InsectBase - This is the flyweight base interface that defines what data and methods all Insects will have.
  - Insect - This inherits the InsectBase and its constructor assigns the values of the class's fields based on the insect type. It also defines our "StatefulOperation" which in this case is GetStrength(int health): a calculation of the insect's strength based on its shared properties and an inputted value for health.
  - InsectFlyweightFactory - The class responsible for creating the flyweights. It will return an already created flyweight if one exists, otherwise it will create the one it needs (I see this being helpful if the number of types of flyweights is big).

- InsectsFlyweightExample.cs - This is a MonoBehaviour we can attach to a game object to see our flyweight pattern in use. It first shows that the factory only creates each type of insect once. Then it goes on to attempt to show how this might be useful. I set up a test to see at what level of health an insect will beat another insect. The iterations could likely have been structured better to not need to create "new" insects, but since this is a flyweight we're only creating a new instance to the reference of an already created insect. So the memory footprint should be really small.

### Soldier Flyweight Example (example2)
- ISoldierFlyweight.cs - This interface defines our contract for intrinsic / shared states (variables and a LevelUp() method) as well as an extrinsic method (GetColor()) that returns a color based on the methods implementation in the concrete flyweights.
- ConcreteSoldiers.cs - These are our implementations of the ISoldierFlyweight interface, our Concrete Flyweights. Here we define a reference to a SoldierStats object, what weapon the soldier uses, how to perform a level up operation on ALL soldiers of this type, and the definition of the extrinsic operation GetColor based on the extrinsic value of the soldier's health.
- SoldierFlyweightFactory.cs - A very standard implementation of a lazy-load (or just in time) factory that creates a flyweight if not already created. If already created then it returns the flyweight from the dictionary. Notice that I have made this class static since there's really no reason to instantiate it.
- SoldierGameObjects.cs - This is the "heavyweight" class of the pattern. Not truly part of the pattern, but seems like it is often needed. It holds a reference to the ISoldierFlyweight that holds all of the shared data for the soldier. It has a field, health, that is the extrinsic state of the flyweight which is used in the extrinsic operation, GetColor(health). I've added some interactive methods here so you can hover over any soldier game object to see its properties, you can left click on the soldier to damage that specific unit (health is extrinsic to the flyweight). We can then use the extrinsic health value to find out what color we should display the soldier as. You can right click to level up ALL soldiers of that type. As you can see in the code, the LevelUp() method will affect the flyweight's intrinsic properties, but it does not affect the extrinsic property, health. This needs to be handled outside of the flyweight which leads to a problem: How would we increase the health on all soldiers when all soldiers are leveled up? We'd have to iterate through all of those "heavyweight" soldier game objects which would increase overhead or tighten coupling between the client and the soldier game objects. Or maybe we could use an Observer pattern to send a notification to all of the soldier game objects to increase health when leveled up. Or maybe even a simple delegate in the concrete flyweight that all of the Soldier game objects subscribe to.
- SoldierSceneController.cs - This is the client of the Flyweight pattern. It is responsible for making visual game objects. The creation of the SoldierGameObjects is handled here. This would likely be more appropriately handled by a factory pattern, but this example is meant to focus solely on the Flyweight pattern.

As I mention above, the limitation here with the intrinsic operation, LevelUp(), is that it will affect all of the flyweight's intrinsic properties, but it won't affect the extrinsic properties (and it shouldn't). So if we want to modify the property that is extrinsic to the flyweight when the flyweight's intrinsic values are changed then we need to look outside this pattern. This is by design as the flyweight is meant to contain values that change infrequently, or when changed they affect all references to the flyweight.





[1]:http://gameprogrammingpatterns.com/flyweight.html
