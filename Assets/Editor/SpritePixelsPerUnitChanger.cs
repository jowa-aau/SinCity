using UnityEditor;

namespace Editor
{
    public class SpritePixelsPerUnitChanger : AssetPostprocessor
    {
        void OnPreprocessTexture ()
        {
            TextureImporter textureImporter  = (TextureImporter) assetImporter;
            textureImporter.spritePixelsPerUnit = 64;
        }
    }
}