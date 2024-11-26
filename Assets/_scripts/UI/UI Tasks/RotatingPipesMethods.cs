using UnityEngine;
using UnityEngine.UI;

public class RotatingPipesMethods : UIPlayerVerification
{
    [Header("Rotating Pipes Task Settings")]
    public GameObject PipeHolder;
    public GameObject[] Pipes;
    [SerializeField]private int _totalPipes = 0;

    #region TaskVerificationMethods
    protected override void Start()
    {
        base.Start();
        _totalPipes = PipeHolder.transform.childCount;
        Pipes = new GameObject[_totalPipes];

        for (int i = 0; i < Pipes.Length; i++)
        {
            Pipes[i] = PipeHolder.transform.GetChild(i).gameObject;
        }
    }
    private void CompleteTask()
    {
      uiTasks.CompleteUITask();
      Debug.Log("¡Rotating Pipes Task Completed!");
    }
    #endregion
}
