## Hash Tables
------------------------------------------------------------------------------------------------------------------------------------------
Each element is a key/value pair stored in a DictionaryEntry object. A key cannot be null, but a value can be.
The objects used as keys by a Hashtable are required to override the Object.GetHashCode method (or the IHashCodeProvider interface) and the Object.Equals method (or the IComparer interface). The implementation of both methods and interfaces must handle case sensitivity the same way; otherwise, the Hashtable might behave incorrectly. For example, when creating a Hashtable, you must use the CaseInsensitiveHashCodeProvider class (or any case-insensitive IHashCodeProvider implementation) with the CaseInsensitiveComparer class (or any case-insensitive IComparer implementation).
Furthermore, these methods must produce the same results when called with the same parameters while the key exists in the Hashtable. An alternative is to use a Hashtable constructor with an IEqualityComparer parameter. If key equality were simply reference equality, the inherited implementation of Object.GetHashCode and Object.Equals would suffice.
Key objects must be immutable as long as they are used as keys in the Hashtable.

![450px-hash_table_5_0_1_1_1_1_1_ll svg](https://cloud.githubusercontent.com/assets/25085025/23308351/64160010-fac4-11e6-8876-6e889d0eca18.png)
