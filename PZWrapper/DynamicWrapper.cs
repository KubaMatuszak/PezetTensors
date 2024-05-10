using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PZWrapper
{
	public class DynamicDllWrapper
	{
		private IntPtr _dllHandle;

		public DynamicDllWrapper(string dllPath)
		{
			_dllHandle = CustomNativeMethods.LoadLibrary(dllPath);
			if (_dllHandle == IntPtr.Zero)
			{
				throw new Exception($"Failed to load DLL from path: {dllPath}");
			}
		}

		public T GetFunctionDelegate<T>(string functionName)
		{
			IntPtr functionPtr = CustomNativeMethods.GetProcAddress(_dllHandle, functionName);
			if (functionPtr == IntPtr.Zero)
				throw new Exception($"Failed to get function pointer for {functionName}");
			return Marshal.GetDelegateForFunctionPointer<T>(functionPtr);
		}

		~DynamicDllWrapper()
		{
			if (_dllHandle != IntPtr.Zero)
			{
				CustomNativeMethods.FreeLibrary(_dllHandle);
			}
		}
	}

	public class CustomNativeMethods
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr LoadLibrary(string dllToLoad);

		[DllImport("kernel32.dll")]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

		[DllImport("kernel32.dll")]
		public static extern bool FreeLibrary(IntPtr hModule);
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate double SumDelegate(int len, double[] values);

}
