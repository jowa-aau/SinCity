using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class SpritePixelsPerUnitChanger : AssetPostprocessor
    {
        void OnPreprocessTexture ()
        {
            TextureImporter textureImporter  = (TextureImporter) assetImporter;
            textureImporter.spritePixelsPerUnit = 64;
            textureImporter.filterMode = FilterMode.Point;
        }
    }
}