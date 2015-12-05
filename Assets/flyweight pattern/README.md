# Flyweight Pattern

The flyweight pattern is useful when you will have many objects that share a lot of the same base data. Nystrom shows a great example [here][1] which I can't really do any better of an explanation. I can see this pattern being really useful in game engine design or some app where you need tons of objects containing a majority of the same data. In engines like Unity the usefulness is still there, but a bit more restricted to objects that will just share data. As Nystrom shows in his example it looks like it might work best for objects that all have the same material and mesh but vary in location and size. Unity already really takes care of this for us with batching. I do suppose we could use this to share a material manually between many meshes. I'd love to see a good use of this in Unity that goes beyond just handling of primitive data.

I'm hoping my example isn't too terrible and it actually makes sense. If someone else has an example that is smarter I'd be happy to look it over bring it in to the fold.

### Structure
At any rate let's go through the structure (namespace NG.Flyweight.Structure):
- FlyweightBase.cs - This is our basic abstraction defining that a flyweight can recieve and act on some state (StatefulOperation). Pretty open ended.
- ConcreteFlyweight.cs - This is our actual implementation of the abstract class. In the structure namespace it's quite dull and just throws a log message.
- UnsharedFlyweight.cs - The flyweights don't need to share the same state, so I guess we can just define a separate class to not share the state. Seems to defeat the purpose a little, but I suppose the point is more about sharing the properties than the state.
- FlyweightFactory.cs - This will create the flyweights and maintain a list of them. This way if one has been created then we don't make a new one, but get a reference the already created flyweight.
- FlyweightClient - I didn't write a structure for this because it basically just creates the factory then looks to it for a reference of the ConcreteFlyweight. 

### Insects Flyweight Example
The example scenario consists of 2 files:
- Insects.cs - This defines all of the classes needed for the pattern.
  - InsectBase - This is the flyweight base interface that defines what data and methods all Insects will have.
  - Insect - This inherits the InsectBase and its construtor assigns the values of the class's fields based on the insect type. It also defines our "StatefulOperation" which in this case is GetStrength(int health): a calculation of the insect's strength based on its shared properies and an inputted value for health.
  - InsectFlyweightFactory - The class responsible for creating the flyweights. It will return an already created flyweight if one exists, otherwise it will create the one it needs (I see this being helpful if the number of types of flyweights is big).

- InsectsFlyweightExample.cs - This is a Monobehaviour we can attach to a game object to see our flyweight pattern in use. It first shows that the factory only creates each type of insect once. Then it goes on to attempt to show how this might be useful. I set up a test to see at what level of health an insect will beat another insect. The iterations could likely have been structured better to not need to create "new" insects, but since this is a flyweight we're only creating a new instance to the reference of an already created insect. So the memory footprint should be really small.

Again, I'd love to see a more visual example of this in Unity. My first attempt was creating a ton of military units that fired at each other, but my design of the flyweight didn't have a good impact on memory. Using a flyweight for game objects might not work out all that well because you can't really share components between game objects. You can share the data that is common to each unit type, but that was not very big.


[1]:http://gameprogrammingpatterns.com/flyweight.html
