## Asynchronous programming

You can avoid performance bottlenecks and enhance the overall responsiveness of your application by using asynchronous programming. However, traditional techniques for writing asynchronous applications can be complicated, making them difficult to write, debug, and maintain.

This example provides an overview of how to use async programming. Simply put, we'll be showing a clear illustration on `WinForms`.

##### To remember
*Thread class represents an object-oriented wrapper around a given path of execution within a particular AppDomain.*

**1)** How works the same thing with synchronous programming:
![sync](https://cloud.githubusercontent.com/assets/25085025/22598298/659ec224-ea4c-11e6-96d8-d31f2c107875.gif)

We can clearly see that while using synchronous programming we are blocking the main UI thread and the user is not able to do anything with the form (here, user cannot click the `Increase counter` button).

**2)** Asynchronous programming provides us the possibility to make the user happier as it won't see anything like that (f.e. `(Not responding)` application or maybe he'll do something while the page is loading).
![gif](https://cloud.githubusercontent.com/assets/25085025/22598669/a85048b2-ea4d-11e6-965b-cc364ceff928.gif)

Some advices for using async code in .net:
* Do not use `.Wait()` or `.Result` if you don't want to get aggregated exceptions, use `.GetAwaiter().GetResult()` for better exception experience
* In fire-and-forget tasks your exceptions will be swallowed, if you don't want it to happen use `.SafeFireAndForget()` in *AsyncAwaitBestPractices* nuget package
* Avoid `return await` statements. If there's only one statement in the method just return a task of the return type. Thus you'll get a little performance boost (in context switching) and less memory consumption (you'll save about 100b when creating state machine). Exceptions are `try/catch` and `using(...)` blocks
* If you don't care which thread should continue the code after `await` use `.ConfigureAwait(false)`
* Use `System.Threading.Tasks.Extensions.ValueTask` whenever a method might not hit `await`
