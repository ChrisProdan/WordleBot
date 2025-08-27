using System;
using System.IO;
using System.Collections.Generic;

class Program
{
  static void Main(string[] args)
  {
    
    WordleBot Game1 = new WordleBot();

    int Count = 0;

    String OptimalWord = "";

    while (true)
    {
      if (Game1.TotalWords() < 6)
      {
        OptimalWord = Game1.OptimalWord();
      }
      else
      {
        OptimalWord = Game1.OptimalWordAll();
      }

      Console.WriteLine("Your Most Optimal Next Word is: " + OptimalWord);

      Console.WriteLine("Please Input the Results of your Guess: ");
      String Guess = Console.ReadLine();
      Count++;
      if (Guess == "22222")
      {
        Console.WriteLine("The Bot has Found the Word in: " + Count + " Guesses.");
        break;
      }

      Game1.WordRemover(OptimalWord, Guess);
      if (Game1.TotalWords() == 1)
      {
        Console.WriteLine("The Bot has Found the Word, It is: " + Game1.ValidWords[0] + ". This took: " + (Count + 1) + " Guesses.");
        break;
      }
      else
      {
        Console.WriteLine("There are: " + Game1.TotalWords() + " Remaining Possible Words. \n");
      }
    }


  }
}
