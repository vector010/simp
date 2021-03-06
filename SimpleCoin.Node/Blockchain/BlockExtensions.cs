﻿namespace SimpleCoin.Node.Blockchain
{
	using System.Collections.Generic;
	using System.Linq;
	using Newtonsoft.Json;
	using Transactions;
	using Util;

	public static class BlockExtensions
	{
		public static Block GetLatestBlock(this IList<Block> blockchain)
		{
			return blockchain.Last();
		}

		public static string CalucateHash(this Block block)
		{
			return CalculateHash(block.Index, block.PreviousHash, block.Timestamp, block.Data, block.Difficulty, block.Nonce);
		}

		/// <summary>
		/// Calculate a SHA256 hash for the given values.
		/// </summary>
		/// <param name="index"></param>
		/// <param name="previousHash"></param>
		/// <param name="timestamp"></param>
		/// <param name="data"></param>
		/// <param name="difficulty"></param>
		/// <param name="nonce"></param>
		/// <returns></returns>
		public static string CalculateHash(long index, string previousHash, long timestamp, IList<Transaction> data, int difficulty, int nonce)
		{
			return CalculateHash(index.ToString(), previousHash, timestamp.ToString(), JsonConvert.SerializeObject(data), difficulty.ToString(), nonce.ToString());
		}

		private static string CalculateHash(params string[] args)
		{
			string str = args.Aggregate((s1, s2) => s1 + s2);
			return str.CalculateHash();
		}
	}
}