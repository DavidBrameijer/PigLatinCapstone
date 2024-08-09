using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Xml;

Console.WriteLine("Welcome to the Pig Latin translator!");
bool runProgram = true;
while (runProgram == true)
{
    Console.WriteLine("Please type a sentence.");
    string sentence = Console.ReadLine();
    if (sentence != "")
    {

        string[] words = sentence.Split(" ");
        foreach (string word in words)
        {
            string pigWord = "";
            string before = "";
            string after = "";
            if (HasSpecialChar(word) == false)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    char currentLetter = word[i];
                    if (currentLetter == 'a' || currentLetter == 'e' || currentLetter == 'i' || currentLetter == 'o' || currentLetter == 'u' || currentLetter == 'A' || currentLetter == 'E' || currentLetter == 'I' || currentLetter == 'O' || currentLetter == 'U')
                    {
                        if (i == 0)
                        {
                            pigWord = word + "way";
                            break;
                        }
                        else
                        {
                            before = word.Substring(0, i);
                            after = word.Substring(i);
                            pigWord = after + before + "ay";
                            break;

                        }
                    }
                }
            }
            else
            {
                pigWord = word;
            }
            Console.Write(pigWord + " ");
        }
    }
    else
    {
        Console.WriteLine("Invalid sentence.");
        continue;
    }

    Console.WriteLine("");
    runProgram = GetContinue();
}

static bool HasSpecialChar(string input)
{
    string specialChar = "\"|#$%&/()=»«@£§€\\{}-;<>1234567890_"; // the \ is an espace to include " and \
    foreach (var item in specialChar)
    {
        if (input.Contains(item)) return true;
    }
    return false;
}

static bool GetContinue()
{
    bool result = true;
    while (true)
    {
        Console.WriteLine("Would you like to type another sentence? (y/n)");
        string answer = Console.ReadLine().ToLower();
        if (answer == "y" || answer == "yes")
        {
            result = true;
            break;
        }
        else if (answer == "n" || answer == "no")
        {
            result = false;
            Console.WriteLine("Thank you for using the Pig Latin translator!");
            break;
        }
        else
        {
            Console.WriteLine("Please enter a valid answer");
            continue;
        }

    }
    return result;
}