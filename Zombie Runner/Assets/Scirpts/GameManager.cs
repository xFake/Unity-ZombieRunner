using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{

    public GameObject heliCallText;
    
    public void StartText(bool spotSelected){
        if (spotSelected){
            StartCoroutine("BlinkText");
        }
        else {
            StopCoroutine("BlinkText");
            heliCallText.SetActive(false);
        }
    }

    private IEnumerator BlinkText(){
        while (true){
            heliCallText.SetActive(true);
            yield return new WaitForSeconds(.5f);
            heliCallText.SetActive(false);
            yield return new WaitForSeconds(.5f);
        }
    }


}
