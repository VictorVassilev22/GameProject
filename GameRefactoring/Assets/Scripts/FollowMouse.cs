using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField]
    const float Speed = 4f;
    bool isRunning = false;

    float angle = 0f;
    bool isMainCamera = false;

    const float dx = 0.5f;
    const float dy = 0.5f;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", isRunning);
        if (Input.GetMouseButton(0))
        {
            isRunning = true;
            Vector3 mousePosition = Input.mousePosition;

#if UNITY_ANDROID
            mousePosition = Input.GetTouch(0).position;
#endif

            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            if (!gameObject.Equals(Camera.main))
                mousePosition.z = -Camera.main.transform.position.z;
            else
            {
                mousePosition.z = Camera.main.transform.position.z;
                isMainCamera = true;
            }

            Vector3 thisPosition = Vector3.MoveTowards(transform.position, mousePosition, Speed * Time.deltaTime);

            if(Mathf.Abs(mousePosition.x - thisPosition.x) > dx || Mathf.Abs(mousePosition.y - thisPosition.y) > dy)
            {
                if (!isMainCamera)
                {
                    angle = Mathf.Atan2(mousePosition.y - thisPosition.y, mousePosition.x - thisPosition.x) * Mathf.Rad2Deg - 90;
                    transform.position = thisPosition;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                }
            }
        }
        else
        {
            isRunning = false;
        }
    }
}
