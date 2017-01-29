# IClonable-interface
Handy examples about IClonable interface in C#

![5849279_orig](https://cloud.githubusercontent.com/assets/25085025/22400041/23b9f626-e5c4-11e6-9484-afd576010c5b.jpg)

###### [A note from msdn.microsoft.com] (https://msdn.microsoft.com/en-us/library/system.icloneable(v=vs.110).aspx)
The ICloneable interface simply requires that your implementation of the Clone method return a copy of the current object instance. It does not specify whether the cloning operation performs a deep copy, a shallow copy, or something in between. Nor does it require all property values of the original instance to be copied to the new instance.

`Object.MemberwiseClone()` creates a **shallow** copy of the current Object. It copys the inheritance graph deeply, though associations it copys superficially, so we deal here with not-full copying!

In this example, the copying would be deep as it will profoundly copy the whole inheritance graph:
```csharp
class A { public int a = 1; }
class B : A { public int b = 2; }
class C : B { public int c = 3; }
class X : C, ICloneable
{
    public object Clone()
    {
        return this.MemberwiseClone();
    }
}
```
And if we change the values of the clone, it doesn't affect the original ones.
```csharp
var clone = (X)original.Clone();
clone.a = clone.b = clone.c = 7;
```
<img width="257" alt="594c6e16f83813364be7fd8fd113e359" src="https://cloud.githubusercontent.com/assets/25085025/22400112/da88de66-e5c5-11e6-9564-68fd29d9a027.png">

This assertion is not true when we handle associations like shown in the example below:
```csharp
class A { public int a = 1; }
class B { public int b = 2; }

class C
{
    public A A = new A();
    public B B = new B();
}

class X : C, ICloneable
{
    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public override string ToString()
    {
        return $"{this.A.a} {this.B.b}";
    }
}
```

In this case when we change the values of A.a and B.b from clone object, it directly alters the values in original, because `MemberwiseClone()` doesn't copy associations, so you'll have access to A.a and B.b both from original and clone objects.

```javascript
clone.A.a = clone.B.b = 7;
```
<img width="157" alt="8b257288e0c1e74c13eea0be86a11b30" src="https://cloud.githubusercontent.com/assets/25085025/22400165/1486b56a-e5c7-11e6-8f61-6d25464eaf54.png">

The last question that we will treat in our example is if `MemberwiseClone()` uses class constructor while cloning or not.
So, to answer this question we have took a timer that will calculate the amount of ticks that takes an object constructor and the `MemberwiseClone()` method.

```csharp
public MyClass()
{
    Thread.Sleep(1000);
    var r1 = new Random().Next(1, 101); //some work
    Thread.Sleep(1000);
    var r2 = new Random().Next(1, 201); //some work
}

public object Clone()
{
     return this.MemberwiseClone();
}
```
We'll be comparing these two "methods" :bowtie: . Here are the results:
<img width="324" alt="535d474f6e06a1b0a1586fb7cc3b6a98" src="https://cloud.githubusercontent.com/assets/25085025/22400206/182bb8a4-e5c8-11e6-8c4a-edb413a5190f.png">

__Conclusion__: `MemberwiseClone()` has its own mechanisms to clone objects, it certainly doesn't use class constructor.

## Keywords
**C# 6.0, .Net Framework 4.6**
