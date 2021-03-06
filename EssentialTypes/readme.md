## Array
* Provides methods for creating, manipulating, searching, and sorting arrays of homogeneneous objects.
* Serves as the base class for all arrays in the CLR.
* Only the system and compilers can explicitly derive from Array.
* Has fixed size, max 4 billion elements.
* Can be multidimensional, max 32 dimensions.
* Each dimension can have its lower bound (default is 0).

* IList size modifying methods throw NotSupportedException.
* Search, Sort, Reverse is not supported for multidimensional arrays
* Enumeration for multidimensional arrays starts with the least significant dimension.
* During enumeration:
    * array size cannot be modified (it's always fixed!)
    * array elements and their state can be modified

## List<T>
   * A strongly typed list of objects that can be accessed by index
   * Provides methods to search, sort and manipulate lists
   * Implements the IList<T> generic interface using an array whose size is dynamically increased as required
   * Mostly behaves like ArrayList and has the following benefits
      * Is type-safe
      * For value types compiler generates a specific implementation that avoids boxing/unboxing

## LinkedList<T>
   * Represents a doubly linked list
   * Item insertion/removal are O(1) operations
   * Doesn't support chaining, splitting or cycles
   * Internally nodes are kept in a cycle, however list.Last.Next == null and list.First.Previous == null
   * During enumeration:
      * Size can't be modified
      * Elements and/or their state can be modified
