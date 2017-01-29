Inheritance

Here are some good examples explaining the process of inheritance in C#.

In #FinancialOrganizations folder you'll see a basic FinancialInstitution class which will "give birth" to Banks, Credit organizations and Insurance companyies. All those institutions inherite all fields, properties and methods from base class. Meanwhile, they also add their own specific states and functionalities.

For example:
```javascript
public long Assets { get; set; }
public long Liabilities { get; set; } 
```
these properties are particular for Banks, so we add them in derived class(Bank).

The same logic applys to # ThreeDimensionalForms library. Ellipsoid and Parallelepiped are derived from base ThreeDShape class. This library allows you to create ellipsoid and parallelepiped objects and count their respective Volumes and outer Surfaces:
```javascript
var piped = new Parallelepiped(5.5,10,3.2,45,45);                 // for parallelepiped
Console.WriteLine($"Parapippo volume: {piped.Volume}");
Console.WriteLine($"Paraesiminch surface: {piped.Surface}");

var ellispe = new Ellipsoid(1.5,10,3.6);                          // for ellipsoid
Console.WriteLine($"Ellipsoid volume: {ellispe.Volume}");
Console.WriteLine($"Ellipsoid surface: {ellispe.Surface}");
```
In TestingPolygon, the client adds our class library reference in his/her project and employs.
