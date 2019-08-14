using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;
    //creates an accessible array of all waypoints making up the enemies path
    void Awake ()
    {
      points = new Transform[transform.childCount];
      for (int i = 0; i < points.Length; i++)
      {
        points[i] = transform.GetChild(i);
      }
    }

}
