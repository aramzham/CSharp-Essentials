# Polymorphism

#### This is app is going to illustrate you how the methods are called when they are invoked from an instance of a base class, from an instance of derived class and from an instance of a derived class casted to base class.

Polymorphism is often referred to as the third pillar of object-oriented programming, after encapsulation and inheritance. Polymorphism is a Greek word that means "many-shaped" and it has two distinct aspects:
* At run time, objects of a derived class may be treated as objects of a base class in places such as method parameters and collections or arrays. When this occurs, the object's declared type is no longer identical to its run-time type.
* Base classes may define and implement virtualmethods, and derived classes can override them, which means they provide their own definition and implementation. At run-time, when client code calls the method, the CLR looks up the run-time type of the object, and invokes that override of the virtual method. Thus in your source code you can call a method on a base class, and cause a derived class's version of the method to be executed.

In this example we have 5 types of methods:
```javascript
class Base
{
    public virtual void F1()
    {
        Console.WriteLine("Base F1 is called");
    }
    public virtual void F2()
    {
        Console.WriteLine("Base F2 is called");
    }
    public virtual void F3()
    {
        Console.WriteLine("Base F3 is called");
    }
    public void F4()
    {
        Console.WriteLine("Not virtual F4 base method is called");
    }
    public void F5()
    {
        Console.WriteLine("Not virtual F5 base method is called");
    }
}
```
These methods are also present in derived class:
```csharp
class Derived : Base
{
    public override void F1()
    {
        Console.WriteLine("Derived F1 is called");
    }
    public new void F2()
    {
        Console.WriteLine("Derived F2 is called with new");
    }
    public void F3()
    {
        Console.WriteLine("Derived F3 is called without a keyword");
    }
    public new void F4()
    {
        Console.WriteLine("Derived F4 with new is called");
    }
    public void F5()
    {
        Console.WriteLine("Derived F5 is called with same name and without keyword");
    }
}
```

The ultimate result of invoking those methods differently:
![capture](https://cloud.githubusercontent.com/assets/25085025/22501482/6d273f9c-e882-11e6-8796-692c100610d4.JPG)


## Keywords
> C# 6.0,
> .Net Framework 4.6
