## Asynchronous programming

You can avoid performance bottlenecks and enhance the overall responsiveness of your application by using asynchronous programming. However, traditional techniques for writing asynchronous applications can be complicated, making them difficult to write, debug, and maintain.

This example provides an overview of how to use async programming. Simply put, we'll be showing a clear illustration on `WinForms`.

**1)** How works the same thing with synchronous programming:
![sync](https://cloud.githubusercontent.com/assets/25085025/22598298/659ec224-ea4c-11e6-96d8-d31f2c107875.gif)

We can clearly see that while using synchronous programming we are blocking the main UI thread and the user is not able to do anything with the form (here, user cannot click the `Increase counter` button).

**2)** Asynchronous programming provides us the possibility to make the user happier as it won't see anything like that (f.e. `(Not responding)` application or maybe he'll do something while the page is loading).
![async](https://cloud.githubusercontent.com/assets/25085025/22598402/cf654ebc-ea4c-11e6-920d-6d1294431ee9.gif)
