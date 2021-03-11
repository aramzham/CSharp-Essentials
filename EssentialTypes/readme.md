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

## ConcurrentBag<T>
   * Useful for storing objects when ordering doesn't matter.
   * Unlike sets, bags **do** support duplicates.
   * Unlike sets, bags **do not** support Contains, Remove, etc.
   * All public and protected members are thread-safe and may be used concurrently from multiple threads.
   * Optimized for scenarios where the same thread will be both producing and consuming data stored in the bag.
   * Under the hood creates a new list and uses its enumerator
   * Count, GetEnumerator, etc. freeze the collection

## ConcurrentDictionary<TKey, TValue>
   * Implements IDictionary<TKey, TValue> interface.
   * Provides the following additional methods: TryAdd, TryUpdate, AddOrUpdate, GetOrAdd
   * Uses fine-grained locking when adding to or updating data in the dictionary, but it's entirely lock-free for read operations.
   * Conceptually uses hash table to store elements internally.
   * Enumeration **does not** represent a moment-in-time snapshot of the contents of the bag.
   * The contents exposed through the enumerator may contain modifications made to the dictionary after GetEnumerator was called.
   * The enumerator is safe to use concurrently with reads from and writes to the dictionary.
   * Under the hood uses Iterator method and yield returns elements stored in the internal data structure.

## IProducerConsumerCollection<T>
   * Defines methods to manipulate thread-safe collections intended for producer/consumer usage (one thread adds jobs, another takes and does them).
   * For example: TryAdd(T), TryTake(T), GetEnumerator, etc.
   * Provides a unified representation for producer/consumer collections so that higher level abstractions such as BlockingCollection<T> can use the colleciton as the underlying storage mechanism.

## BlockingCollection<T>
   * Provides blocking and bounding capabilities for thread-safe collections that implement IProducerConsumerCollection<T>.
   * Allows removal attempts from the collection to block until is available to be removed.
   * A producing thread can call the *CompleteAdding* method to indicate that no more items will be added (all waiting threads will be released).
   * Can enforce an upper bound on the number of data elements allowed in the collection; addition attempts to the collection may then block until space is available.
