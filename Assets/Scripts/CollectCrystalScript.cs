using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectCrystalScript : MonoBehaviour
{
    [SerializeField] GameObject crystalEffect;
    [SerializeField] TMP_Text plusScore;
    [SerializeField] AudioSource collectSound;
    private void OnTriggerEnter(Collider other)
    {
        collectSound.Play();    
        GameObject vfx = Instantiate(crystalEffect, other.transform.position + new Vector3(0f,0.4f,0f), Quaternion.identity);
        TMP_Text vfx2 = Instantiate(plusScore, this.transform.position, Quaternion.identity);
        Destroy(vfx, 2f);
        Destroy(vfx2, 1.2f);
        Destroy(this.gameObject);
        ScoreScript.score += 2;
    }
}
