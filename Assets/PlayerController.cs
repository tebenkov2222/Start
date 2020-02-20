using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region public
    public GameObject brevno, hand;
    public float SizeX = 1, SizeY = 1, SizeZ = 1, deltaSize = 0.1f;
    #endregion
    #region private
    private GameObject InHand = null;
    private int Size = 0; 
    #endregion
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
            InHand = Instantiate(brevno, hand.gameObject.transform.position, Quaternion.identity);
            InHand.GetComponentInChildren<CapsuleCollider>().enabled = false;
        }
        if (Input.GetKey(KeyCode.Space) && InHand != null)
        {
            InHand.GetComponentInChildren<CapsuleCollider>().enabled = false;
            InHand = null;
        }
        if (Input.GetKey(KeyCode.Z) && InHand != null)
        {
            Size = 0;
        }
        if (Input.GetKey(KeyCode.X) && InHand != null)
        {
            Size = 1;
        }
        if (Input.GetKey(KeyCode.Y) && InHand != null)
        {
            Size = 2;
        }
        if (Input.GetKey(KeyCode.Plus) && InHand != null)
        {
            Resize(true);
        }
        if (Input.GetKey(KeyCode.Minus) && InHand != null)
        {
            Resize(false);
        }
    }
    private void Resize(bool Sum)
    {
        switch (Size)
        {
            case 0:
                {
                    if (Sum) SizeZ += deltaSize;
                    else SizeZ -= deltaSize;
                    break;
                }
            case 1:
                {
                    if (Sum) SizeX += deltaSize;
                    else SizeX -= deltaSize;
                    break;
                }
            case 2:
                {
                    if (Sum) SizeY += deltaSize;
                    else SizeY -= deltaSize;
                    break;
                }
        }
        InHand.transform.localScale = new Vector3(SizeX, SizeY, SizeZ);
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
