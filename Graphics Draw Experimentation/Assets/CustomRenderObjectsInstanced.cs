using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class CustomRenderObjectsInstanced : MonoBehaviour
{
    public Mesh cubeMesh;
    public Mesh mesh;
    public Material cubeMaterial;
    List<Matrix4x4> transformList = new List<Matrix4x4>();
    public Sprite sprite;

    void Start()
    {
        transformList = new List<Matrix4x4>();
        Vector3 position;
        Matrix4x4 matrix;
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int z = 0; z < 10; z++)
                {
                    //We will assume you want to create your cube of cubes at 0,0,0
                    position = new Vector3(x * 2, y * 2, z * 2);

                    //Create a matrix for the position created from this iteration of the loop
                    matrix = new Matrix4x4();

                    //Set the position/rotation/scale for this matrix
                    matrix.SetTRS(position, Quaternion.Euler(Vector3.zero), Vector3.one);

                    //Add the matrix to the list, which will be used when we use DrawMeshInstanced.
                    transformList.Add(matrix);
                }
            }
        }

        //mesh = SpriteToMesh(sprite);
        //cubeMaterial.mainTexture = sprite.texture;


        Debug.Log(transformList.Count);

    }


    private Mesh SpriteToMesh(Sprite sprite)
    {
        Mesh mesh = new Mesh();
        mesh.SetVertices(Array.ConvertAll(sprite.vertices, i => (Vector3)i).ToList());
        mesh.SetUVs(0, sprite.uv.ToList());
        mesh.SetTriangles(Array.ConvertAll(sprite.triangles, i => (int)i), 0);

        return mesh;
    }

    // Update is called once per frame
    void Update()
    {

        //After the for loops are finished, and transformList has several matrices in it, simply pass DrawMeshInstanced the mesh, a material, and the list of matrices containing all positional info.
        Graphics.DrawMeshInstanced(mesh, 0, cubeMaterial, transformList);

    }
}
