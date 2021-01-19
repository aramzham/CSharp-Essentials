using System;
using System.Collections;
using System.Collections.Generic;

var animals = new Animal[] { new(), new() };
var objects = new object[1];
objects = animals;

//var animalList = new List<Animal>();
//var objectList = new List<object>();
//objectList = animalList;

Consumer<object> objectConsumer = PrintObject;
Consumer<Animal> animalConsumer = PrintAnimal;

//objectConsumer(new Animal()); // փոխանցվող տիպը կարող է լինել նաև ժառանգներից
animalConsumer = objectConsumer;

Producer<object> objectProducer = CreateObject;
Producer<Animal> animalProducer = CreateAnimal;

// object a = animalProducer(); // վերադարձվող տիպը կարող է լինել բազային կլասներից
objectProducer = animalProducer;

IGenericList2<object> objectList = new GenericList<object>(); // IGenericList2-ov linum a, IGenericList-ov chi linum
var animalList = new GenericList<Animal>();
objectList = animalList;

Console.ReadKey();

void PrintObject(object a) => Console.WriteLine($"{a.GetType()} is an object");
void PrintAnimal(Animal a) => Console.WriteLine($"{a.GetType()} is an animal");

object CreateObject() => new();
Animal CreateAnimal() => new();

public class Animal
{

}

public class Developer
{

}

delegate void Consumer<in T>(T param);
delegate T Producer<out T>();

interface IGenericList2<out T>
{
    T GetOne();
}

interface IGenericList<in T> // in u out irar het chen kara linel
{
    void Add(T t);
}

public class GenericList<T> : IGenericList<T>, IGenericList2<T> where T : class
{
    public void Add(T item) { }
    public T GetOne() => default;
}