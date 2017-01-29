# IndexerExamples
Here is an example of using indexers in C# 6.0.

_**An indexer allows an object to be indexed such as an array. When you define an indexer for a class, this class behaves similar to a virtual array. You can then access the instance of this class using the array access operator ([ ]).**_

![what-the-hell-is-that](https://cloud.githubusercontent.com/assets/25085025/21965621/1bf01002-db7d-11e6-87ad-c7b5c733ef99.gif)

Here are some easy examples to better understand indexers in C# 6.0.

In [Indexers in C#] (https://github.com/aramzham/IndexerExamples/tree/master/IndexersInCSharp) you use a class that will tell you the number of a chosen day of the week using a simple indexer.

In our [Astronomic example] (https://github.com/aramzham/IndexerExamples/tree/master/IndexersInCSharp/StellarSystem) you'll see that indexers can be abstract, can be inherited and, thus, overriden.

As you can't add or change days of the week, indexers **won't have setters**.

```cs
public class DayOfTheWeekManager
{
    //indexer
    public int this[string index]
    {
        get
        {
             if(index !=DayOfWeek.Monday.ToString() && index != DayOfWeek.Tuesday.ToString() && index != DayOfWeek.Wednesday.ToString() && index != DayOfWeek.Thursday.ToString() && index != DayOfWeek.Friday.ToString() && index != DayOfWeek.Saturday.ToString() && index != DayOfWeek.Sunday.ToString()) throw new Exception("There is no such week day");
             var dayOfWeek = (DayOfWeek) Enum.Parse(typeof(DayOfWeek), index);
             return (int)dayOfWeek;
         }
     }
}
```

```cs
public class CustomWeekDayManager
{
    private string[] daysOfWeek = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

    //indexer
    public int this[string index]
    {
        get
        {
            if(daysOfWeek.Any(d=>d==index)) return Array.IndexOf(daysOfWeek, index) + 1;
            throw new Exception("No such day exists");
        }
    }
}
```

While tesing we have concluded that the `CustomDayOfTheWeekManager` is about 50 times faster than `DayOfTheWeekManager`.

<img width="426" alt="untitled" src="https://cloud.githubusercontent.com/assets/25085025/21962385/3bc755fa-db3e-11e6-95c6-064f8730bcf4.png">

Why there is such a significant difference?
```cs
var dayOfWeek = (DayOfWeek) Enum.Parse(typeof(DayOfWeek), index);
```
Because `DayOfTheWeekManager` uses some details of Reflection which is evidently slow.

Conclusion! - **Do Not use Reflection where unnecessary!**.
