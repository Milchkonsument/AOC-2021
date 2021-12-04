using System.Linq; 
using System;
using System.IO;
using System.Collections.Generic;

class Prog 
{
	static void Main() {
		int c = 0;
		int[] ints = File.ReadAllLines("in").Select(s => int.Parse(s)).ToArray(); 
		int[] sums = new int[ints.Length-2];
		
		for(int i = 0; i < ints.Length-2; i++)
			sums[i] = ints[i] + ints[i+1] + ints[i+2]; 
		
		sums.Aggregate((a,b) => { c += (a < b ? 1 : 0); return b; }); 
		Console.WriteLine(c);
	}
}
