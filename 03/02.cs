using System.Linq; 
using System;
using System.IO;
using System.Collections.Generic;

static class Prog 
{
	static void Main() {
		List<List<int>> val = File.ReadAllLines("in").Select(s => s.Select(c => int.Parse(c.ToString())).ToList()).ToList();
		int[] cnt = new int[val[0].Count];
		List<List<int>> candidate_oxy = new List<List<int>>(val);
		List<List<int>> candidate_co2 = new List<List<int>>(val);

		for(int i = 0; i < val.Count; i++)
			for(int k = 0; k < val[0].Count; k++)
				cnt[k] += val[i][k];
		
		for(int k = 0; k < val[0].Count; k++) {
			if(candidate_oxy.Count != 1) candidate_oxy = candidate_oxy.Where(l => l[k] == (cnt[k] >= val.Count/2 ? 1 : 0)).ToList();
			if(candidate_co2.Count != 1) candidate_co2 = candidate_co2.Where(l => l[k] == (cnt[k] >= val.Count/2 ? 0 : 1)).ToList();
			Console.WriteLine($"oxy: {candidate_oxy.Count} co2: {candidate_co2.Count}");
		}
		Console.WriteLine($"{Convert.ToInt32(candidate_co2[0].Select(i => i.ToString()).Aggregate((a,b) => a+b), 2) * Convert.ToInt32(candidate_oxy[0].Select(i => i.ToString()).Aggregate((a,b) => a+b), 2)}");
	}
}
