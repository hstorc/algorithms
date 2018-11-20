using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("?");
            string input = "";
            while ((input = Console.ReadLine()) != "exit")
            {
                Console.WriteLine(IsValidParentheses(input));
                Console.Write("?");
            }
            Console.WriteLine();
        }

        static bool IsValidParentheses(string exp)
        {
            var isValid = true;
            var specialCharsDict = new Dictionary<char, char>() { { '}', '{' }, { ']', '[' }, { ')', '(' } };

            Stack<char> openners = new Stack<char>();
            for (var i = 0; i < exp.Count() && isValid; i++)
            {
                if (specialCharsDict.ContainsKey(exp[i]) &&
                (openners.Count() == 0 || specialCharsDict[exp[i]] != openners.Peek()))
                {
                    isValid = false;
                }
                else if (specialCharsDict.ContainsValue(exp[i]))//openner
                {
                    if (openners.Count() == 0)
                    {
                        openners.Push(exp[i]);
                    }
                    else
                    {
                        switch (exp[i])
                        {

                            case '[':
                                if (openners.Peek() == '(')
                                    isValid = false;
                                break;
                            case '{':
                                if (openners.Peek() == '(' ||
                                    openners.Peek() == '[')

                                    isValid = false;
                                break;

                        }
                        if (isValid)
                            openners.Push(exp[i]);
                    }
                }
                else if (specialCharsDict.ContainsKey(exp[i]) &&
                        specialCharsDict[exp[i]] == openners.Peek())
                {

                    openners.Pop();
                }

            }
            if (openners.Count() > 0) isValid = false;
            return isValid;
        }

    }
}
