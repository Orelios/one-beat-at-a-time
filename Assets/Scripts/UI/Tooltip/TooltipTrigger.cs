using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string header;
    public string content;

    private bool showTooltip = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        showTooltip = true;
        StartCoroutine(DelayedShow());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        showTooltip = false;
        TooltipSystem.Instance.Hide();
    }

    IEnumerator DelayedShow()
    {
        for (float timer = TooltipSystem.Instance.delayTooltip; timer >= 0; timer -= Time.deltaTime)
        {
            //if any time during the timer coundown, showTooltip becomes false, then stop coroutine
            if (showTooltip == false)
            {
                yield break;
            }
            yield return null;
        }
        //else show tooltip after delay
        TooltipSystem.Instance.Show(content, header);
    }
}
