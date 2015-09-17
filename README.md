# Structural pattern homework

## Bridge

### Motivation 
Sometimes an abstraction should have different implementations; consider an object that handles persistence of objects over different platforms using either relational databases or file system structures (files and folders). A simple implementation might choose to extend the object itself to implement the functionality for both file system and RDBMS. However this implementation would create a problem: Inheritance binds an implementation to the abstraction and thus it would be difficult to modify, extend, and reuse abstraction and implementation independently.

### Intent 
The intent of this pattern is to decouple abstraction from implementation so that the two can vary independently.

### Implementation
![alt text](http://jpsampige.files.wordpress.com/2011/07/bridgepattern1.png "Diagram of Bridge design pattern")

The participants classes in the bridge pattern are:
   - Abstraction - Abstraction defines abstraction interface.
   
   - AbstractionImpl - Implements the abstraction interface using a reference to an object of type Implementor.
   
    - Implementor - Implementor defines the interface for implementation classes. This interface does not need to correspond directly to abstraction interface and can be very different. Abstraction imp provides an implementation in terms of operations provided by Implementor interface.
    
  - ConcreteImplementor1, ConcreteImplementor2 - Implements the Implementor interface.

    
``` C#
using System;

namespace Bridge
{
  class MainApp
  {
    static void Main()
    {
      Abstraction ab = new RefinedAbstraction();

      ab.Implementor = new ConcreteImplementorA();

      ab.Operation();

      ab.Implementor = new ConcreteImplementorB();

      ab.Operation();

      Console.ReadKey();
      
    }   
  }

  class Abstraction
  {
    protected Implementor implementor;

    public Implementor Implementor
    {
      set { implementor = value; }
    }
    
    public virtual void Operation()
    {
      implementor.Operation();
    }
    
  }

  abstract class Implementor
  {
    public abstract void Operation();
  }

  class RefinedAbstraction : Abstraction
  {
    public override void Operation()
    {
      implementor.Operation();
    }
    
  }

  class ConcreteImplementorA : Implementor
  {
    public override void Operation()
    {
      Console.WriteLine("ConcreteImplementorA Operation");
    }
    
  }

  class ConcreteImplementorB : Implementor
  {
    public override void Operation()
    {
      Console.WriteLine("ConcreteImplementorB Operation");
    }

  }
}
```

### Use
The bridge pattern is used when there is a need to avoid permanent binding between an abstraction and an implementation and when the abstraction and implementation need to vary independently. Using the bridge pattern would leave the client code unchanged with no need to recompile the code.

### Issiues

## Proxy

### Motivation 

The Proxy pattern is used to control the access to an object. For example if we need to use only a few methods of some costly objects we'll initialize those objects when we need them entirely. Until that point we can use some light objects exposing the same interface as the heavy objects. These light objects are called proxies and they will instantiate those heavy objects when they are really need and by then we'll use some light objects instead.

This ability to control the access to an object can be required for a variety of reasons: controlling when a costly object needs to be instantiated and initialized, giving different access rights to an object, as well as providing a sophisticated means of accessing and referencing objects running in other processes, on other machines.

### Intent 
The intent of this pattern is to provide a "Placeholder" for an object to control references to it.

### Implementation
![alt text](http://www.dofactory.com/images/diagrams/net/proxy.gif "Diagram of Proxy design pattern")

The participants classes in the proxy pattern are:

- Subject:
  Interface implemented by the RealSubject and representing its services. The interface must be implemented by the proxy as well so that the proxy can be used in any location where the RealSubject can be used.
  
- Proxy:
         Maintains a reference that allows the Proxy to access the RealSubject.
        Implements the same interface implemented by the RealSubject so that the Proxy can be substituted for the
        
- RealSubject:
        Controls access to the RealSubject and may be responsible for its creation and deletion.
        Other responsibilities depend on the kind of proxy.
    RealSubject - the real object that the proxy represents.
    
    using System;

 
``` C#
using System;

namespace Proxy
{
  class MainApp
  {
    static void Main()
    {
      Proxy proxy = new Proxy();

      proxy.Request();
      
      Console.ReadKey();
    }
    
  }

  abstract class Subject
  {
    public abstract void Request();
  }

  class RealSubject : Subject
  {
    public override void Request()

    {
      Console.WriteLine("Called RealSubject.Request()");
    }
    
  }

  class Proxy : Subject
  {
    private RealSubject realSubject;

    public override void Request()
    {
      if (_realSubject == null)
      {
        realSubject = new RealSubject();
      }
      
      realSubject.Request();
    }
  }
}
``` 

### Use
The Proxy design pattern is applicable when there is a need to control access to an Object, as well as when there is a need for a sophisticated reference to an Object. Common Situations where the proxy pattern is applicable are:

Virtual Proxies: delaying the creation and initialization of expensive objects until needed, where the objects are created on demand (For example creating the RealSubject object only when the doSomething method is invoked).

Remote Proxies: providing a local representation for an object that is in a different address space. A common example is Java RMI stub objects. The stub object acts as a proxy where invoking methods on the stub would cause the stub to communicate and invoke methods on a remote object (called skeleton) found on a different machine.

Protection Proxies: where a proxy controls access to RealSubject methods, by giving access to some objects while denying access to others.

Smart References: providing a sophisticated access to certain objects such as tracking the number of references to an object and denying access if a certain number is reached, as well as loading an object from database into memory on demand.


## Decorator

### Intent 

The decorator pattern is used to extend (decorate) the functionality of a certain object statically, or in some cases at run-time, independently of other instances of the same class, provided some groundwork is done at design time. This is achieved by designing a new decorator class that wraps the original class.

This pattern is designed so that multiple decorators can be stacked on top of each other, each time adding a new functionality to the overridden method(s).

### Implementation
![alt text](http://eysermans.com/images/articles/a-design-pattern-a-day-the-decorator-pattern/500px-Decorator_UML_class_diagram.png "Diagram of Decorator design pattern")

- Component: This is an interface containing members that will be implemented by ConcreteClass and Decorator.

- ConcreteComponent: This is a class which implements the Component interface.

- Decorator: This is an abstract class which implements the Component interface and contains the reference to a Component instance. This class also acts as base class for all decorators for components.

- ConcreteDecorator: This is a class which inherits from Decorator class and provides a decorator for components.
``` C#
using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Decorator.RealWorld
{
  class MainApp
  {
    static void Main()
    {
      Book book = new Book("Worley", "Inside ASP.NET", 10);

      book.Display();

      Video video = new Video("Spielberg", "Jaws", 23, 92);

      video.Display();
      
      Console.WriteLine("\nMaking video borrowable:");

      Borrowable borrowvideo = new Borrowable(video);

      borrowvideo.BorrowItem("Customer #1");

      borrowvideo.BorrowItem("Customer #2");

      borrowvideo.Display();

      Console.ReadKey();
    }
  }

  abstract class LibraryItem
  {
    private int _numCopies;

    public int NumCopies
    {
      get { return _numCopies; }
      
      set { _numCopies = value; }
    }
    public abstract void Display();
  }

  class Book : LibraryItem
  {
    private string _author;

    private string _title;

    public Book(string author, string title, int numCopies)
    {
      this._author = author;
      this._title = title;
      this.NumCopies = numCopies;
    }

    public override void Display()
    {
      Console.WriteLine("\nBook ------ ");
      Console.WriteLine(" Author: {0}", _author);
      Console.WriteLine(" Title: {0}", _title);
      Console.WriteLine(" # Copies: {0}", NumCopies);
    }
    
  }

  class Video : LibraryItem
  {
    private string _director;

    private string _title;

    private int _playTime;
    
    public Video(
    string director,
    string title,
    int numCopies,
    int playTime)
    {
      this._director = director;
      this._title = title;
      this.NumCopies = numCopies;
      this._playTime = playTime;
    }

    public override void Display()
    {
      Console.WriteLine("\nVideo ----- ");

      Console.WriteLine(" Director: {0}", _director);

      Console.WriteLine(" Title: {0}", _title);

      Console.WriteLine(" # Copies: {0}", NumCopies);

      Console.WriteLine(" Playtime: {0}\n", _playTime);
    }
  }

  abstract class Decorator : LibraryItem
  {
    protected LibraryItem libraryItem;

    public Decorator(LibraryItem libraryItem)
    {
      this.libraryItem = libraryItem;
    }

    public override void Display()
    {
      libraryItem.Display();
    }
    
  }

  class Borrowable : Decorator
  {
    protected List<string> borrowers = new List<string>();

    public Borrowable(LibraryItem libraryItem)
      : base(libraryItem)
    {
    
    }

    public void BorrowItem(string name)
    {
      borrowers.Add(name);
      
      libraryItem.NumCopies--;
    }

 

    public void ReturnItem(string name)
    {
      borrowers.Remove(name);

      libraryItem.NumCopies++;

    }

    public override void Display()
    {
      base.Display();

      foreach (string borrower in borrowers)
      {
        Console.WriteLine(" borrower: " + borrower);
      }

    }
  }
}
```

### Use
The Decorator pattern is used to add functionality to a class, preventing class explosion (high amount of similar classes).
