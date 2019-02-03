using System;
using System.Collections.Generic;
using System.Text;
using NMeCab.Core;

namespace machine_learning_sample.naturallang
{
	public class Onehot
	{
		private List<OnehotData> onehotdatas = new List<OnehotData>();
		private List<string> allUniqWords = new List<string>();

		public Onehot(string sentence)
		{
			this.AddSentence(sentence);
		}

		public Onehot(List<string> sentences)
		{
			foreach(string s in sentences)
			{
				this.AddSentence(s);
			}
		}

		public void AddSentence(string sentence)
		{
			OnehotData data = new OnehotData(sentence);
			this.onehotdatas.Add(data);
			AddOnehot(data.words);
		}

		public void AddOnehot(List<string> vs)
		{
			foreach(string s in vs)
			{
				if (this.allUniqWords.Contains(s) == false)
				{
					this.allUniqWords.Add(s);
				}
			}
		}

		public void AddOnehot(string s)
		{
			if(this.allUniqWords.Contains(s) == false)
			{
				this.allUniqWords.Add(s);
			}
		}

		public List<OnehotData> GetOnehotDatas()
		{
			return this.onehotdatas;
		}

		public List<OnehotData> buildOnehot()
		{
			foreach(OnehotData data in this.onehotdatas)
			{
				data.InitOnehots(this.allUniqWords);
			}
			return this.onehotdatas;
		}

		public List<string> GetAllUniqWords()
		{
			return this.allUniqWords;
		}
	}

	public class OnehotData
	{
		public string sentence;
		public List<string> words = new List<string>();
		public List<List<int>> onehots = new List<List<int>>();

		public OnehotData(string sentence)
		{
			this.sentence = sentence;
			var mecab = NMeCab.MeCabTagger.Create();
			var node = mecab.ParseToNode(sentence);
			while (node != null)
			{
				node = node.Next;
				if (node == null || node.Length == 0) break;
				this.AddWords(node.Surface);
			}
		}

		public void AddWords(string word)
		{
			this.words.Add(word);
		}

		public void SetWords(List<string> words)
		{
			this.words = words;
		}

		public void InitOnehots(List<string> allWords)
		{
			this.onehots = new List<List<int>>();
			foreach (string w in this.words)
			{
				List<int> ohs = new List<int>();
				foreach (string aw in allWords)
				{
					if(w == aw)
					{
						ohs.Add(1);
					}
					else
					{
						ohs.Add(0);
					}
				}
				this.onehots.Add(ohs);
			}
		}
	}
}
