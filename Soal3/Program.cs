using System;
using System.Collections.Generic;

class Program
{
    static bool IsBalanced(string input)
    {
        Stack<char> stack = new Stack<char>();
        char[] openingBrackets = { '(', '[', '{' };
        char[] closingBrackets = { ')', ']', '}' };
        Dictionary<char, char> bracketPairs = new Dictionary<char, char>
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        foreach (char c in input)
        {
            if (Array.Exists(openingBrackets, bracket => bracket == c))
            {
                stack.Push(c);
            }
            else if (Array.Exists(closingBrackets, bracket => bracket == c))
            {
                if (stack.Count == 0 || stack.Peek() != bracketPairs[c])
                {
                    return false;
                }
                stack.Pop();
            }
        }

        return stack.Count == 0;
    }

    static void Main(string[] args)
    {
        Console.Write("Input: ");
        string input = Console.ReadLine();

        string result = IsBalanced(input) ? "YES" : "NO";
        Console.WriteLine($"Output: {result}");
    }
}
