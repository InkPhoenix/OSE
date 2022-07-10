using UnityEngine;

namespace DevCon.Commands
{
	public class MiscellaneousCommands
	{
        [ConsoleMethod("write", "Writes text to the console || write 'your text here'"), UnityEngine.Scripting.Preserve]
        public static void LogText(string[] args)
        {
            string text = string.Join(" ", args);
            Debug.Log(text);
        }
        [ConsoleMethod("game.end", "Closes the game"), UnityEngine.Scripting.Preserve]
        public static void end()
        {
            Application.Quit();
        }
    }
}
