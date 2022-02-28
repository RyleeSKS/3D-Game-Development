using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    private IState entryState;
    private IState currentState;

    private void Awake()
    {
        entryState = new GreenState(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetState(entryState);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.OnStateUpdate();
        }
    }

    public void SetState(IState state)
    {
        if(currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = state;
        currentState.OnStateEnter();
    }
}

public interface IState
{
    public void OnStateEnter();
    public void OnStateUpdate();
    public void OnStateExit();
}

public class GreenState : IState
{
    private FiniteStateMachine instance;
    //private MeshRenderer r;

    //public GreenState(MeshRenderer rend)
    public GreenState(FiniteStateMachine fsm)
    {
        // r.material.color = Color.green;
        instance = fsm;
    }

    public void OnStateEnter()
    {
        instance.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    public void OnStateExit()
    {
        Debug.Log("greenstate has finished executing");
    }

    public void OnStateUpdate()
    {
        Debug.Log("grren state is currently executtiong");
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            instance.SetState(new RedState(instance)); // transition to a new state
        }
    }
    
}
public class RedState : IState
{
    private FiniteStateMachine instance;
    //private MeshRenderer r;

    //public GreenState(MeshRenderer rend)
    public RedState(FiniteStateMachine fsm)
    {
        // r.material.color = Color.green;
        instance = fsm;
    }

    public void OnStateEnter()
    {
        instance.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void OnStateExit()
    {
        Debug.Log(" red state has finished executing");
    }

    public void OnStateUpdate()
    {
        Debug.Log("red state is currently executtiong");
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            instance.SetState(new GreenState(instance)); // transition to a new state
        }
    }
    
}