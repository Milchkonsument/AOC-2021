using System.Linq; 
using System;
using System.IO;
using System.Collections.Generic;

static class Prog 
{
	static void Main() {
		(int h, int d, int a) pos = (0,0,0);
		File.ReadAllLines("in")
			.Select(s => (s.Split(' ')[0], int.Parse(s.Split(' ')[1])))
			.ToList()
			.ForEach(c => pos = pos.Add((c.Item1 == "forward" ? c.Item2 : 0, c.Item1 == "forward" ? c.Item2 * pos.Item3 : 0, c.Item1 == "down" ? c.Item2 : c.Item1 == "up" ? -c.Item2 : 0)));
		Console.WriteLine($"hor {pos.Item1} dep {pos.Item2} -> {pos.Item1 * pos.Item2}");
	}
	public static (int,int,int) Add(this (int, int, int) l, (int,int,int) r) => (r.Item1 + l.Item1, r.Item2 + l.Item2, r.Item3 + l.Item3);
}
