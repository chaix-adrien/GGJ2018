using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public static class ScriptGameOptions {
	public static int playersNumber;
	public static GamePad.Index?[] gamepads;	
	public static Color[] playerColors;

	public static bool gameEnded = false;
	public static KeyValuePair<Color, int>[] scores;
}
