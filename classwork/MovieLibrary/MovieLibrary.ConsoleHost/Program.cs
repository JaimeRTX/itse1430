// Get Movies
// Tittle genre, description, MPAA Rating
// Length, relase year, budget
// IsBlackAndWhite
// Operation, Add, Edit, View, delete

string title = "", genre = "";
string description = "", rating = "";

int length = 0, releaseYear = 1900;
decimal budget = 125.45M;

bool isBlackAndWhite = false;

//Get the Title
Console.WriteLine("Enter A Title");
title = Console.ReadLine();

Console.WriteLine("Enter A Description");
description = Console.ReadLine();

//TODO: Fix Length
Console.WriteLine("Enter The Run Length in Minutes");
string lengthString = Console.ReadLine();

Console.WriteLine(title);
Console.WriteLine(description);
Console.WriteLine(lengthString);

//double someFloatingValue = 3.14159;
//char letterGrade = 'A';

//{
// int hours = 5;
//int title = 54;
//title = "Jaws";

// Console.WriteLine(title);
// Console.WriteLine(length);
//}