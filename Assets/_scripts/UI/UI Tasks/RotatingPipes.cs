using UnityEngine;

public class RotatingPipes : MonoBehaviour
{
    [Header("Pipe Settings")]
    private float[] rotations = { 0, 90, 180, 270 };
    public float correctRotation;
    public bool isPlaced = false;

    private void Start()
    {
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);
        if (transform.eulerAngles.z == correctRotation && isPlaced == false)
        {
            isPlaced = true;
        }
    }

    public void MouseOn()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        if(transform.eulerAngles.z == correctRotation && isPlaced == false)
        {
            isPlaced = true;
        }else if(isPlaced == true)
        {
            isPlaced = false;
        }
    }

}
