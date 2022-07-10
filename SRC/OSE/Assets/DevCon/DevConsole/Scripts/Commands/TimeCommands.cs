using UnityEngine;

namespace DevCon.Commands
{
	public class TimeCommands
	{
		[ConsoleMethod("time.speed", "Sets the Time.timeScale value"), UnityEngine.Scripting.Preserve]
		public static void SetTimeScale(float value)
		{
			Time.timeScale = Mathf.Max(value, 0f);
		}

		[ConsoleMethod("time.speed", "Returns the current Time.timeScale value"), UnityEngine.Scripting.Preserve]
		public static float GetTimeScale()
		{
			return Time.timeScale;
		}
	}
}
