class Input
{
    public static string GetString(string sentence = "Enter an input:", string fallback = "")
    {
        Console.WriteLine($"\n{sentence}");
        Console.Write("\n >  ");
        string? res = Console.ReadLine();
        return String.IsNullOrEmpty(res) ? fallback : res;
    }

    public static int GetInt(string sentence = "Enter an input:")
    {
        int result = 0;
        bool isInt = false;
        while (!isInt)
        {
            if (!String.IsNullOrEmpty(sentence))
                Console.WriteLine($"\n{sentence}");
            Console.Write("\n >  ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int i))
            {
                isInt = true;
                result = i;
            }
            else
                Input.DisplayError("integer");
        }
        return result;
    }

    public static float GetFloat(string sentence = "Enter an input:")
    {
        float result = 0;
        bool isFloat = false;
        while (!isFloat)
        {
            Console.WriteLine($"\n{sentence}");
            Console.Write("\n >  ");
            string? input = Console.ReadLine();

            if (float.TryParse(input, out float f))
            {
                isFloat = true;
                result = f;
            }
            else
                Input.DisplayError("float");
        }
        return result;
    }

    private static void DisplayError(string type = "type")
    {
        Console.WriteLine($"\nThis wasn't a valid \"{type}\" value.\nPlease try again with a correspondent value ({type}).\n");
    }
}