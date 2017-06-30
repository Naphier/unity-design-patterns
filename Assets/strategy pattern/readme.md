# Strategy Pattern
Defines a family of algorithms, encapsulates each one, and makes the interchangeable. Strategy lets the algorithm vary independently from the clients that use it.

## Participants

- **Strategy** - declares an interface common to all supported algorithms. **Context** uses this interface to call the algorithm defined by a **ConcreteStrategy**.
- **ConcreteStrategy** - implements the algorithm using the **Strategy** interface.
- **Context** - is configured with a **ConcreteStrategy** object. Maintains a reference to a **Strategy** object that lets the **Strategy** access its data.

## Advantages

- Encapsulation of the algorithms allows new algorithms complying with the same interface to be easily introduces.
- Strategies can be switched at runtime.
- Allows clients to choose the algorithm without using conditional statements.
- Data structures used for implementing the algorithm can be completely encapsulated in the Strategy classes allowing the implementation of the algorithm to be changed without affecting the Context class.
- The same strategy object can be shared between different Context objects. However, the shared Strategy object should not maintain states across invocations.

## Disadvantages

- The application needs to be aware of the available strategies to select the appropriate one for the situation.
- Strategy and Context classes may be tightly coupled. The Context must supply the relevant data to the Strategy for implementing the algorithm and sometimes all of the date passed by the Context may not be relevant to all Concrete Strategies. 
- Context and the Strategy classes normally communicate through the interface specified by the abstract Strategy base class. Strategy base class must expose interface for all of the required behaviors which may not be implemented by the Concrete Strategy class.
- The application configures the Context with the required Strategy object therefore creating and maintaining two objects in place of one.
- Since the Strategy object is created by the application (in most cases) the Context has not control over the lifetime of the Strategy object. However, the Context could make a local copy of the Strategy object, but this would increase the memory requirement and likely impact performance.


## Common Uses

- Changing actor locomotion behavior (or any behavior really) - i.e. the player may normally walk or run, but in a certain setting should swim, fly, teleport, etc.
- Sorting algorithm - easily change the algorithm strategy.
- Storing data - We may want to store to a database for now, but later save to a file or transfer over a network.
- Output - We may want to output to a string or CSV or JSON, etc.


## Enemy Behavior Example

In game programming it is common to define the behaviors of enemies. During the design phase you may or may not be aware of all enemy types and may need to add in behaviors later in development. The Strategy pattern allows us to do this fairly easy. It also allows us to redefine these behaviors with minimal (if any) change to the application's code.

### Participants

- **IEnemyBehavior** - This is the pattern's **Strategy**  interface the defines what methods (Attack and Move) are required in the **ConcreteStrategies**.
- **DroneBehavior** and **FighterBehavior** - These are the **ConcreteStrategies** that implement **IEnemyBehavior**. Defined in these classes are properties that are specific to the certain behavior, a constructor method to initiate those properties, then our two required behavioral methods, Attack() and Move().
- **EnemyBehaviorContext** - This is our **Context** class that will be used by the  application to call the behaviors of the Drones and Fighters. It maintains a reference to an IEnemyBehavior property that is initialized via the class's constructor and it has a single method, Act(), which calls the behavioral methods of the IEnemyBehavior.

### Other

- **Bullet** - This class is not truly part of the pattern's structure, but in this example it is a convenience class for creating bullets to visually illustrate the behaviors' Attack() method.

### Application

- **StrategyExampleMainApp.cs** - This is a MonoBehaviour class that is attached to a GameObject in our Unity scene. It contains a coroutine for making the enemies and staggers creation by one second so the enemies don't lump together. In this coroutine we also create an EnemyBehaviorContext and assign to it an IEnemyBehavior. We then add the context to a List so that we can iterate through the list of contexts in the MonoBehaviour's Update() method.

### Notes

Notice how the main app does not need to care about the exact behavior type when it is using a context to fire the behaviors. It does need to know what behavior to use in what situation. Also the app has no idea what the behaviors actually do and they are completely decoupled. This allows us to easily modify or add new behaviors with minimal change to the app's code. The app does not need conditional statements to determine what behavior to use. All of this is left to the Concrete Strategies to carry out. Although these strategies can be switched at runtime, notice that the coupling of the enemy game object to the strategy makes this not very clean. To overcome this you may need some methods for converting the existing IEnemyBehavior Concrete Strategy to a new one. An Adapter pattern may be useful in such a case if you had strategies that do not share common properties (unlike the ones in the example). Or in this specific case it may be simplest to decouple the game object from the concrete IEnemyBehaviors and instead couple it with the EnemyBehaviorContext and pass it as a parameter in the IEnemyBehavior.Move() method.

## Data Output Example

In programming it is often desired to have output in various forms such as CSV, JSON, a simple string legible to humans, or even a string that has been encrypted for saving to a file. In this example we will use a strategy pattern to output to either a CSV or an "encrypted" string for saving to a file.

### Participants

- **IOutputStrategy** - this is the basic strategy interface that all concrete strategies must implement.
- **CSVOutput** and **EncryptedOutput** - these are our concrete strategy variants. Not that the Rot13 class is not part of the participants, but is simply a utility class to allow us a simple 'encryption' method. By no means is this meant to be a good example of encryption.
- **OutputContext** - this is the context class for the pattern that serves as the interface between our app and the strategies.

### Application

**OutputStrategyController.cs** - This is a simple MonoBehaviour class that is added to the scene to illustrate the use of the strategy pattern in this example. It sets up a context for the concrete strategy we have defined then runs it to show the output in the debug console. Then it very easily changes the strategy used in the context then shows the new output.

### Notes
Notice how, unlike the Enemy Behavior example, the object being acted upon (the input string in the example, the enemy game object in the Enemy Behavior example) is completely decoupled from the strategy. So in this example we can easily change what strategy we want to use by changing the concrete strategy that is passed to the context.
