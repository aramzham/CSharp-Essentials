# Inheritance

#### Here are some good examples explaining the process of inheritance in C#.

In #FinancialOrganizations folder you'll see a basic FinancialInstitution class which will "give birth" to Banks, Credit organizations and Insurance companyies. All those institutions inherite all fields, properties and methods from base class. Meanwhile, they also add their own specific states and functionalities.

For example:
```javascript
public long Assets { get; set; }
public long Liabilities { get; set; } 
```
these properties are particular for Banks, so we add them in derived class(Bank). To better understand this topic, take a look at this glittering class diagram:

<img width="698" alt="finorgdiagram" src="https://cloud.githubusercontent.com/assets/25085025/22687848/2f1e0936-ed43-11e6-9937-7e9fe902c219.png">


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
