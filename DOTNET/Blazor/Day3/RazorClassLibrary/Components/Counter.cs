using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorClassLibrary.Components
{
	public partial class Counter
	{
		public static int count { get; set; }

		public async Task increment()
		{
			count++;
			await JSRuntime.InvokeVoidAsync("increment");
		}

		[JSInvokable]
		public static async Task<int> decrement()
		{
			count--;

			return await Task.FromResult(count);
		}
	}
}
