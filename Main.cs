using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace Antifreeze;

public class Init : IModApi
{
	public void InitMod(Mod _modInstance)
	{
		Log.Out("Mod::[Antifreeze] ⚙ LOADING...");
		Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "v1.UnloadTheUAntifreeze.7DTD.redbeardt");
		Log.Out("Mod::[Antifreeze] ✔ LOADED.");
	}
}

[HarmonyPatch(typeof(Resources))]
public static class __Resources
{
	[HarmonyPatch("UnloadUnusedAssets"), HarmonyPrefix]
	public static bool Prefix__UnloadUnusedAssets(ref bool __runOriginal)
	{
		if(!XUi.IsGameRunning()) return __runOriginal = true; 

		Log.Out(@"[Mod:Antifreeze] Blocked a call to Resources.UnloadUnusedAssets() 
call - No freeze for you!");
		__runOriginal = false;
		return false;
	}
}
