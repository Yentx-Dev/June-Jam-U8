using System;
using UnityEditor.SceneManagement;
using UnityEngine;


[RequireComponent(typeof(SkinnedMeshRenderer))]
public class SoftBody : MonoBehaviour
{
    [Range(0f, 2f)]
    public float softness = 1f;

    [Range(0f, 1f)]
    public float damping = 0.1f;

    public float stiffness = 1f;

    private void Start()
    {
        SoftbodyPhysics();
    }

    void SoftbodyPhysics()
    {
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

        if (skinnedMeshRenderer == null)
        {
            Debug.Log("Missing SKM");
            return;
        }

        Cloth cloth = gameObject.AddComponent<Cloth>();
        cloth.damping = damping;
        cloth.bendingStiffness = stiffness;

        cloth.coefficients = GenerateClothCoefficients(skinnedMeshRenderer.sharedMesh.vertices.Length);
    }

    private ClothSkinningCoefficient[] GenerateClothCoefficients(int vertexCount)
    {
        ClothSkinningCoefficient[] coefficients = new ClothSkinningCoefficient[vertexCount];

        for (int i = 0; i < vertexCount; i++)
        {
            coefficients[i].maxDistance = softness;
            coefficients[i].collisionSphereDistance = 0f;
        }

        return coefficients;
    }
}
