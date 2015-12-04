Command patterns are useful for when you want a generic way to store a command and be able to undo it.
In the scene "command pattern example" you'll see a simple dot that can be moved by GUI buttons.
After making a move you can then undo and redo it. I've added a simple OnGUI label output to the screen so you can see the list of commands with an indication of which is the current command.

There are 4 classes that get used in this example:
* **Command** - this is the basic structure (abstract class) that any command pattern can inherit from. You can use this class in any project.
* **MoveCommand** - this is the structure that inherits from the Command class and will make use of Execute and UnExecute (undo). Each movement is done via a MoveCommand which is in turn recorded in a list so it can be undone or redone. Notice how we have not inherited from Monobehaviour at all yet. It also contains a function to reverse the movement direction, an override for ToString() for the class so we can see it's fields, and a function to convert our MoveDirection enum to a string for easy reading later. The class is constructed with parameters for the receiver of the command (more on that next), the direction of the movement, distance of the movement, and the game object that is being moved.
* **MoveCommandReceiver** - this class handles the actual movement of the game object and is really only needed once. It plays the part of an intermediate between input and the MoveCommand. All of the actual movement is defined here. 
* **InputHandler** - this is the class that brings it all together, the "Invoker". It sends player input to the MoveCommandReceiver via MoveCommands.. They get stored in a standard List so that we can later undo and redo them. It has a functions for each direction of movement so they can be attached to uGUI buttons. It has a simple use of OnGUI to illustrate the command sequence.

Final thoughts:</br>
MoveCommand and MoveCommandReciever are not very flexible. Also, they're tied together. It feels like these could even be in a single class where the MoveCommandReciever could be completely eliminated. I may be missing something. It feels like using this pattern will lead to a lot of classes. 2 for each command. Not really cool. 

