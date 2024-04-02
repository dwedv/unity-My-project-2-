using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    public Material color1;
    public Material color2;
    private Material originalMaterial;
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = color1;
        originalMaterial = color1; // 假定开始时Capsule是原始颜色
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("player"))
        {

            ChangeMaterial(color2); // 改变颜色
            Invoke("RestoreMaterial", 3f); // 假设颜色改变持续1秒
        }
    }

    private void ChangeMaterial(Material newMaterial)
    {
        renderer.material = newMaterial;
    }

    void RestoreMaterial()
    {
        renderer.material = originalMaterial;
    }
}
