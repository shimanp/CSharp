using System;
using System.Diagnostics;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using machine_learning_sample.naturallang;

namespace machine_learning_test
{
	[TestClass]
	public class OnehotTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			Onehot onehot = new Onehot("–¾“ú‚Í‰J‚©‚à‚µ‚ê‚È‚¢");
			onehot.AddSentence("‚¢‚â–¾“ú‚Í°‚ê‚Ì‰Â”\«‚à‚ ‚é");
			onehot.AddSentence("–¾“ú‚Í—Ç‚¢“ú‚É‚È‚é‚©‚à‚µ‚ê‚È‚¢");
			onehot.buildOnehot();
			Debug.WriteLine(String.Join(",", onehot.GetAllUniqWords()));
			foreach(OnehotData data in onehot.GetOnehotDatas())
			{
				Debug.WriteLine(data.sentence);
				foreach(List<int> vs in data.onehots)
				{
					Debug.WriteLine(String.Join(",", vs));
				}
			}
		}
	}
}
