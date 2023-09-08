using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChainGenerator : MonoBehaviour
{
    //prefab
    //chain, wreakingball
    //chainlegth
    [SerializeField] GameObject chainLinkObj;
    [SerializeField] GameObject wreakingBall;
    [SerializeField] int chainLength;

        GameObject[] chainlinks;
    private void Start()
    {
        /*
         for i to chainlegth
            if i ==0 
            instantiate object
            this.fixed joint conect to insobj.rigdbody
            
            else if(i == chainlegth-1)
               instantiate objectball
                previouschain.joint=ball
                
            else{
                instatiate object
                current.chain
            }
         */
        chainlinks = new GameObject[chainLength];
        for (int i = 0; i < chainLength; i++)
        {
            if (i == 0)
            {
                GameObject chainlink = Instantiate(chainLinkObj, Vector3.down * (-.4f * i), Quaternion.identity); 
                chainlinks[i] = chainlink;
                chainlink.GetComponent<HingeJoint2D>().connectedBody=this.GetComponent<Rigidbody2D>();
            }
            else {
                GameObject chainlink = Instantiate(chainLinkObj, Vector3.down * (-.4f * i), Quaternion.identity);
                chainlinks[i] = chainlink;
                chainlink.GetComponent<HingeJoint2D>().connectedBody = chainlinks[i-1].GetComponent<Rigidbody2D>();
            }
        }
    }
}

