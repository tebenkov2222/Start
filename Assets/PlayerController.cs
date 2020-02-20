using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region public
    public GameObject brevno, hand;
    public GameObject[] Models;
    public float SizeX = 1, SizeY = 1, SizeZ = 1, deltaSize = 0.1f;
    #endregion
    #region private
    private GameObject InHand = null;
    private int Size = 0, Selected = 0; 
    #endregion
    // Update is called once per frame
    void Update()
    {
        CheckButton();
        brevnoInHand();
    }
    private void CheckButton()
    {
        if (InHand == null)
        {
            if (Input.GetKey(KeyCode.R))
            {
                InHand = Instantiate(brevno, hand.gameObject.transform.position, Quaternion.identity);
                InHand.GetComponent<Rigidbody>().useGravity = false;
                InHand.GetComponentInChildren<CapsuleCollider>().enabled = false;
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                if (Selected != Models.Length - 1)
                {
                    Selected += 1;
                }
                else Selected = 0;
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                if (Selected > 0)
                {
                    Selected -= 1;
                }
                else Selected = 0;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Z))
            {
                Size = 0;
            }
            if (Input.GetKey(KeyCode.X))
            {
                Size = 1;
            }
            if (Input.GetKey(KeyCode.Y))
            {
                Size = 2;
            }
            if (Input.GetKey(KeyCode.Keypad8))
            {
                Resize(true);
            }
            if (Input.GetKey(KeyCode.Keypad2))
            {
                Resize(false);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                InHand.GetComponent<Rigidbody>().useGravity = true;
                InHand.GetComponentInChildren<CapsuleCollider>().enabled = true;
                InHand = null;
                SizeX = 1; SizeY = 1; SizeZ = 1;
            }
        }
    }
    private void Resize(bool Sum)
    {
        switch (Size)
        {
            case 0:
                {
                    if (Sum) SizeZ += deltaSize;
                    else if (SizeZ > 0.1f) SizeZ -= deltaSize;
                    break;
                }
            case 1:
                {
                    if (Sum) SizeX += deltaSize;
                    else if (SizeX > 0.1f) SizeX -= deltaSize;
                    break;
                }
            case 2:
                {
                    if (Sum) SizeY += deltaSize;
                    else if (SizeY > 0.1f) SizeY -= deltaSize;
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
