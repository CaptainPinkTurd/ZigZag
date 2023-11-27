using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoad : MonoBehaviour
{
    public GameObject roadMapProcedural;
    public Transform[] location;
    [SerializeField] GameObject crystal;
    private float nextTimeCall = 0f;

    private void Start()
    {
        nextTimeCall = Time.time + 0.25f;  
    }

    private void CreateCrystal()
    {
        int chances = UnityEngine.Random.Range(0, 100);
        if(chances > 25)
        {
            Destroy(crystal);
        }
        else
        {
            crystal.SetActive(true);
        }
    }
    private void CreateRoadPart()
    {
        int chances = UnityEngine.Random.Range(0, 100);
        if (chances < 50)
        {
            CreateCrystal();
            Instantiate(roadMapProcedural, location[0].position, Quaternion.Euler(0, 45, 0));
            location[0].gameObject.SetActive(false);
            location[1].gameObject.SetActive(false);
            this.enabled = false;
        }
        else
        {
            CreateCrystal();
            Instantiate(roadMapProcedural, location[1].position, Quaternion.Euler(0, 45, 0));
            location[0].gameObject.SetActive(false);
            location[1].gameObject.SetActive(false);
            this.enabled = false;    
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextTimeCall)
        {
            if(CharacterMovementScript.animator.GetBool("gameStarted"))
            {
                CreateRoadPart();
            }
            nextTimeCall += 0.25f;
        }
    }
}
