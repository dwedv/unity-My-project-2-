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
        originalMaterial = color1; // �ٶ���ʼʱCapsule��ԭʼ��ɫ
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("player"))
        {

            ChangeMaterial(color2); // �ı���ɫ
            Invoke("RestoreMaterial", 3f); // ������ɫ�ı����1��
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
