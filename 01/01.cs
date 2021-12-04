using System.Linq; 
using System;
using System.IO;

class Prog 
{
	static void Main() {
		int c = 0;
		File.ReadAllLines("in").Select(s => int.Parse(s)).Aggregate((a,b) => { c += (a < b ? 1 : 0); return b; });
		Console.WriteLine(c);
	}
}
