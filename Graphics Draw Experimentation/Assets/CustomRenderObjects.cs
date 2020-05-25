using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;

public class CustomRenderObjects : MonoBehaviour
{
    public List<Sprite> Sprites = new List<Sprite>();

    public SpriteAtlas spriteAtlas;
    MaterialPropertyBlock materialPropertyBlock;

    public Mesh mesh;
    public Material material;
    public List<RenderObject> RenderObjects = new List<RenderObject>();

    [System.Serializable]
    public class RenderObject
    {
        public Vector3 Transform;
        public Mesh mesh;
        public Material material;
        public Sprite sprite;
        public Color color;
        public Vector4 ST;
        public float Scale;
        public  RenderObject (Vector3 Transform, Mesh mesh, Material material, Sprite sprite)
        {
            this.Transform = Transform;
            this.mesh = mesh;
            this.material = material;
            this.sprite = sprite;
            this.mesh = mesh;
            this.ST = new Vector4(1, 1, sprite.textureRect.position.x / sprite.texture.width, sprite.textureRect.position.y / sprite.texture.height);
        }
    }

    public int Num = 100;
    void Start()
    {
        while (RenderObjects.Count < (int)(Num / Sprites.Count))
        {
            foreach (Sprite s in Sprites)
                RenderObjects.Add(new RenderObject(UnityEngine.Random.insideUnitSphere * 10, mesh, material, s));
        }
    }

    private void Update()
    {
        materialPropertyBlock = new MaterialPropertyBlock();
        foreach (RenderObject renderObject in RenderObjects)
        {
            materialPropertyBlock.SetTexture("_MainTex", renderObject.sprite.texture);
            materialPropertyBlock.SetVector("_MainTex_ST", renderObject.ST);
            Graphics.DrawMesh(renderObject.mesh, renderObject.Transform, Quaternion.identity, renderObject.material, 0, null, 0, materialPropertyBlock);
        }
    }
}
