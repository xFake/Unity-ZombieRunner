using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieRunner;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour{

    public GameObject heliCallText;
    public GameObject menuPanel;

    private bool lockCursor = false;
    private FirstPersonController fPC;

    private void Start()
    {
        fPC = FindObjectOfType<FirstPersonController>();
    }

    public void StartText(bool spotSelected){
        if (spotSelected){
            StartCoroutine("BlinkText");
        }
        else {
            StopCoroutine("BlinkText");
            heliCallText.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            lockCursor = !lockCursor;
            menuPanel.SetActive(true);
            fPC.enabled = false;
        }


        Cursor.lockState = lockCursor ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = lockCursor;
    }
    private IEnumerator BlinkText(){
        while (true){
            heliCallText.SetActive(true);
            yield return new WaitForSeconds(.5f);
            heliCallText.SetActive(false);
            yield return new WaitForSeconds(.5f);
        }
    }

    public void ContinueGame() {
        Time.timeScale = 1;
        lockCursor = false;
        fPC.enabled = true;
    }


}
