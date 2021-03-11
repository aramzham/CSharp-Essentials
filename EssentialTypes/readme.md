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

## Stack<T>
   * Represents a variable size last-in-first-out (LIFO) collection of instances of the same specified type
   * Peek and Pop are O(1) operations
   * Push is O(1) if the size is less than capacity, otherwise O(n)
   * Allows nulls and duplicate values
   * Implemented the same way as the List<T>
   * During enumeration:
      * Size and elements can't be modified
      * Element state can be modified

## Queue<T>
   * Represents a variable size first-in-first-out (FIFO) collection of instances of the same specified type
   * Peek and Dequeue are O(1) operations
   * Enqueue is O(1) if the size is less than capacity, otherwise O(n)
   * Allows nulls and duplicate values
   * Implemented as a circular array
   * During enumeration:
      * Size and elements can't be modified
      * Element state can be modified

## HashSet<T>
   * Data is stored in a hash table. Uses Object.GetHashCode as a hash function and the lower 31 bits of the hash code.
   * Object state used to define hash code must be immutable while object is in the HashSet.
   * Use HashCode.Combine to generate a good hash code for a type based on its fields.
   * Size is dynamically increased as required.
   * Capacity is always prime - during resizing the capacity is chosen as the next prime number greater than double of last capacity.
   * During enumeration:
      * order is not defined, iterates over slots array
      * elements can't added or removed
      * element state can be modified if hash code stays the same

## ConcurentStack<T>
   * Is a lock free, thread-safe LIFO collection of objects.
   * All public and protected members are thread-safe and may be used concurrently from multiple threads.
   * Uses only Interlocked (compare-and-swap, CAS) and spin locks.
   * Data is stored in a single-linked list of nodes

## ConcurrentQueue<T>
   * Is a lock-free, thread-safe FIFO collection of objects.
   * Uses only Interlocked (compare-and-swap, CAS) and spin locks.
   * Data is stored in a linked list of small arrays called segments.
   * **Enumeration of last two**
      * The enumeration represents a moment-in-time snapshot of the contents of the collection.
      * It does not reflect any updates to the collection after GetEnumerator was called
      * The enumerator is safe to use concurrently with reads from and writes to the collection
      * Under the hood uses iterator method and yield returns elements stored in the internal data structure.
