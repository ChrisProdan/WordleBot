using System;
using System.Collections.Generic;
using System.IO;

class WordleBot
{
    public List<String> ValidWords;
    private Dictionary<String, int> HashMap;

    public WordleBot()
    {
        List<String> ValidWordsDupe = new List<string>();
        StreamReader sr = new StreamReader("C:\\Users\\Andrada Prodan\\Desktop\\VS Code\\WordleBot\\Words.txt");
        String line = sr.ReadLine();
        while (line != null)
        {
            //write the line to console window
            ValidWordsDupe.Add(line);
            //Read the next line
            line = sr.ReadLine();
        }
        Dictionary<String, int> HashMapDupe = new Dictionary<String, int>();
        HashMapDupe.Add("a", 909);
        HashMapDupe.Add("b", 267);
        HashMapDupe.Add("c", 448);
        HashMapDupe.Add("d", 370);
        HashMapDupe.Add("e", 1056);
        HashMapDupe.Add("f", 207);
        HashMapDupe.Add("g", 300);
        HashMapDupe.Add("h", 379);
        HashMapDupe.Add("i", 647);
        HashMapDupe.Add("j", 27);
        HashMapDupe.Add("k", 202);
        HashMapDupe.Add("l", 648);
        HashMapDupe.Add("m", 298);
        HashMapDupe.Add("n", 550);
        HashMapDupe.Add("o", 673);
        HashMapDupe.Add("p", 346);
        HashMapDupe.Add("q", 29);
        HashMapDupe.Add("r", 837);
        HashMapDupe.Add("s", 618);
        HashMapDupe.Add("t", 667);
        HashMapDupe.Add("u", 457);
        HashMapDupe.Add("v", 149);
        HashMapDupe.Add("w", 194);
        HashMapDupe.Add("x", 37);
        HashMapDupe.Add("y", 417);
        HashMapDupe.Add("z", 35);

        ValidWords = ValidWordsDupe;
        HashMap = HashMapDupe;
    }

    public void WordRemover(String Word, String Key)
    {
        for (int j = 0; j < 5; j++)
        {
            if (Key.Substring(j, 1) == "2")
            {
                HashMap[Word.Substring(j, 1)] = 0;
            }
        }
        for (int i = 0; i < ValidWords.Count; i++)
        {
            while (!WordCheck(ValidWords[i], Word, Key))
            {

                for (int j = 0; j < 5; j++)
                {
                    if (ValidWords[i].IndexOf(ValidWords[i].Substring(j, 1)) == j)
                    {
                        if (HashMap[ValidWords[i].Substring(j, 1)] > 0)
                        {
                            HashMap[ValidWords[i].Substring(j, 1)]--;
                        }
                    }

                }
                ValidWords.RemoveAt(i);
                if (i >= ValidWords.Count)
                {
                    break;
                }

            }
        }
    }

    public static bool WordCheck(String toCheck, String Word, String Key)
    {
        List<String> GreenLetters = new List<string>();
        List<String> YellowLetters = new List<string>();
        for (int i = 0; i < 5; i++)
        {
            if (Key.Substring(i, 1) == "2")
            {
                GreenLetters.Add(Word.Substring(i, 1));
            }
            else if (Key.Substring(i, 1) == "1")
            {
                YellowLetters.Add(Word.Substring(i, 1));
            }
        }
        for (int i = 0; i < 5; i++)
        {
            if (Key.Substring(i, 1) == "2")
            {
                

                if (toCheck.Substring(i, 1) != Word.Substring(i, 1))
                {
                    return false;
                }
            }
            else if (Key.Substring(i, 1) == "1")
            {
                int count = 0;
                foreach (String letter in GreenLetters)
                {
                    if (letter == Word.Substring(i, 1))
                    {
                        count++;
                    }
                }
                foreach (String letter in YellowLetters)
                {
                    if (letter == Word.Substring(i, 1))
                    {
                        count++;
                    }
                }
                if (toCheck.Substring(i, 1) == Word.Substring(i, 1))
                {
                    return false;
                }
                if ((5 - toCheck.Replace(Word.Substring(i, 1), "").Length) < count)
                {
                    return false;
                }


            }
            else if (Key.Substring(i, 1) == "0")
            {
                int count = 0;
                foreach (String letter in GreenLetters)
                {
                    if (letter == Word.Substring(i, 1))
                    {
                        count++;
                    }
                }
                foreach (String letter in YellowLetters)
                {
                    if (letter == Word.Substring(i, 1))
                    {
                        count++;
                    }
                }
                if (toCheck.Substring(i, 1) == Word.Substring(i, 1))
                {
                    return false;
                }
                if ((5 - toCheck.Replace(Word.Substring(i, 1), "").Length) > count)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public String OptimalWordAll()
    {
        int HighestSum = 0;
        String BestWord = "";

        StreamReader sr2 = new StreamReader("C:\\Users\\Andrada Prodan\\Desktop\\VS Code\\WordleBot\\AllPossibleWords.txt");

        String Word = sr2.ReadLine();

        while (Word != null)
        {
            int tempSum = 0;
            for (int i = 0; i < 5; i++)
            {
                if (Word.IndexOf(Word.Substring(i, 1)) == i)
                {
                    tempSum += HashMap[Word.Substring(i, 1)];
                }
            }
            if (tempSum > HighestSum)
            {
                HighestSum = tempSum;
                BestWord = Word;
            }
            Word = sr2.ReadLine();

        }
        return BestWord;
    }

    public String OptimalWord()
    {
        int HighestSum = 0;
        String BestWord = "";

        for (int j = 0; j < ValidWords.Count; j++)
        {
            int tempSum = 0;
            for (int i = 0; i < 5; i++)
            {
                if (ValidWords[j].IndexOf(ValidWords[j].Substring(i, 1)) == i)
                {
                    tempSum += HashMap[ValidWords[j].Substring(i, 1)];
                }
            }
            if (tempSum > HighestSum)
            {
                HighestSum = tempSum;
                BestWord = ValidWords[j];
            }

        }
        return BestWord;
    }
    public int TotalWords()
    {
        return ValidWords.Count;
    }
}