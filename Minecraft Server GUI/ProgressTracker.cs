using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Minecraft_Server_GUI
{
	internal interface IProgressTracker
	{
		/// <summary>
		/// Возвращает текущий прогресс.
		/// </summary>
		int CurrentProgress { get; }

		/// <summary>
		/// Обрабатывает новую строку лога и возвращает текущий прогресс (0–100).
		/// </summary>
		int UpdateProgress(string logLine);

		void ResetProgress();
	}

	internal class VanillaProgressTracker : IProgressTracker
	{
		private readonly Dictionary<string, int> stages = new()
		{
			{ "Starting minecraft server", 10 },
			{ "Loading properties", 20 },
			{ "Preparing level", 40 },
			{ "Preparing spawn area", 70 },
			{ "Done", 100 }
		};

		public int CurrentProgress { get; private set; } = 0;

		public void ResetProgress()
		{
			CurrentProgress = 0;
		}

		public int UpdateProgress(string logLine)
		{
			foreach (var kvp in stages)
				if (logLine.Contains(kvp.Key) && kvp.Value > CurrentProgress)
					CurrentProgress = kvp.Value;

			// Обработка "Preparing spawn area: XX%"
			if (logLine.Contains("Preparing spawn area"))
			{
				var match = Regex.Match(logLine, @"Preparing spawn area: (\d+)%");
				if (match.Success)
				{
					int chunkPercent = int.Parse(match.Groups[1].Value);
					int mappedProgress = 40 + (int)(chunkPercent * 0.3f); // 40–70%

					if (mappedProgress > CurrentProgress)
						CurrentProgress = mappedProgress;
				}
			}

			return CurrentProgress;
		}
	}

	internal class ForgeProgressTracker : IProgressTracker
	{
		private readonly Dictionary<string, int> stages = new()
		{
			{ "Forge Mod Loader", 10 },
			{ "Completed early Minecraft initialization", 20 },
			{ "PreInitialization Event", 30 },
			{ "Initialization Event", 50 },
			{ "PostInitialization Event", 70 },
			{ "Minecraft Forge", 80 },
			{ "Preparing spawn area", 90 },
			{ "Done", 100 },
		};

		public int CurrentProgress { get; private set; } = 0;

		public void ResetProgress()
		{
			CurrentProgress = 0;
		}

		public int UpdateProgress(string logLine)
		{
			foreach (var kvp in stages)
				if (logLine.Contains(kvp.Key) && kvp.Value > CurrentProgress)
					CurrentProgress = kvp.Value;
			// Обработка "Preparing spawn area: XX%"
			if (logLine.Contains("Preparing spawn area"))
			{
				var match = Regex.Match(logLine, @"Preparing spawn area: (\d+)%");
				if (match.Success)
				{
					int chunkPercent = int.Parse(match.Groups[1].Value);
					int mappedProgress = 80 + chunkPercent / 10; // 80–90%

					if (mappedProgress > CurrentProgress)
						CurrentProgress = mappedProgress;
				}
			}

			return CurrentProgress;
		}
	}
	internal enum CoreType
	{
		Unknown = 0,   // Если ядро не определено
		Vanilla,   // Ванильный сервер
		Forge,     // Forge сервер
		Fabric,    // Fabric сервер
		Spigot,    // Spigot/Paper сервер
		Quilt      // Quilt сервер
	}
}