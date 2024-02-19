using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : Singleton<TooltipSystem>
{
    public Tooltip tooltip;
    public float delayTooltip = 0.5f;

    public void Show(string content, string header = "")
    {
        tooltip.SetText(content, header);
        tooltip.gameObject.SetActive(true);
    }

    public void Hide()
    {
        tooltip.gameObject.SetActive(false);
    }
}
