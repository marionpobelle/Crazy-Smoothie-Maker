using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Errors : MonoBehaviour
{

    [SerializeField]
    private Sprite[] errorNotes;

    [SerializeField]
    private SpriteRenderer errorNotebook;

    // Update is called once per frame
    void Update()
    {
        int currentErrors = FindObjectOfType<GameManager>().GetErrors();
        if(currentErrors == 1) errorNotebook.sprite = errorNotes[0];
        if(currentErrors == 2) errorNotebook.sprite = errorNotes[1];
        if(currentErrors == 3) errorNotebook.sprite = errorNotes[2];
    }
}
