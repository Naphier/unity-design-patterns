# Flyweight Pattern

### UNFINISHED!

The flyweight pattern is useful when you will have many objects that share a lot of the same base data. Nystrom shows a great example [here][1] which I can't really do any better of an explanation. I can see this pattern being really useful in game engine design or some app where you need tons of objects containing a majority of the same data. In engines like Unity I don't see this being all that useful. As Nystrom shows in his example it looks like it might work best for objects that all have the same material and mesh but vary in location and size. Unity already really takes care of this for us with static batching and its component-based system. 

I'm hoping my example isn't too terrible and it actually makes sense. If someone else has an example that is smarter I'd be happy to look it over bring it in to the fold.

At any rate let's go through the structure (namespace NG.Flyweight.Structure):
- FlyweightBase.cs - This is our basic abstraction defining that a flyweight can recieve and act on some state (StatefulOperation). Pretty open ended.
- ConcreteFlyweight.cs - This is our actual implementation of the abstract class. In the structure namespace it's quite dull and just throws a log message.
- UnsharedFlyweight.cs - The flyweights don't need to share the same state, so I guess we can just define a separate class to not share the state. Seems to defeat the purpose a little, but I suppose the point is more about sharing the properties than the state.
- FlyweightFactory.cs - This will create the flyweights and maintain a list of them. This way if one has been created then we don't make a new one, but get a reference the already created flyweight.
- FlyweightClient.cs - This file is missing and I should be yelled at for that. :P I apparently didn't think it worthwhile. 

As I'm writing this and reading through my code I think I failed to grasp the concept of the flyweight. I'm going to try to do another, better example.


[1]:http://gameprogrammingpatterns.com/flyweight.html
