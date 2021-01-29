using System;

var dt = DateTime.Now;
var o1 = new { name = "A1", dt.Year };
var o2 = new { name = "A1", dt.Year };

if (o1.Equals(o2))
    Console.WriteLine("Equals");

Console.WriteLine($"hashcode are same: {o1.GetHashCode() == o2.GetHashCode()}");

var o3 = o1;
// anonymous types are created as classes
if (ReferenceEquals(o1, o3))
    Console.WriteLine("Reference equals");

(string Name, int Age) a = ("Name1", 22);
(string Name, int Age) b = ("Name1", 22);

if (a.Equals(b))
    Console.WriteLine("Equals");

Console.WriteLine($"hashcode are same: {a.GetHashCode() == b.GetHashCode()}");

var c = a;
// tuples are value types
if (ReferenceEquals(a, c))
    Console.WriteLine("Reference equals");

var d = ("Name2", 8);
var e = (Name: "Name3", Country: "Barbados");

Console.ReadKey();