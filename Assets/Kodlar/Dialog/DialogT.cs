using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogT : MonoBehaviour
{
    public Dialog[] dialog;

    public UzunYazi2 uzunYazi;


    public void DialogTetikle(int i)
    {
        uzunYazi.StartDialogue(dialog[i]);
    }

}
