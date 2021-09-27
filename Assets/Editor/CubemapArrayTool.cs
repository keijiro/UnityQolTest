using UnityEngine;
using UnityEditor;

static class CubemapArrayTool
{
    const int _width = 64;
    const int _layerCount = 8;

    static Color ColorPattern(int x, int y, int i)
      => new Color((float)x / _width, (float)y / _width, (float)i / _layerCount);

    [MenuItem("QoL/Create CubemapArray Asset")]
    static void CreateCubemapArrayAsset()
    {
        var tex = new CubemapArray(_width, _layerCount, TextureFormat.RGBA32, false);

        var pix = new Color[_width * _width];

        for (var i = 0; i < _layerCount; i++)
        {
            var offs = 0;
            for (var y = 0; y < _width; y++)
                for (var x = 0; x < _width; x++)
                    pix[offs++] = ColorPattern(x, y, i);

            tex.SetPixels(pix, CubemapFace.NegativeX, i, 0);
            tex.SetPixels(pix, CubemapFace.PositiveX, i, 0);
            tex.SetPixels(pix, CubemapFace.NegativeY, i, 0);
            tex.SetPixels(pix, CubemapFace.PositiveY, i, 0);
            tex.SetPixels(pix, CubemapFace.NegativeZ, i, 0);
            tex.SetPixels(pix, CubemapFace.PositiveZ, i, 0);
        }

        tex.Apply();

        AssetDatabase.CreateAsset(tex, "Assets/CubemapArray.asset");
        AssetDatabase.SaveAssets();
    }
}
