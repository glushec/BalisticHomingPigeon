using UnityEditor;
using UnityEngine;
using System.IO;

public class CopyFullPath : MonoBehaviour
{
    [MenuItem("Assets/Copy Full Path %#c", false, 2000)]  // CTRL + SHIFT + C
    private static void CopyPath()
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        string fullPath = Path.GetFullPath(path);
        
        GUIUtility.systemCopyBuffer = fullPath;
        Debug.Log("Copied to clipboard: " + fullPath);
    }

    [MenuItem("Assets/Copy Full Path", true)]
    private static bool CopyPathValidation()
    {
        return Selection.activeObject != null;
    }
}