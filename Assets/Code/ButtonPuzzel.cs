using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzel : MonoBehaviour
{

    public List<Buttons> sequence;

    [SerializeField]
    List<Buttons> InputButtons;

    bool pass = false;

    bool Start = true;

    public GameObject Door;

    public enum Buttons
    {
        Blue,
        Green,
        Red
    }
    private void Update()
    {
        if(Start && InputButtons.Count > 0)
        {
            InputButtons.Clear();
            StartCoroutine(StartSequance());
        }

        if (sequence.Count == InputButtons.Count && !Start)
        {
            pass = true;

            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] != InputButtons[i])
                    pass = false;
            }

            if (pass)
                Pass();
            else
                Fail();
        }
    }

    public void PressButton(Buttons Inp_Button)
    {
        InputButtons.Add(Inp_Button);
    }

    void Pass()
    {
        Door.GetComponent<AN_DoorScript>().isOpened = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<ButtonInter>().tag = "Untagged";
        }
        InputButtons.Clear();
        SFXManager.TheSFXGuy.PlaySFX("Success");
    }

    void Fail()
    {
        Start = true;
        InputButtons.Clear();
        SFXManager.TheSFXGuy.PlaySFX("Fail");
    }

    public IEnumerator StartSequance()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<ButtonInter>().tag = "Untagged";
            transform.GetChild(i).GetComponent<ButtonInter>().Light();
        }
        yield return new WaitForSeconds(3);

        for (int i = 0; i < sequence.Count; i++)
        {
            for (int o = 0; o < transform.childCount; o++)
            {
                if (transform.GetChild(o).GetComponent<ButtonInter>().Type == sequence[i])
                {
                    transform.GetChild(o).GetComponent<ButtonInter>().Light();
                    break;
                }
                
            }
            yield return new WaitForSeconds(2);
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<ButtonInter>().tag = "Interactable";            
        }

        Start = false;
    }
}
