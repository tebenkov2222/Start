using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region public
    public GameObject brevno, hand;
    #endregion
    #region private
    private GameObject InHand = null;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckButton();
        brevnoInHand();
    }
    private void CheckButton()
    {
        if (Input.GetKey(KeyCode.R) && InHand == null)
        {
            //InHand = Instantiate(brevno, hand.gameObject.transform.position, Quaternion.identity);
            InHand.GetComponentInChildren<CapsuleCollider>().enabled = false;
        }
        if (Input.GetKey(KeyCode.Space) && InHand != null)
        {
            //InHand.GetComponentInChildren<CapsuleCollider>().enabled = true;
            InHand = null;
        }
    }
    private void brevnoInHand()
    {
        if (InHand)
        {
            InHand.transform.position = hand.transform.position;
        }
    }
    public bool Hand()
    {
        if (InHand) return true;
        else return false;
    }
}
