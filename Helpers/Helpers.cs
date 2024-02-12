using System;
using System.Configuration;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text;
using System.Security.Cryptography;

namespace Helpers
{
	public static class Helpers
	{


		// -----------------------------------------------------
		// This algorithm was taken from the Microsoft C# documentation's website.
		// Link to source: 'https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.hashalgorithm.computehash?view=net-8.0'
        // -----------------------------------------------------
		public static string StringToHash(string inString)
		{
			StringBuilder sBuilder = new StringBuilder();

			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(inString));
				for (int x = 0; x < data.Length; ++x)
				{
					sBuilder.Append(data[x].ToString("x2"));
				}
			}

			return sBuilder.ToString();
		}
	}
}