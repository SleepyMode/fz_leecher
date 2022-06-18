using System;
using System.IO;
using System.Text;
using System.Xml;

namespace FileZillaLeecher;

public class Program
{
	private static void Main(string[] args)
	{
		var fileZillaFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FileZilla";
		if (!Directory.Exists(fileZillaFolder))
		{
			Console.WriteLine("Can't find FileZilla data folder.");
			Console.ReadKey();
			return;
		}

		var xmlDoc = new XmlDocument();

		var fileZillaDataFile = fileZillaFolder + "\\filezilla.xml";
		if (File.Exists(fileZillaDataFile))
		{
			Console.WriteLine("[Data File: Tabs]");
			try
			{
				xmlDoc.Load(fileZillaDataFile);

				var tabs = xmlDoc.GetElementsByTagName("Tab");
				foreach (var tab in tabs)
				{
					var element = tab as XmlElement;
					if (element == null)
					{
						continue;
					}

					var host = element["Host"]?.InnerText ?? "<none>";
					var port = element["Port"]?.InnerText ?? "<none>";
					var protocol = element["Protocol"]?.InnerText ?? "<none>";
					var type = element["Type"]?.InnerText ?? "<none>";
					var user = element["User"]?.InnerText ?? "<none>";
					var pass = element["Pass"]?.InnerText ?? "<none>";
					var logonType = element["LogonType"]?.InnerText ?? "<none>";
					var encodingType = element["EncodingType"]?.InnerText ?? "<none>";
					var bypassProxy = element["BypassProxy"]?.InnerText ?? "<none>";
					var site = element["Site"]?.InnerText ?? "<none>";
					var remotePath = element["RemotePath"]?.InnerText ?? "<none>";
					var localPath = element["LocalPath"]?.InnerText ?? "<none>";

					if (pass != "<none>") pass = Encoding.UTF8.GetString(Convert.FromBase64String(pass));

					Console.WriteLine($"\tHost: {host}");
					Console.WriteLine($"\t\tPort: {port}");
					Console.WriteLine($"\t\tProtocol: {protocol}");
					Console.WriteLine($"\t\tType: {type}");
					Console.WriteLine($"\t\tUser: {user}");
					Console.WriteLine($"\t\tPass: {pass}");
					Console.WriteLine($"\t\tLogon Type: {logonType}");
					Console.WriteLine($"\t\tEncoding Type: {encodingType}");
					Console.WriteLine($"\t\tBypass Proxy: {bypassProxy}");
					Console.WriteLine($"\t\tSite: {site}");
					Console.WriteLine($"\t\tRemote Path: {remotePath}");
					Console.WriteLine($"\t\tLocal Path: {localPath}");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
		else
		{
			Console.WriteLine("Can't find FileZilla data file (filezilla.xml).");
		}

		Console.WriteLine(Environment.NewLine);

		var recentServersFile = fileZillaFolder + "\\recentservers.xml";
		if (File.Exists(recentServersFile))
		{
			Console.WriteLine("[Recent Servers]");
			try
			{
				xmlDoc.Load(recentServersFile);

				var servers = xmlDoc.GetElementsByTagName("Server");
				foreach (var server in servers)
				{
					var element = server as XmlElement;
					if (element == null)
					{
						continue;
					}

					var host = element["Host"]?.InnerText ?? "<none>";
					var port = element["Port"]?.InnerText ?? "<none>";
					var protocol = element["Protocol"]?.InnerText ?? "<none>";
					var type = element["Type"]?.InnerText ?? "<none>";
					var user = element["User"]?.InnerText ?? "<none>";
					var pass = element["Pass"]?.InnerText ?? "<none>";
					var logonType = element["LogonType"]?.InnerText ?? "<none>";
					var encodingType = element["EncodingType"]?.InnerText ?? "<none>";
					var bypassProxy = element["BypassProxy"]?.InnerText ?? "<none>";

					if (pass != "<none>") pass = Encoding.UTF8.GetString(Convert.FromBase64String(pass));

					Console.WriteLine($"\tHost: {host}");
					Console.WriteLine($"\t\tPort: {port}");
					Console.WriteLine($"\t\tProtocol: {protocol}");
					Console.WriteLine($"\t\tType: {type}");
					Console.WriteLine($"\t\tUser: {user}");
					Console.WriteLine($"\t\tPass: {pass}");
					Console.WriteLine($"\t\tLogon Type: {logonType}");
					Console.WriteLine($"\t\tEncoding Type: {encodingType}");
					Console.WriteLine($"\t\tBypass Proxy: {bypassProxy}");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
		else
		{
			Console.WriteLine("Can't find FileZilla recent servers file (recentservers.xml).");
		}

		Console.ReadKey();
	}
}