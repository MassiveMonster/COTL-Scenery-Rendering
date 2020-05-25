using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomRenderTextures : MonoBehaviour
{
    public List<RenderTextureObject> RenderTextureObjects = new List<RenderTextureObject>();

    void Start()
    {
    }

    [System.Serializable]
    public class RenderTextureObject
    {
        public Rect rect;
        public Texture texture;
        public RenderTextureObject(Rect rect, Texture texture)
        {
            this.rect = rect;
            this.texture = texture;
        }
    }

    private void Update()
    {
    }
}
