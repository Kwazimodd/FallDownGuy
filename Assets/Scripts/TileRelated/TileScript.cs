using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

public class TileScript : Tile
{
    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
    {
        if (go != null)
        {
            go.GetComponent<SpriteRenderer>().sortingOrder = -position.y * 2;
        }
        return base.StartUp(position, tilemap, go);
    }
    [MenuItem("Assets/Create/Tiles/TileScript")]
    public static void CreateTreeTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Tile", "New Tile", "asset", "Save Tile", "Assets");
        if (path == "")
        {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<TileScript>(), path);
    }
}
