using System;
using System.Collections.Generic;

namespace Andesite;

public class Log
{
    /// <summary>
    /// Log a warning message to the console.
    /// </summary>
    /// <param name="Message"></param>
    public static void Warn(string Message, string prefix = "[WARNING]")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(DateTime.Now.ToString("s") + $" {prefix} " + Message);
        Console.ForegroundColor = ConsoleColor.White;
    }
    /// <summary>
    /// Log an Error message to the console.
    /// </summary>
    /// <param name="Message"></param>
    public static void Error(string Message, string prefix = "[ERROR]")
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(DateTime.Now.ToString("s") + $" {prefix} " + Message);
        Console.ForegroundColor = ConsoleColor.White;
    }
    /// <summary>
    /// Log a debug message to the console. If the bool CanSend is false, the message won't be sent.
    /// </summary>
    /// <param name="Message"></param>
    /// <param name="CanSend"></param>
    public static void Debug(string Message, bool CanSend = true, string prefix = "[Debug]")
    {
        if (CanSend)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(DateTime.Now.ToString("s") + $" {prefix} " + Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    /// <summary>
    /// Log an info message to the console.
    /// </summary>
    /// <param name="Message"></param>
    public static void Info(string Message, string prefix = "[Info]")
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(DateTime.Now.ToString("s") + $" {prefix} " + Message);
        Console.ForegroundColor = ConsoleColor.White;
    }
    /// <summary>
    /// Log a generic message, with the "[Message]" tag to the console.
    /// </summary>
    /// <param name="Message"></param>
    public static void Message(string Message, string prefix = "[Message]")
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(DateTime.Now.ToString("s") + $" {prefix} " + Message);
        Console.ForegroundColor = ConsoleColor.White;
    }
    /// <summary>
    /// Log a generic message to the console.
    /// </summary>
    /// <param name="Message"></param>
    public static void Generic(string Message, string prefix = "[Generic]")
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(DateTime.Now.ToString("s") + $" {prefix} " + Message);
        Console.ForegroundColor = ConsoleColor.White;
    }
    /// <summary>
    /// Log a raw message to the console. Message is the message to log, InfoLevel is the info tag to prefix the message, and Color is the console color of the message.
    /// </summary>
    /// <param name="Message"></param>
    /// <param name="InfoLevel"></param>
    /// <param name="Color"></param>
    public static void Raw(string Message, string InfoLevel = "[INFO]", ConsoleColor Color = ConsoleColor.White)
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(DateTime.Now.ToString("s") + $" {InfoLevel} " + Message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}