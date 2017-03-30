using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public bool visibleOnStartup;

    private Animator animator;
    private CanvasGroup canvasGroup;

    public bool IsOpen
    {
        get { return animator.GetBool("IsOpen"); }
        set { animator.SetBool("IsOpen", value); }
    }

    public void Awake()
    {
        animator = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (visibleOnStartup)
        {
            animator.SetTrigger("ShowMenuTrigger");
        }

        //var rect = GetComponent<RectTransform>();
        //rect.offsetMax = rect.offsetMin = new Vector2(10f, 0f);
    }

    public void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
        {
            canvasGroup.blocksRaycasts = canvasGroup.interactable = false;
        }

        else
        {
            canvasGroup.blocksRaycasts = canvasGroup.interactable = true;
        }
    
    }

}