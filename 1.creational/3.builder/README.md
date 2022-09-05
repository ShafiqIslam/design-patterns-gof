# Builder Pattern

## Definition

Builder pattern aims to **“Separate the construction of a complex object from its representation so that the same construction process can create different representations.”** It is used to construct a complex object step by step and the final step will return the object. The process of constructing an object should be generic so that it can be used to create different representations of the same object.

## UML

![UML of Builder](uml.jpg)

## How to Implement

1. Identify a Product which requires complex initialization steps, or maybe a long constructor parameter list.
2. Create a builder class containing those steps.
3. The builder class can be abstract to hold the same construction logic for different representations of product.
4. The builder will contain a final step to get the concrete product.
5. Create a Director if the construction logic needs to be isolated, otherwise clients can directly use builder.
