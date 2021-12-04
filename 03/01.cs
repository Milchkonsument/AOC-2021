using System.Linq; 
using System;
using System.IO;
using System.Collections.Generic;

static class Prog 
{
	static void Main() {
		List<List<int>> val = File.ReadAllLines("in").Select(s => s.Select(c => int.Parse(c.ToString())).ToList()).ToList();
		int[] cnt = new int[val[0].Count];
		
		for(int i = 0; i < val[0].Count; i++)
			for(int k = 0; k < val.Count; k++)
				cnt[i] += val[k][i];

		Console.WriteLine(Convert.ToInt32(cnt.Select(i => i > val.Count/2 ? "1" : "0").Aggregate((a,b) => a+b), 2) * Convert.ToInt32(cnt.Select(i => i < val.Count /2 ? "1" : "0").Aggregate((a,b) => a+b), 2));
	}
}
