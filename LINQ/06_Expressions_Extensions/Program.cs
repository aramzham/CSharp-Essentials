using System;
using System.Linq.Expressions;
using _Common_Expressions;

var st = new Student() { Name = "A1", Age = 18 };

Expression<Func<Student, bool>> q3 = s => s.Age > 12;
Expression<Func<Student, bool>> q4 = s => s.Age < 20;

Expression<Func<Student, bool>> isTeenagerExpression1 = q3.And(p => p.Age < 20).Or(p => p.Age == 30);

var isTeenagerFunc = isTeenagerExpression1.Compile();
Console.WriteLine(isTeenagerFunc(st) ? "Yes" : "No");

Console.ReadKey();
