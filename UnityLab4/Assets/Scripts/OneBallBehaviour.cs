using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBallBehaviour : MonoBehaviour
{
     //public bool DrawLine = false;
     //public bool DrawRay = false;
     //public float XRotation = 0;
     //public float YRotation = 1;
     //public float ZRotation = 0;
     //public float DegreePerSecond = 180;

     public float XSpeed;
     public float YSpeed;
     public float ZSpeed;
     public float Multiplier = 0.75f;

     static int BallCount = 0;
     public int BallNumber = 0;

     public float TooFar = 5;

     // Start is called before the first frame update
     void Start()
    {
          BallNumber = ++BallCount;
          transform.position = new Vector3(3 - Random.value * 6, 3 - Random.value * 6, 3 - Random.value * 6);
     }

    // Update is called once per frame
    void Update()
    {
          transform.Translate(XSpeed * Time.deltaTime, YSpeed * Time.deltaTime, ZSpeed * Time.deltaTime);

          XSpeed += Multiplier - Random.value * Multiplier * 2;
          YSpeed += Multiplier - Random.value * Multiplier * 2;
          ZSpeed += Multiplier - Random.value * Multiplier * 2;

          if ((Mathf.Abs(transform.position.x) > TooFar)
               || (Mathf.Abs(transform.position.y) > TooFar)
               || (Mathf.Abs(transform.position.z) > TooFar))
          {
               ResetBall();
          }

          //Vector3 axis = new Vector3(XRotation, YRotation, ZRotation);
          //transform.RotateAround(Vector3.zero, axis, DegreePerSecond * Time.deltaTime);

          //if (DrawLine)
          //{
          //     Debug.DrawLine(this.transform.position, Vector3.zero, Color.red, 0.5f * Time.deltaTime);
          //}
          //if (DrawRay)
          //{
          //     Debug.DrawRay(this.transform.position, axis, Color.yellow);
          //     Debug.DrawRay(Vector3.zero, axis, Color.yellow);
          //}
     }

     void OnMouseDown()
     {
          GameController controller = Camera.main.GetComponent<GameController>();
          if (!controller.GameOver)
          {
               controller.ClickedOnBall();
               Destroy(gameObject);
          }
     }

     void ResetBall()
     {
          XSpeed = Multiplier - Random.value * Multiplier * 2;
          YSpeed = Multiplier - Random.value * Multiplier * 2;
          ZSpeed = Multiplier - Random.value * Multiplier * 2;

          transform.position = new Vector3(3 - Random.value * 6, 3 - Random.value * 6, 3 - Random.value * 6);
     }
}
