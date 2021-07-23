using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    private Transform camTransform;
    private Transform lightTransform;
    public GameObject directionLight;

    // Start is called before the first frame update
    void Start()
    {
        directionLight = GameObject.Find("Directional Light");
        lightTransform = directionLight.GetComponent<Transform>();
        camTransform = this.GetComponent<Transform>();
        Weapon huntingBow = new Weapon("Hunting Bow", 105);
        Paladin knight = new Paladin("Sir Arthur", huntingBow);
        //knight.PrintStatsInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
