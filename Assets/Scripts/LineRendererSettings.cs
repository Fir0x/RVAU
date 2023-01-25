using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRendererSettings : MonoBehaviour
{
    [SerializeField] LineRenderer rend;
    public LayerMask layerMask;
    public Button btn;

    private Vector3[] points;


    void Start()
    {
        rend = gameObject.GetComponent<LineRenderer>();

        points = new Vector3[2];
        points[0] = Vector3.zero;
        points[1] = transform.position + new Vector3(0, 0, 20);

        rend.SetPositions(points);
        rend.enabled = true;
    }

    void Update()
    {
        if (AlignLineRenderer(rend))
            btn.onClick.Invoke();
    }

    public bool AlignLineRenderer(LineRenderer rend)
    {
        bool hitButton = false;

        Ray ray;
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, layerMask))
        {
            points[1] = transform.forward + new Vector3(0, 0, hit.distance);

            rend.startColor = Color.red;
            rend.endColor = Color.red;

            btn = hit.collider.gameObject.GetComponent<Button>();

            hitButton = true;
        }
        else
        {
            points[1] = transform.forward + new Vector3(0, 0, 20);

            rend.startColor = Color.green;
            rend.endColor = Color.green;

            hitButton = false;
        }

        rend.SetPositions(points);

        rend.material.color = rend.startColor;

        return hitButton;
    }
}
