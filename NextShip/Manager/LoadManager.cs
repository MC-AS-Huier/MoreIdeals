using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using NextShip.Languages;
using NextShip.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NextShip.Manager;

[HarmonyPatch]
public static class LoadManager
{
    public static bool Loaded = false;
    private static bool Started = false;

    public static List<IEnumerator> AllLoad = new ();

    [HarmonyPatch(typeof(SplashManager), nameof(SplashManager.Update)), HarmonyPrefix]
    public static bool SplashManager_Update_Patch_Load(SplashManager __instance)
    {
        if (Loaded || Started || !__instance.doneLoadingRefdata || !(Time.time - __instance.startTime > __instance.minimumSecondsBeforeSceneChange)) return Loaded;
        __instance.StartCoroutine(Load(__instance));
        Started = true;
        return Loaded;
    }

    [HarmonyPatch(typeof(SplashManager), nameof(SplashManager.Start)), HarmonyPostfix]
    public static void SplashManager_InitializeRefdata_Patch_OnVanillaManagerLoaded(SplashManager __instance)
    {
        Loaded = false;
    }

    public static IEnumerator Load(SplashManager __instance)
    {
        if (AllLoad.Count == 0 || AllLoad == null)
        {
            Loaded = true;
            yield break;  
        }
        
        float t = 1;
        var c2 = Color.white;
        c2.a = 0;

        var logo = GameObjectUtils.CreateCGameObject<SpriteRenderer>();
        var text = GameObjectUtils.CreateCGameObject<TextMeshPro>();

        logo.gameObject.transform.localPosition = new Vector3(0, 0, -5);
        text.gameObject.transform.localPosition = new Vector3(0.2f, -0.9f, -5);

        logo.sprite = SpriteUtils.NextShipText_Sprite;

        text.text = "Loading.....";
        text.alignment = TextAlignmentOptions.Center;
        text.fontSize = 4.5f;
        
        while (t > 0)
        {
            t -= 0.01f;
            text.color = logo.color = Color.Lerp(Color.white, c2, t);
            yield return null;
        }

        foreach (var co in AllLoad.Select(load => new StackFullCoroutine(load)))
        {
            while (co.MoveNext()) yield return null;
        }
        
        t = 1;
        text.text = "Load Complete";
        
        while (t > 0)
        {
            t -= 0.01f;
            text.color = logo.color = Color.Lerp(c2, Color.white, t);
            yield return null;
        }

        Loaded = true;
    }

    [HarmonyPatch(typeof(AccountManager), nameof(AccountManager.Awake)), HarmonyPostfix]
    public static void AccountManager_Awake_Patch()
    {
        var fill = GameObject.Find("BlockFill");
        var color = new Color(0, 0, 0);
        color.a = 0.9f;
        fill.GetComponent<SpriteRenderer>().color = color;

        var text = new GameObject("Text");
        text.transform.SetParent(fill.transform);
        text.transform.localPosition = new Vector3(0.02f, -0.04f, -5);
        var TMP = text.AddComponent<TextMeshPro>();
        TMP.text = "登录中...";
        TMP.alignment = TextAlignmentOptions.Center;
        TMP.fontSize = 5;
    }
}