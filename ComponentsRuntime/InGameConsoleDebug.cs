using Game.InternalData;
using UnityEngine;

namespace Game.Components
{
/// <summary>
/// In game debug console to view console from build
/// Make sure that resources asset not include to release build
/// Move file outside from resources folder
/// </summary>
internal class InGameConsoleDebug : MonoBehaviour
{
#if DEVELOPMENT_BUILD
    [SerializeField] private bool _enableInEditor;
    [SerializeField] private int _countTouchToDestroy = 5;

    private GameObject _cachedConsole;
    
    private void Start()
    {
        EnableInGameDebugConsole();
    }
    
    private void EnableInGameDebugConsole()
    {
        
#if UNITY_EDITOR
        
        if (_enableInEditor == false)
            return;
        
#endif
        
        var consolePrefab = Resources.Load<GameObject>("IngameDebugConsole");
        if (consolePrefab == null) 
        {
            Log.Warning("IngameDebugConsolePrefab not found");
            return;
        }

        _cachedConsole = Instantiate(consolePrefab);
    }

    private void Update()
    {
        if (Input.touchCount == _countTouchToDestroy)
            Destroy(_cachedConsole.gameObject);
    }

#endif

#if UNITY_EDITOR

    private const string InResourcesFolder = "Assets/Plugins/IngameDebugConsole/Resources/IngameDebugConsole.prefab";
    private const string OutsideResourcesFolder = "Assets/Plugins/IngameDebugConsole/IngameDebugConsole.prefab";
    
    private const string Title = "In-game console";
    
    private const string InspectAsset = "Inspect prefab asset";
    private const string ToResources = "Move to resource folder";
    private const string FromResources = "Move from resource folder";
    
    [ContextMenu(InspectAsset)]
    private void SelectInGamePrefab()
    {
        SelectInGamePrefabStatic();
    }
    
    [ContextMenu(ToResources)]
    private void MoveToResources()
    {
        MoveToResourcesStatic();
    }
    
    [ContextMenu(FromResources)]
    private void MoveFromResources()
    {
        MoveFromResourcesStatic();
    }
    
    [UnityEditor.MenuItem(GameData.EditorName + "/" + Title + "/" + InspectAsset)]
    private static void SelectInGamePrefabStatic()
    {
        var inGameConsole = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(InResourcesFolder);
        if (inGameConsole == null)
            inGameConsole = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(OutsideResourcesFolder);

        if (inGameConsole == null)
        {
            Debug.LogWarning("Can't find asset");
            return;
        }

        UnityEditor.Selection.activeObject = inGameConsole;
    }
    
    [UnityEditor.MenuItem(GameData.EditorName + "/" + Title + "/" + ToResources)]
    private static void MoveToResourcesStatic()
    {
        var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(OutsideResourcesFolder);
        if (asset == null)
        {
            Debug.LogWarning($"Asset from [{OutsideResourcesFolder}] not found");
            return;
        }

        var result = UnityEditor.AssetDatabase.MoveAsset(OutsideResourcesFolder, InResourcesFolder);
        Debug.Log($"Result moving: {(string.IsNullOrEmpty(result) ? "Success" : result)}");
        
        UnityEditor.AssetDatabase.Refresh();
    }
    
    [UnityEditor.MenuItem(GameData.EditorName + "/" + Title + "/" + FromResources)]
    private static void MoveFromResourcesStatic()
    {
        var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(InResourcesFolder);
        if (asset == null)
        {
            Debug.LogWarning($"Asset from [{InResourcesFolder}] not found");
            return;
        }

        var result = UnityEditor.AssetDatabase.MoveAsset(InResourcesFolder, OutsideResourcesFolder);
        Debug.Log($"Result moving: {(string.IsNullOrEmpty(result) ? "Success" : result)}");
        
        UnityEditor.AssetDatabase.Refresh();
    }
    
#endif
}
}