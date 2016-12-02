﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.VR;

public class PlayerSelector : NetworkBehaviour
{
    public enum Mode
    {
        None,
        Spectator,
        Vive,
        Rift,
    }

    public GameObject vivePlayer;
    public GameObject riftPlayer;
    public GameObject spectorPlayer;

    [Header("RiftUpdate")]
    public JeepMovement jeepMove;
    public MountPivot pivot;
    public BarrelMovement barrle;

    [SyncVar(hook = "DisplayMode")]
    public Mode mode = Mode.None;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        CheckForMode();
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        DisplayMode(mode);
    }

    public void CheckForMode()
    {
        if (VRDevice.model.Contains("Oculus"))
        {
            CmdSetMode(Mode.Rift);
            return;
        }
        if (VRDevice.model.Contains("Vive"))
        {
            //LOAD IN THE VIVEZILLA HAHAH
            CmdSetMode(Mode.Vive);
            return;
        }
        CmdSetMode(Mode.Spectator);
    }

    [Command]
    public void CmdSetMode(Mode m)
    {
        mode = m;
    }

    public void DisplayMode(Mode m)
    {
        mode = m;
        vivePlayer.SetActive(false);
        riftPlayer.SetActive(false);
        spectorPlayer.SetActive(false);

        if (m == Mode.Vive)
        {
            vivePlayer.SetActive(true);
        }
        if(m == Mode.Rift)
        {
            riftPlayer.SetActive(true);
        }
        if (m == Mode.Spectator)
        {
            spectorPlayer.SetActive(true);
           
            spectorPlayer.transform.GetChild(0).gameObject.SetActive(isLocalPlayer);
        }
    }


    public void Update()
    {
        if (!isLocalPlayer)
            return;
        if(mode == Mode.Spectator)
        {
            UpdateSpecator();
        } else if(mode == Mode.Rift)
        {
            UpdateRift();
        }
        
    }

    public void UpdateRift()
    {
        float uD = Input.GetAxis("Right Stick Y");
        barrle.Rotate(uD);
        if (Input.GetButton("Fire1") || Input.GetAxis("Fire1") > 0.2f)
        {
            barrle.Fire();
        }

        float lR = Input.GetAxis("Right Stick X");
        pivot.Rotate(lR);

        float forward = Input.GetAxis("Vertical");
        float rot = Input.GetAxis("Horizontal");
        jeepMove.MoveFwd(forward);
        jeepMove.doRotation(rot);
    }
    
    private void UpdateSpecator()
    {
        if (Input.GetKey(KeyCode.W))
        {
            spectorPlayer.transform.position += spectorPlayer.transform.forward * 100 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            spectorPlayer.transform.position -= spectorPlayer.transform.forward * 100 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            spectorPlayer.transform.position -= spectorPlayer.transform.right * 100 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            spectorPlayer.transform.position += spectorPlayer.transform.right * 100 * Time.deltaTime;
        }
        float rotateSpeed = 100;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spectorPlayer.transform.rotation *= Quaternion.Euler(0, -rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            spectorPlayer.transform.rotation *= Quaternion.Euler(0, rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            spectorPlayer.transform.rotation *= Quaternion.Euler(-rotateSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            spectorPlayer.transform.rotation *= Quaternion.Euler(rotateSpeed * Time.deltaTime, 0, 0);
        }
    }
}
