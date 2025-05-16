using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationScript : MonoBehaviour
{
    public NPCConversation Conver;
    private MouseInput mouseInputScript;
    private KeyboardInput keyboardInputScript;

    void Start()
    {
        mouseInputScript = FindObjectOfType<MouseInput>();
        keyboardInputScript = FindObjectOfType<KeyboardInput>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                mouseInputScript.enabled = false;
                keyboardInputScript.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                ConversationManager.Instance.StartConversation(Conver);
            }
        }
    }

    public void ExitConvo()
    {
        mouseInputScript.enabled = true;
        keyboardInputScript.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
