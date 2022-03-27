// Problem statement: https://www.codingame.com/ide/puzzle/cgx-formatter
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // int N = int.Parse(Console.ReadLine());
        // StringBuilder cgx = new StringBuilder();
        // for (int i = 0; i < N; i++)
        // {
        //     cgx.Append(Console.ReadLine());
        // }
        // string test = cgx.ToString();
        string test = @$"'menu'= 'file'";
        Console.WriteLine(ParseCGX(test).Format());
    }

    public static void Debug(string message) {
        // Console.Error.WriteLine(message);
    }

    public static Element ParseCGX(string toParse)
    {
        toParse = toParse.Trim();
        Debug($"To Parse: '{toParse}'");

        // Parse a block
        if (toParse[0] == '(')
        {
            string innerString = toParse.Substring(1, toParse.Length - 2).Trim();
            Debug($"Last Char: '{toParse[toParse.Length-2]}'");
            Debug($"Inner String: '{innerString}'");
            if (innerString.Length == 0) return new Block(new List<Element>());
            List<Element> inner = ParseList(innerString);
            return new Block(inner);
        }

        // Parse String primitives
        if (toParse[0] == '\'' && !toParse.Contains('='))
        {
            return new Primitive(toParse.Trim());
        }

        // Parse KeyValue
        if (toParse[0] == '\'')
        {
            return ParseKeyValue(toParse.Substring(1));
        }

        // Parse as primitive
        return new Primitive(toParse.Trim());
    }

    public static Element ParseKeyValue(string toParse)
    {
        int endIx = toParse.IndexOf('\'');
        string key = toParse.Substring(0, endIx);
        toParse = toParse.Substring(endIx + 1).Trim();
        return new KeyValue(key, ParseCGX(toParse.Substring(1)));

    }

    public static List<Element> ParseList(string toParse)
    {
        List<Element> elems = new List<Element>();
        // Find each semi colon that is not inside of a single quote
        StringBuilder b = new StringBuilder();
        bool insideQuote = false;
        int insideBlock = 0;
        foreach (char ch in toParse)
        {
            if (ch == '\'')
            {
                insideQuote = !insideQuote;
            } 
            else if (ch == '(' && !insideQuote)
            {
                insideBlock++;
            }
            else if (ch == ')' && !insideQuote)
            {
                insideBlock--;
            }
            else if (ch == ';' && !insideQuote && insideBlock == 0)
            {
                elems.Add(ParseCGX(b.ToString()));
                b.Clear();
                continue;
            }

            b.Append(ch);
        }
        if (b.ToString().Trim().Length > 0) {
            Debug("Parsing Rest:");
            Debug($"'{b.ToString().Trim()}'");
            elems.Add(ParseCGX(b.ToString().Trim()));
        }

        return elems;
    }
}

abstract class Element
{
    public string Format() => Format(0);
    internal abstract string Format(int level);
    public string Prefix(int level)
    {
        if (level <= 0) return "";
        return "    " + Prefix(level - 1);
    }
}

class KeyValue : Element
{
    private readonly string key;
    private readonly Element e;
    private readonly bool IsPrimitive;

    public KeyValue(string key, Element e)
    {
        IsPrimitive = e.GetType() == typeof(Primitive);
        this.key = key;
        this.e = e;
    }

    internal override string Format(int level)
    {
        if (this.IsPrimitive) return $"{Prefix(level)}'{key}'={e.Format()}";
        return $"{Prefix(level)}'{key}'=\n{e.Format(level)}";
    }
}

class Primitive : Element
{
    private readonly string token;
    public Primitive(string token)
    {
        this.token = token;
    }

    internal override string Format(int level)
    {
        return $"{Prefix(level)}{token}";
    }
}

class Block : Element
{
    private List<Element> elems;
    public Block(List<Element> elems)
    {
        this.elems = elems;
    }
    internal override string Format(int level)
    {
        string prefix = Prefix(level);
        string inner = string.Join(";\n", elems.Select(e => e.Format(level + 1)));
        if (inner.Length > 0) inner += "\n";

        return string.Format("{0}(\n{1}{0})", prefix, inner);
    }
}