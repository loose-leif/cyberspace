using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperImposeButton : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Transform targetTransform;
    private RectTransform rectTransform;
    private Image image;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    /*
    void Start()
    {
        screenPoint = new Vector3(100.0f, 100.0f, 0.0f);

    }
    */

    // Update is called once per frame
    void Update()
    {
        
        var screenPoint = Camera.main.WorldToScreenPoint(targetTransform.position);
        rectTransform.position = screenPoint;

        //var viewportPoint = Camera.main.WorldToViewportPoint(targetTransform.position);
        Debug.Log(screenPoint);


        //var show = distanceFromCenter < 0.3f;
        image.enabled = true;
    }
}
