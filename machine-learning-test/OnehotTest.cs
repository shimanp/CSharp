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
			Onehot onehot = new Onehot("明日は雨かもしれない");
			onehot.AddSentence("いや明日は晴れの可能性もある");
			onehot.AddSentence("明日は良い日になるかもしれない");
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
