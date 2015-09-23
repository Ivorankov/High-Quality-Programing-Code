# Creational patterns homework

## Template 

### Motivation
If we take a look at the dictionary definition of a template we can see that a template is a preset format, used as a starting point for a particular application so that the format does not have to be recreated each time it is used.
On the same idea is the template method is based. A template method defines an algorithm in a base class using abstract operations that subclasses override to provide concrete behavior.

### Intent
- Define the skeleton of an algorithm in an operation, deferring some steps to subclasses.
- Template Method lets subclasses redefine certain steps of an algorithm without letting them to change the algorithm's structure.

### Implementation

![alt text](http://www.codeproject.com/KB/architecture/482196/myTemplate.jpg "Template parretn diagram")

- AbstractClass - defines abstract primitive operations that concrete subclasses define to implement steps of an algorithm.
Implements a template method which defines the skeleton of an algorithm. The template method calls primitive operations as well as operations defined in AbstractClass or those of other objects.


- ConcreteClass - implements the primitive operations to carry out subclass-specific steps of the algorithm.
When a concrete class is called the template method code will be executed from the base class while for each method used inside the template method will be called the implementation from the derived class.

```
using System;

namespace DoFactory.GangOfFour.Template.Structural
{
  class MainApp
  {
    static void Main()
    {
      AbstractClass aA = new ConcreteClassA();
      aA.TemplateMethod();
      AbstractClass aB = new ConcreteClassB();
      aB.TemplateMethod();
      Console.ReadKey();
    }

  }

  abstract class AbstractClass
  {
    public abstract void PrimitiveOperation1();

    public abstract void PrimitiveOperation2();

    public void TemplateMethod()
    {
      PrimitiveOperation1();
      PrimitiveOperation2();
      Console.WriteLine("");
    }

  }

  class ConcreteClassA : AbstractClass
  {
    public override void PrimitiveOperation1()
    {
      Console.WriteLine("ConcreteClassA.PrimitiveOperation1()");
    }

    public override void PrimitiveOperation2()
    {
      Console.WriteLine("ConcreteClassA.PrimitiveOperation2()");
    }

  }

  class ConcreteClassB : AbstractClass
  {
    public override void PrimitiveOperation1()
    {
      Console.WriteLine("ConcreteClassB.PrimitiveOperation1()");
    }
    
    public override void PrimitiveOperation2()
    {
      Console.WriteLine("ConcreteClassB.PrimitiveOperation2()");
    }
    
  }
}
```

### Use
The Template Method pattern is used when: 
- implimenting the invariant parts of an algorithm once and leave it up to subclasses to implement the behavior that can vary.


- when refactoring is performed and common behavior is identified among classes. A abstract base class containing all the common code (in the template method) should be created to avoid code duplication.

## Command 

### Motivation
The Command design pattern encapsulates commands (method calls) in objects allowing us to issue requests without knowing the requested operation or the requesting object. Command design pattern provides the options to queue commands, undo/redo actions and other manipulations.

### Intent
- encapsulate a request in an object
- allows the parameterization of clients with different requests
- allows saving the requests in a queue

### Implementation
![alt text](https://mushfiqrazib.files.wordpress.com/2012/05/command_pattern_uml_diagram.png "Command parretn diagram")
- Command - declares an interface for executing an operation;
- ConcreteCommand - extends the Command interface, implementing the Execute method by invoking the corresponding operations on Receiver. It defines a link between the Receiver and the action.
- Client - creates a ConcreteCommand object and sets its receiver;
- Invoker - asks the command to carry out the request;
- Receiver - knows how to perform the operations;

```
using System;

namespace DoFactory.GangOfFour.Command.Structural
{
  class MainApp
  {
    static void Main()
    {
      Receiver receiver = new Receiver();
      Command command = new ConcreteCommand(receiver);
      Invoker invoker = new Invoker();
      invoker.SetCommand(command);
      invoker.ExecuteCommand();
      Console.ReadKey();
    }
    
  }

  abstract class Command
  {
    protected Receiver receiver;

    public Command(Receiver receiver)
    {
      this.receiver = receiver;
    }
    
    public abstract void Execute();
  }

  class ConcreteCommand : Command
  {
    public ConcreteCommand(Receiver receiver) 
    : base(receiver)
    {
    }
    
    public override void Execute()
    {
      receiver.Action();
    }

  }

  class Receiver
  {
    public void Action()
    {
      Console.WriteLine("Called Receiver.Action()");
    }

  }

  class Invoker
  {
    private Command command;

    public void SetCommand(Command command)
    {
      this.command = command;
    }

    public void ExecuteCommand()
    {
      command.Execute();
    }
    
  }
} 
```

### Use

The Command pattern is used when:
- parameterizes objects depending on the action they must perform
- specifies or adds in a queue and executes requests at different moments in time
- offers support for undoable actions (the Execute method can memorize the state and allow going back to that state)
- structures the system in high level operations that based on primitive operations
- decouples the object that invokes the action from the object that performs the action. Due to this usage it is also known as Producer - Consumer design pattern.

## Mediator

### Motivation
The Mediator design pattern defines an object that encapsulates how a set of objects interact with each other.

### Intent
Define an object that encapsulates how a set of objects interact. Mediator promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently.
The participants classes in this pattern are:


### Implementation
![alt text](http://www.dofactory.com/images/diagrams/net/mediator.gif "Mediator parretn diagram")

- Mediator - defines an interface for communicating with Colleague objects.
 
- ConcreteMediator - knows the colleague classes and keep a reference to the colleague objects.
    Implements the communication and transfer the messages between the colleague classes
    
- Colleague classes - keep a reference to its Mediator object
     Communicates with the Mediator whenever it would have otherwise communicated with another Colleague. 
     
``` using System;

namespace Mediator
{
  class MainApp
  {
    static void Main()
    {
      ConcreteMediator m = new ConcreteMediator();
      ConcreteColleague1 c1 = new ConcreteColleague1(m);
      ConcreteColleague2 c2 = new ConcreteColleague2(m);
      m.Colleague1 = c1;
      m.Colleague2 = c2;

      c1.Send("How are you?");
      c2.Send("Fine, thanks");
      Console.ReadKey();
    }
  }

  abstract class Mediator
  {
    public abstract void Send(string message, Colleague colleague);
  }

  class ConcreteMediator : Mediator
  {
    private ConcreteColleague1 colleague1;

    private ConcreteColleague2 colleague2;

    public ConcreteColleague1 Colleague1
    {
      set { colleague1 = value; }
    }
    
    public ConcreteColleague2 Colleague2
    {
      set { colleague2 = value; }
    }

    public override void Send(string message, Colleague colleague)
    {
      if (colleague == colleague1)
      {
        colleague2.Notify(message);
      }
      else
      {
        colleague1.Notify(message);
      }
    }
    }
    
    abstract class Colleague
  {
    protected Mediator mediator;

    public Colleague(Mediator mediator)

    {
      this.mediator = mediator;
    }

  }

  class ConcreteColleague1 : Colleague
  {
    public ConcreteColleague1(Mediator mediator)
      : base(mediator)
    {
    }

    public void Send(string message)
    {
      mediator.Send(message, this);
    }

    public void Notify(string message)
    {
      Console.WriteLine("Colleague1 gets message: " + message);
    }
    
  }

  class ConcreteColleague2 : Colleague
  {
    public ConcreteColleague2(Mediator mediator)
      : base(mediator)
    {
    }

    public void Send(string message)
    {
      mediator.Send(message, this);
    }
    
    public void Notify(string message)
    {
      Console.WriteLine("Colleague2 gets message: " + message);
    }
    
  } 
  ```

     
   
    

### Use
The Mediator design pattern is used when:

- A set of objects communicate in well-defined but complex ways. The resulting interdependencies are unstructured and difficult to understand.
- reusing an object is difficult because it refers to and communicates with many other objects.
- a behavior that's distributed between several classes should be customizable without a lot of subclassing.

## Memento

### Motivation
It is sometimes necessary to capture the internal state of an object at some point and have the ability to restore the object to that state later in time. Such a case is useful in case of error or failure.

### Intent
The intent of this pattern is to capture the internal state of an object without violating encapsulation and thus providing a mean for restoring the object into initial state when needed.


### Implementation
![alt text](http://www.codeproject.com/KB/architecture/455228/memento.jpg "Memento parretn diagram")
- Memento Stores internal state of the Originator object. The state can include any number of state variables. The Memento must have two interfaces, an interface to the caretaker. This interface must not allow any operations or any access to internal state stored by the memento and thus honors encapsulation. The other interface is to the originator and allows the originator to access any state variables necessary to for the originator to restore previous state.
- Originator Creates a memento object capturing the originators internal state. Use the memento object to restore its previous state.
- Caretaker Responsible for keeping the memento. The memento is opaque to the caretaker, and the caretaker must not operate on it.

```
using System;

namespace Memento
{
  class MainApp
  {
    static void Main()
    {
      Originator o = new Originator();
      o.State = "On";
      Caretaker c = new Caretaker();
      c.Memento = o.CreateMemento();
      o.State = "Off";
      o.SetMemento(c.Memento);
      Console.ReadKey();
    }

  }

  class Originator
  {
    private string state;
    
    public string State
    {
      get { return _state; }
      
      set
      {
        state = value;
        Console.WriteLine("State = " + _state);
      }

    }

    public Memento CreateMemento()
    {
      return (new Memento(_state));
    }

    public void SetMemento(Memento memento)
    {
      Console.WriteLine("Restoring state...");
      State = memento.State;
    }

  }

  class Memento
  {
    private string state;

    public Memento(string state)
    {
      this.state = state;
    }

    public string State
    {
      get { return _state; }
    }
    
  }

  class Caretaker
  {
    private Memento memento;

    public Memento Memento
    {
      set { memento = value; }

      get { return _memento; }
    }
    
  }
}
```


### Use
The Memento design pattern is used when:

- a snapshot of an object's state must be captured so that it can be restored to that state later and in situations where explicitly passing the state of the object would violate encapsulation. 

