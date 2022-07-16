using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace DevCon.Commands
{
	public class SceneCommands
	{
		[ConsoleMethod("scene.load", "Loads a scene"), UnityEngine.Scripting.Preserve]
		public static void LoadScene(string sceneName)
		{
            DOTween.KillAll();
            LoadSceneInternal(sceneName, false, LoadSceneMode.Single);
		}

		[ConsoleMethod("scene.load", "Loads a scene"), UnityEngine.Scripting.Preserve]
		public static void LoadScene(string sceneName, LoadSceneMode mode)
		{
            DOTween.KillAll();
            LoadSceneInternal(sceneName, false, mode);
		}

		[ConsoleMethod("scene.loadasync", "Loads a scene asynchronously"), UnityEngine.Scripting.Preserve]
		public static void LoadSceneAsync(string sceneName)
		{
            DOTween.KillAll();
            LoadSceneInternal(sceneName, true, LoadSceneMode.Single);
		}

		[ConsoleMethod("scene.loadasync", "Loads a scene asynchronously"), UnityEngine.Scripting.Preserve]
		public static void LoadSceneAsync(string sceneName, LoadSceneMode mode)
		{
            DOTween.KillAll();
            LoadSceneInternal(sceneName, true, mode);
		}

		private static void LoadSceneInternal(string sceneName, bool isAsync, LoadSceneMode mode)
		{
			if(SceneManager.GetSceneByName(sceneName).IsValid())
			{
				Debug.Log("Scene " + sceneName + " is already loaded");
				return;
			}

			if(isAsync)
				SceneManager.LoadSceneAsync(sceneName, mode);
			else
				SceneManager.LoadScene(sceneName, mode);
		}

		[ConsoleMethod("scene.unload", "Unloads a scene"), UnityEngine.Scripting.Preserve]
		public static void UnloadScene(string sceneName)
		{
			SceneManager.UnloadSceneAsync(sceneName);
		}

		[ConsoleMethod("scene.restart", "Restarts the active scene"), UnityEngine.Scripting.Preserve]
		public static void RestartScene()
		{
            DOTween.KillAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
		}

        [ConsoleMethod("scene.list", "Lists all scenes present in the build settings by build order"), UnityEngine.Scripting.Preserve]
        public static void ListScene()
        {
            int sceneCountTotal = SceneManager.sceneCountInBuildSettings;
            string[] sceneNameTotal = new string[sceneCountTotal];
            string result = "Total scenes in build: " + sceneCountTotal + " || Scenes:     (click here)\n\n";

            for (int i = 0; i < sceneCountTotal; i++)
            {
                sceneNameTotal[i] = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            }

            foreach(string scn in sceneNameTotal) { result += scn.ToString() + "\n"; } //add scene names to result
            Debug.Log(result);
        }

        [ConsoleMethod("scene.list.loaded", "Lists all scenes currently loaded"), UnityEngine.Scripting.Preserve]
        public static void ListSceneLoaded()
        {
            int loadedSceneCountTotal = SceneManager.sceneCount;
            string[] loadedSceneNameTotal = new string[loadedSceneCountTotal];
            string result = "Total scenes loaded: " + loadedSceneCountTotal + " || Scenes:     (click here)\n\n";

            for (int i = 0; i < loadedSceneCountTotal; i++)
            {
                loadedSceneNameTotal[i] = SceneManager.GetSceneAt(i).name;
            }

            foreach (string scn in loadedSceneNameTotal) { result += scn.ToString() + "\n"; } //add scene names to result
            Debug.Log(result);
        }
    }
}
