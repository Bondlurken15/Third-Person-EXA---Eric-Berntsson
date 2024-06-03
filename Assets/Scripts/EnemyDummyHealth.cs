using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDummyHealth : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI damageTakenText;
    [SerializeField] Material hitEffectMaterial;
    [SerializeField] float blindDuration;

    MeshRenderer meshRenderer;
    Material startMaterial;
    
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        startMaterial = meshRenderer.material;
    }

    void Update()
    {
        
    }

    public void DisplayDamage(int damageToDisplay)
    {
        if (meshRenderer != null)
        {
            StartCoroutine(ChangeColor());
        }
        
        if (damageTakenText!= null)
        {
            damageTakenText.text = damageToDisplay.ToString();
        }
    }

    IEnumerator ChangeColor()
    {
        meshRenderer.material = hitEffectMaterial;

        yield return new WaitForSeconds(blindDuration);

        meshRenderer.material = startMaterial;
    }
}
