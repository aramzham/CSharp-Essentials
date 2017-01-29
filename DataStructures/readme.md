We are creating a custom collection and implementing some necessary functionality like `Add`, `Remove`, `RemoveAt`, `IndexOf` and many more.
`MyList` will have 3 constructors:
```javascript
1. public MyList() : this(0)
2. public MyList(int length)
3. public MyList(ICollection<T> collection)
```
For more detailed description, please, take a look at the code.

The purpose of this project is to understand which algorithms work under different data structures (f.e. dynamic arrays). And this will help to strenghten your knowledge of custom user collections in **C#**.

One thing that caught my attention most was that under many types of collections (f.e. List<T>) there is a simple immutable array hidden. When we're adding items in our list and hitting the borders of the underlying array, it calls a function like `GrowArray()` that takes two times larger array and copys values from old array into the new one. It is performed so fastly that we have the illusion that the items are added dynamicly.

```javascript
private void GrowArray()
{
    var newSize = array.Length == 0 ? 4 : array.Length * 2;
    var newArray = new T[newSize];
    Array.Copy(array, 0, newArray, 0, array.Length);
    array = newArray;
}
```
