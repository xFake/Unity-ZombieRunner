using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{

    public GameObject heliCallText;

    public IEnumerator BlinkText(bool spotSelected)
    {
        while (spotSelected == true)
        {
            heliCallText.SetActive(true);
            yield return new WaitForSeconds(.5f);
            heliCallText.SetActive(false);
            yield return new WaitForSeconds(.5f);// something wrong test it !!
        }
    }
}
