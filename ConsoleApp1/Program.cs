// See https://aka.ms/new-console-template for more information


// https://www.c-sharpcorner.com/blogs/get-any-date-and-time-as-per-time-zone-in-c-sharp

Console.WriteLine("Hello, World!");

string time = DateTime.UtcNow + "+00:00";

var bb = DateTimeOffset.Parse(time).UtcDateTime;

Console.WriteLine(bb);
