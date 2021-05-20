public class Compression
{
	public static string ExtractZipWithoutPsw(string src, string dst)
	{
		string source = @src;
		string destination = @dst;
		ZipFile.ExtractToDirectory(source, destination);
		return "successful";
	}

	public static string ExtractRAR(string src, string dst, string password)
	{
		 string rarExec = "\"c:\\Program Files\\WinRAR\\Rar.exe\"";
		 string output = "";
		 string source = @src;
		string destination = @dst;
		using (Process process = new Process())
		{
			process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			process.StartInfo.FileName = rarExec;
			if (!string.IsNullOrEmpty(password) )
				process.StartInfo.Arguments = "/c x -cfg- -inul -y " + "-p" + password + source + " " + destination;
			else
				process.StartInfo.Arguments = "/c x -cfg- -inul -y " + source + " " + destination;

			process.Start();
			process.WaitForExit();

			switch (process.ExitCode)
			{
				case 0:
					output = "successful";
					break;
				case 10:
					output = "wrong password";
					break;
				default:
					output = "Error: unknown";
					break;
			}
			
			return output;
		}
	}
}
