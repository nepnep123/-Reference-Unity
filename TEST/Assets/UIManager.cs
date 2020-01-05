using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    //전체 UI 
    public CanvasGroup canvasGroup;
    //버튼 그룹
    public ButtonGroups buttonGroups;

    private void Awake()
    {
        if (instance == null) instance = GetComponent<UIManager>();
        else DestroyImmediate(this);
    }

    private void Start()
    {
        StartCoroutine(CanvasState(false));
        //StartCoroutine(InstructSequence());
    }

    //전체적인 UI ON / OFF
    public IEnumerator CanvasState(bool a)
    {
        float timer;
        //UI 전체 ON
        if (a == true)
        {
            timer = 0;
            while (timer < 1)
            {
                timer += Time.deltaTime;
                canvasGroup.alpha = timer;
                yield return null;
            }
        }
        //UI 전체 OFF
        else
        {
            timer = 1;
            while (timer > 0)
            {
                timer -= Time.deltaTime;
                canvasGroup.alpha = timer;
                yield return null;
            }
        }
    }

    public IEnumerator InstructSequence()
    {
        float timer = 0;
        for (int i = 0; i < buttonGroups.buttons.Length; i++)
        {
            while (timer < 1)
            {
                timer += Time.deltaTime;
                buttonGroups.buttons[i].alpha = timer;
                yield return null;
            }
            yield return new WaitForSeconds(2f);
            timer = 1;
            while (timer > 0)
            {
                timer -= Time.deltaTime;
                buttonGroups.buttons[i].alpha = timer;
                yield return null;
            }
        }
    }
}
