using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.VR;

public class PlayerSelector : NetworkBehaviour
{
    public enum Mode
    {
        Spectator,
        Vive,
        Rift,
    }

    public GameObject vivePlayer;
    public GameObject spectorPlayer;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (!hasAuthority) return;
        if (VRDevice.model.Contains("Vive"))
        {
            //LOAD IN THE VIVEZILLA HAHAH
            CmdInstancePlayer(Mode.Vive);
            return;
        }

        CmdInstancePlayer(Mode.Spectator);
    }

    [Command]
    public void CmdInstancePlayer(Mode mode)
    {
        vivePlayer.SetActive(false);
        spectorPlayer.SetActive(false);

        if (mode == Mode.Vive)
        {
            vivePlayer.SetActive(true);
        }
        if(mode == Mode.Spectator)
        {
            spectorPlayer.SetActive(true);
            spectorPlayer.transform.GetChild(0).gameObject.SetActive(isLocalPlayer);
        }
        Debug.Log(isLocalPlayer + " " + isClient + " " + isServer);
    }

    public void Update()
    {
        if (!isLocalPlayer)
            return;
        if(Input.GetKey(KeyCode.W))
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
