using System.Globalization;

public class StringSegmentsDemo
{
    public static void Run()
    {
        var s = "Yo👩🏽‍🚒";
        Console.WriteLine($"Length: {s.Length}"); //shows 9 chars!

        // Proper way — segment by grapheme clusters
        var enumerator = StringInfo.GetTextElementEnumerator(s);
        while (enumerator.MoveNext()) //loop three times
            Console.WriteLine($"Segment: {enumerator.Current}");
            //Here each TextElement is a grapheme cluster
            //what users see as one character.
    }
}
