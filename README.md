# Creational patterns homework

## Singleton

### Motivation
Sometimes it's important to have only one instance for a class. For example, in a system there should be only one window manager (or only a file system or only a print spooler). Usually singletons are used for centralized management of internal or external resources and they provide a global point of access to themselves.

The singleton pattern is one of the simplest design patterns: it involves only one class which is responsible to instantiate itself, to make sure it creates not more than one instance; in the same time it provides a global point of access to that instance. In this case the same instance can be used from everywhere, being impossible to invoke directly the constructor each time.


### Intent

Ensure that only one instance of a class is created and provide a global point of access to the object.


### Implementation

The implementation involves a static member in the "Singleton" class, a private constructor and a static public method that returns a reference to the static member. The Singleton Pattern defines a getInstance operation which exposes the unique instance which is accessed by the clients. getInstance() is is responsible for creating its class unique instance in case it is not created yet and to return that instance.

![alt text](http://www.oodesign.com/images/design_patterns/creational/singleton_implementation_-_uml_class_diagram.gif "Diagram of Singleton pattern")

```
using System;

namespace Singleton
{
  class MainApp
  {
    static void Main()
    {
      Singleton s1 = Singleton.Instance();
      Singleton s2 = Singleton.Instance();

      // Test for same instance
      if (s1 == s2)
      {
        Console.WriteLine("Objects are the same instance");
      }

    }
  }
  
  class Singleton
  {
    private static Singleton instance;

    protected Singleton()
    {
    }

    public static Singleton Instance()
    {
      // Uses lazy initialization.
      // Note: this is not thread safe.
      if (instance == null)
      {
        instance = new Singleton();
      }

      return instance;
    }
  }
}
```

### Use 
The Abstract Factory, Builder, and Prototype patterns can use Singletons in their implementation. Facade objects are often singletons because only one Facade object is required. State objects are often singletons. Singletons are often preferred to global variables because they do not pollute the global namespace (or, in languages with namespaces, their containing namespace) with unnecessary variables and they permit lazy allocation and initialization, whereas global variables in many languages will always consume resources.
I'm no good at writing sample / filler text, so go write something yourself.

### Issues
Singleton introduces tight coupling among collaborating classes also Singleton classes are also difficult to test. 
Also Singleton breaks the single responsibility principle - they control their own creation and lifecycle.

## Factory method

### Motivation

The factory method pattern is the best-known use of factories and factory methods a class implementing an interface, or derived class, implements a factory method.

### Intent
Define an interface for creating an object, but let subclasses decide which class to instantiate.
Lets a class defer instantiation to subclasses

### Implementation
Two major varieties - Creator declares ABSTRACT factory method and ConcreteCreator that implements it.
Creator defines a default implementation for factory method.
Parameterized factory methods let the factory method create multiple kinds of objects
factory methods takes a parameter: a kind of object to create all products have to share a Product interface
![alt text](http://javatechig.com/wp-content/uploads/2014/11/Factory-Method-Design-Pattern.png "Diagram of Factiry Method pattern")
```

public interface ICar
{
    string GetName();
}

public class Sedan : ICar
{

    public string GetModel()
    {
        return "Vroom Vroom";
    }

}

public class Cabrio : ICar
{

    public string GetModel()
    {
        return "Grrr GT40";
    }

}

public enum CarType
{
    Eco,
    Sport
}

public class Factory
{
    public ICar GetCars(CarType type)
    {
        ICar cars = null;
        switch (type)
        {
            case CarType.Eco :
                cars = new Sedan();
                break;
            case CarType.Sport:
                cars = new Cabrio();
                break;
            default:
                break;
        }
        return cars;
    }
}
```
### Use
The Factory Method pattern is used when 
* a class wants its subclasses to specify the object it creates
* a class can’t anticipate the class of objects it must create
* classes delegate responsibility to one of several helper subclasses, and you want to localize the knowledge of which helper subclass is the delegate

### Issiues

The factory has to be used for a family of objects. If the classes doesn't extend common base class or interface they can not be used in a factory design template.

## Builder

### Motivation

It is a pattern for step-by-step creation of a complex object so that the same construction process can create different representations is the routine in the builder pattern that also makes for finer control over the construction process. All the different builders generally inherit from an abstract builder class that declares the general functions to be used by the director to let the builder create the product in parts.

### Intent

The intent is to separate the construction of a complex object from its representation so that the same construction process can create different representations.

### Implementation

The Builder design pattern uses the Factory Builder pattern to decide which concrete class to initiate in order to build the desired type of object
There are 4 components to it:
* The Builder class specifies an abstract interface for creating parts of a Product object.
* The ConcreteBuilder constructs and puts together parts of the product by implementing the Builder interface. It defines and keeps track of the representation it creates and provides an interface for saving the product.
* The Director class constructs the complex object using the Builder interface.
* The Product represents the complex object that is being built.

![alt text](https://j2eethoughts.files.wordpress.com/2010/09/builder.jpg "Diagram of Builder Method pattern")

### Use

Builder patterns are used when the desierd object has too many peaces that need to be implimented
