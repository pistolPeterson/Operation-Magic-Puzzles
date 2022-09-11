using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButtonSize : MonoBehaviour
{
    public void IncreaseSize()
    {
        this.gameObject.transform.localScale += new Vector3(0.5f, 0.5f, 0f);
    }
    public void DecreaseSize()
    {
        this.gameObject.transform.localScale -= new Vector3(0.5f, 0.5f, 0f);
    }
}
