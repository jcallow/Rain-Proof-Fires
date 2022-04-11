using System;
using System.Reflection;
using HarmonyLib;
using UnityEngine;

public class RainProofFires : Mod
{
    private static Harmony m_harmony;
    private const string ModName = "RainProofFires";
    private const string HarmonyId = "com.jcallow.projects.rainprooffires";
    public void Start()
    {
        m_harmony = new Harmony(HarmonyId);
        var assembly = Assembly.GetExecutingAssembly();
        m_harmony.PatchAll(assembly);
        Debug.Log("Mod RainProofFires has been loaded!");
    }

    public void OnModUnload()
    {
        m_harmony.UnpatchAll(HarmonyId);
        Debug.Log("Mod RainProofFires has been unloaded!");
    }
    
}

[HarmonyPatch(typeof(Firecamp))]
class RainProofFirePatch {
    private static Boolean raining = false;
    [HarmonyPrefix]
    [HarmonyPatch("CheckRain")]
    static bool CheckRain() {
        return false;
    }
}