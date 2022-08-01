![Image of Design Patterns](book_cover.webp)

The four authors Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides are collectively introduced the Gang of Four Design Patterns in Software development. In 1994, they published a book (Design Patterns: Elements of Reusable Object-Oriented Software) for explaining the concept of Design Patterns, which are solutions to common software design problems that occur while working with the small or enterprise applications.

## 1. Creational Design Patterns

These patterns deal with the process of objects created in such a way that they can be decoupled from their implementing system. This provides more flexibility in deciding which objects need to be created for a given use case / scenario. There are as follows:

1. **[Factory Method](1.creational/1.factory-method/):** Create instances of derived classes.
2. **[Abstract Factory](1.creational/2.abstract-factory/):** Create instances of several classes belonging to different families.
3. **[Builder](1.creational/3.builder/):** Separates an object construction from its representation.
4. **[Prototype](1.creational/4.prototype/):** Create a duplicate object or clone of the object.
5. **[Singleton](1.creational/5.singleton/):** Ensures that a class can has only one instance.

## 2. Structural Design Patterns

These patterns deal with the composition of objects structures. The concept of inheritance is used to compose interfaces and define various ways to compose objects for obtaining new functionalities. There are as follows:

1. **[Adapter](2.structural/1.adapter/):** Match interfaces of different classes.
2. **[Bridge](2.structural/2.bridge/):** Separates an object’s abstraction from its implementation .
3. **[Composite](2.structural/3.composite/):** A tree structure of simple and composite objects.
4. **[Decorator](2.structural/4.decorator/):** Add responsibilities to objects dynamically.
5. **[Facade](2.structural/5.facade/):** A single class that represents an entire complex system.
6. **[Flyweight](2.structural/6.flyweight/):** Minimize memory usage by sharing as much data as possible with similar objects.
7. **[Proxy](2.structural/7.proxy/):** Provides a surrogate object, which references to other object.

## 3. Behavioral Design Patterns

These patterns deal with the process of communication, managing relationships, and responsibilities between objects. There are as follows:

1. **[Chain of Responsibility](3.behavioral/1.chain-of-responsibility/):** Passes a request among a list or chain of objects.
2. **[Command](3.behavioral/2.command/):** Wraps a request under an object as a command and passed to invoker object.
3. **[Interpreter](3.behavioral/3.interpreter/):** Implements an expression interface to interpret a particular context.
4. **[Iterator](3.behavioral/4.iterator/):** Provides a way to access the elements of a collection object in sequential manner without knowing its underlying structure.
5. **[Mediator](3.behavioral/5.mediator/):** Allows multiple objects to communicate with each other’s without knowing each other’s structure.
6. **[Memento](3.behavioral/6.memento/):** Capture the current state of an object and store it in such a manner that it can be restored at a later time without breaking the rules of encapsulation.
7. **[Observer](3.behavioral/7.observer/):** Allows an object (subject) to publish changes to its state and other objects (observer) that depend upon that object are automatically notified of any changes to the subject's state.
8. **[State](3.behavioral/8.state/):** Alters the behavior of an object when it’s internal state changes.
9. **[Strategy](3.behavioral/9.strategy/):** Allows a client to choose an algorithm from a family of algorithms at run-time and gives it a simple way to access it.
10. **[Visitor](3.behavioral/10.visitor/):** Creates and performs new operations onto a set of objects without changing the object structure or classes.
11. **[Template Method](3.behavioral/11.template-method/):** Defines the basic steps of an algorithm and allow the implementation of the individual steps to be changed.

## License

MIT
