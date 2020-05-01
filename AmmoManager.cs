using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{

    Text ammoText;
    public GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        ammoText = GetComponent<Text>();
        ammoText.text = "AMMO: 100/100";
    }

    // Update is called once per frame
    void Update()
    {
        int currAmmo = gun.GetComponent<Gun>().currentAmmo;
        ammoText.text = "AMMO: " + currAmmo.ToString() + "/100";
    }
}
