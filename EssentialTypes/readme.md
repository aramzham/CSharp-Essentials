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
