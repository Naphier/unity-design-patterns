# Decorator Pattern
Decorators attach additional responsibilities to an object dynamically. They provide a flexible alternative for extending functionality.

## Participants
- **Component** - defines the interface for objects that can have responsibilities added to them dynamically.
- **ConcreteComponent** - defines an object to which additional responsibilities can be attached.
- **Decorator** - maintains a reference to a Component object and defines an interface that conforms to the Component's interface.
- **ConcreteDecorator** adds responsibilities to the Component.

