using System.Linq; 
using System;
using System.IO;
using System.Collections.Generic;

static class Prog 
{
	static void Main() {
		string[] ss = File.ReadAllLines("in");
		int[] draws = ss[0].Split(',').Select(s => int.Parse(s)).ToArray();
		List<List<List<Tuple<int,bool>>>> bingos = new List<List<List<Tuple<int,bool>>>>();
		List<List<Tuple<int,bool>>> buf = new List<List<Tuple<int,bool>>>();
		for(int i = 2; i < ss.Length; i++) {
			if(ss[i] == "\n") {
				bingos.Add(buf);
				buf = new List<List<Tuple<int,bool>>>();
			} else
				buf.Add(ss[i].Split(' ').Select(s => new Tuple<int,bool>(int.Parse(s), false)).ToList());
		}

		List<List<List<Tuple<int,bool>>>> candidates = new List<List<List<Tuple<int,bool>>>>();
		for(int i = 0; i < draws.Length; i++) {
			if(candidates.Count != 0)
				break;

			bingos.ForEach(b => {b.Check(i); if(b.IsBingo()) candidates.Add(b);});
		}
		Console.WriteLine($"{candidates.Count}");
	}

	static bool IsBingo(this List<List<Tuple<int,bool>>> l) {
		if(l.Any(ll => ll.Select(t => (t, 0)).Aggregate((a,b) => {b.Item2 += a.Item1.Item2 ? 1 : 0; return b;}).Item2 == ll.Count))
			return true;



		return false;
	}

	static void Check(this List<List<Tuple<int,bool>>> l, int i) {
		l.ForEach(ll => ll.ForEach(t => {if(t.Item1 == i) t = new Tuple<int, bool>(t.Item1, true);}));
	}
}
