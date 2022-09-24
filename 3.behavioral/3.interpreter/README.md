# Interpreter Pattern

## Definition

Given a language, the Interpreter design pattern defines a representation for its grammar along with an interpreter that uses the representation to interpret sentences in the language.

## UML

![UML of Interpreter](uml.png)

## How to Implement

1. Decide if a "little language" offers a justifiable return on investment.
2. Define a grammar for the language.
3. Map each production in the grammar to a class.
4. Organize the suite of classes into the structure of the Composite pattern.
5. Define an interpret(Context) method in the Composite hierarchy.
6. The Context object encapsulates the current state of the input and output as the former is parsed and the latter is accumulated. It is manipulated by each grammar class as the "interpreting" process transforms the input into the output.
