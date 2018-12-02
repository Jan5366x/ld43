using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPanel : MonoBehaviour
{
    enum WeaponTypes
    {
        SingleShot
    }

    List<GameObject> icons = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        icons.Insert((int)WeaponTypes.SingleShot, GameObject.FindWithTag("SingleShotIcon"));


    }

    // Update is called once per frame
    void Update()
    {

    }
}
