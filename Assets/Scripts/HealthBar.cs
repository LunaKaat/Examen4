using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image UIHealthFrame;
    public Image UIHealthBar;

    private Character character;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }


    void Update()
    {
        UIHealthBar.fillAmount = (float)character.currentHP / (float)character.HP;
    }
}
