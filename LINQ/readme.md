## LINQ

Well, LINQ is a powerful tool that faciliates the developer's work. It consists of useful extension methods that will make your life easier when working with collections.
I'll give you an example.

__How can you find number of the elements starting by "A" in a collection?__
Probably like this:
```csharp
for(int i = 0; i < collection.Length; i++)
{
  if(collection[i].StartsWith("A"))
  {
    count++;
  }
}
return count;
```
No one would argue that this will work flawlessly. But take a look how LINQ deals with that problem:

```csharp
int count = collection.Count(i => i.StartsWith("A"));
```
That's it! Nothing more needed. :+1:

Personally, i like this one-line solutions. Still, it's a matter of taste :)
