using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VRInteraction : MonoBehaviour
{
    public Camera vrCamera;
    public Image cursor;

    public float actionRate = 2; // как часто срабатывает взгляд
    float nextAction;

    public float multipleCursor = 2; // на сколько увеличится курсор
    RectTransform cursorTransform;// компонент трансформации курсора
    Vector2 startCursorSize;// стартовый размер курсора


    void Start()
    {
        cursorTransform = cursor.GetComponent<RectTransform>(); // получаем компонент у курсора RectTransform
        startCursorSize = cursorTransform.sizeDelta; // сохраняем стартовый размер курсора 
        nextAction = actionRate;

    }


    void Update()
    {
        Ray ray = vrCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // луч из центра камеры
        RaycastHit hit; // обьект с которым столкнется луч

        // пускаем луч и проверяем обьект пересечения
        if (Physics.Raycast(ray, out hit) && hit.transform.GetComponent<IVRInteractible>() != null) 
        {
            cursorTransform.sizeDelta += new Vector2(multipleCursor, multipleCursor) * Time.deltaTime;

            // Debug.Log(hit.collider.gameObject.name);
            if (Time.time >= nextAction)
            {
                nextAction = Time.time + actionRate;
                ClearCursor();
                hit.transform.GetComponent<IVRInteractible>().OnRedy();

            }
        }     
        else
        {
            nextAction = Time.time + actionRate;
        }

	}
    void ClearCursor()
    {
        cursorTransform.sizeDelta = startCursorSize;
    }
}
