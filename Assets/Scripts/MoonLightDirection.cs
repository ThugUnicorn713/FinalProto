using UnityEngine;

[ExecuteInEditMode]
public class MoonLightDirection : MonoBehaviour
{
    [SerializeField]
    private Material skyboxMaterial;

    private void Update()
    {
        skyboxMaterial.SetVector(name = "_MainLightDirection", transform.forward);
    }

}
