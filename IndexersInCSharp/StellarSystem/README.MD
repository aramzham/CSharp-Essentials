This pretty example demonstrates us the inheritance and overriding of indexers.

![the-planets-of-the-solar-system](https://cloud.githubusercontent.com/assets/25085025/21965544/c9f937ac-db7b-11e6-86e6-c445db884254.jpg)

Our base class - `StellarSystem` has two abstract indexers that will be implemented in derived class.

```cs
public abstract string this[int index] { get; }
public abstract int this[string index] { get; }
```

The first one will tell you the name of the planet which has the defined index. And the second one will give you planet's current number.

Here is the derived class, our Solar system:

```csharp
public class SolarSystem : StellarSystem
{
    public SolarSystem()
    {
        CentralStar = "Sun";
        planets = new[] { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Pluto" };
    }
    public override string this[int index]
    {
        get
        {
            if (index < 1 || index > 9) throw new IndexOutOfRangeException("Index cannot be negative or higher than 9");
            return planets[index - 1];
        }
    }

    public override int this[string index]
    {
        get
        {
            if (planets.Any(planet => planet == index)) return Array.IndexOf(planets, index) + 1;
            throw new IndexOutOfRangeException("No such planet exists in our system");
        }
    }
}
```
