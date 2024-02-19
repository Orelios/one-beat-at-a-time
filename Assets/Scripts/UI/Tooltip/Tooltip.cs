using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;
    public LayoutElement layoutElement;
    public int characterWrapLimit;

    #region Anchor tooltip dynamically part1
    //NOTE: if dynamic anchor is not desired and instead, tooltip is to be anchored to tip of mouse,
    //set Tooltip.RectTransform.Pivot x=0, y=1
    public RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    #endregion

    public void SetText(string content, string header = "")
    {
        #region Check Header
        if (string.IsNullOrEmpty(header)) //if header is null OR empty
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }
        #endregion

        contentField.text = content;

        //can move #region Tooltip Length here if length is final (TooltipCanvas > Tooltip.LayoutElement.PreferredWidth)
        /*
        #region Tooltip Length
        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
        #endregion
        */
    }

    private void Update()
    {
        #region Tooltip Length
        if (Application.isEditor) //remove this if statement if moved to SetText()
        {
            //keeping this code in Update() allows for live checking of tooltip length for easy editing
            //otherwise move this to SetText()
            int headerLength = headerField.text.Length;
            int contentLength = contentField.text.Length;

            layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
        }
        #endregion

        #region Tooltip follows mouse position
        Vector2 mousePosition = Input.mousePosition;
        transform.position = mousePosition;
        #endregion

        #region Anchor tooltip dynamically part2
        float pivotX = mousePosition.x / Screen.width;
        float pivotY = mousePosition.y / Screen.height;
        rectTransform.pivot = new Vector2(pivotX, pivotY);
        #endregion
    }
}
