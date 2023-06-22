using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTetikleyici : MonoBehaviour
{

    public Dialog[] dialog;

    public UzunYaziDenetleyici uzunYazi;


    public void DialogTetikle(int i)
	{
        uzunYazi.StartDialogue(dialog[i]);
	}


}
