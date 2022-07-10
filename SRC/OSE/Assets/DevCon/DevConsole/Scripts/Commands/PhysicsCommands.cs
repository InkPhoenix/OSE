using UnityEngine;

namespace DevCon.Commands
{
	public class PhysicsCommands
	{
        [ConsoleMethod("Physics.gravity", "Changes the gravity value"), UnityEngine.Scripting.Preserve]
        public static void SetGravity(float grav)
        {
            Physics.gravity = new Vector3(Physics.gravity.x, grav, Physics.gravity.z);
        }

        [ConsoleMethod("Physics.gravity", "Returns the current gravity value"), UnityEngine.Scripting.Preserve]
		public static float GetGravity()
		{
            return Physics.gravity.y;
		}
	}
}
