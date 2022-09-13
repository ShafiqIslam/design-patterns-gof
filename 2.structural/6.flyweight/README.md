# Flyweight Pattern

## Definition

Flyweight design pattern is used when we need to create a lot of Objects of a class. Since every object consumes memory space that can be crucial for low memory devices, such as mobile devices or embedded systems, flyweight design pattern can be applied to reduce the load on memory by sharing objects.

To apply flyweight pattern, we need to divide Object property into **intrinsic** and **extrinsic** state. **Intrinsic State** (unique state per object) make the Object unique whereas **Extrinsic State** (repititive state of all objects) are set by client code and used to perform different operations. For example, an Object `Circle` can have extrinsic properties such as color and width. For applying flyweight pattern, we need to create a Flyweight factory that returns the shared objects. For our example, lets say we need to create a drawing with lines and ovals. So we will have an interface `Shape` and its concrete implementations as `Line` and `Oval`. `Oval` class will have intrinsic property to determine whether to fill the `Oval` with given color or not whereas `Line` will not have any intrinsic property.

## UML

![UML of Flyweight](uml.png)

## How to Implement

1. Divide fields of a class that will become a flyweight into two parts:
   1. the intrinsic state: the fields that contain unchanging data duplicated across many objects
   2. the extrinsic state: the fields that contain contextual data unique to each object
2. Leave the fields that represent the intrinsic state in the class, but make sure they’re immutable. They should take their initial values only inside the constructor.
3. Go over methods that use fields of the extrinsic state. For each field used in the method, introduce a new parameter and use it instead of the field.
4. Optionally, create a factory class to manage the pool of flyweights. It should check for an existing flyweight before creating a new one. Once the factory is in place, clients must only request flyweights through it. They should describe the desired flyweight by passing its intrinsic state to the factory.
5. The client must store or calculate values of the extrinsic state (context) to be able to call methods of flyweight objects. For the sake of convenience, the extrinsic state along with the flyweight-referencing field may be moved to a separate context class.
