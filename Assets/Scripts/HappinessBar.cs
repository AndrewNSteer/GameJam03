using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessBar : MonoBehaviour
{
    public GameObject qm;
    QuestManager qmScript;
    public Slider slider;
    float happiness;

void Start()
    {
        qm = GameObject.FindGameObjectWithTag("QM");
        qmScript = qm.GetComponent<QuestManager>();

        happiness = qmScript.happiness;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = qmScript.happiness;
    }
}
