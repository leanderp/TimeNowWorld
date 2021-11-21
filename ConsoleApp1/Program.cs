// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string time = DateTime.UtcNow + "+00:00";

var bb = DateTimeOffset.Parse(time).UtcDateTime;

Console.WriteLine(bb);
