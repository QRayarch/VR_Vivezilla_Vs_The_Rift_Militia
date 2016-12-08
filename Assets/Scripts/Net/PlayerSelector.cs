using UnityEngine;
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
    public int godzillaHealth;
    public int jeepHealth;
    private Health healthComponent;

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
        healthComponent = GetComponent<Health>();
        if (VRDevice.model.Contains("Oculus"))
        {
            CmdSetMode(Mode.Rift);
            healthComponent.SetHealth(jeepHealth);
            return;
        }
        if (VRDevice.model.Contains("Vive"))
        {
            //LOAD IN THE VIVEZILLA HAHAH
            CmdSetMode(Mode.Vive);
            healthComponent.SetHealth(godzillaHealth);
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
            SetLocalOnly(vivePlayer.transform, isLocalPlayer);
        }
        if(m == Mode.Rift)
        {
            riftPlayer.SetActive(true);
            SetLocalOnly(riftPlayer.transform, isLocalPlayer);
        }
        if (m == Mode.Spectator)
        {
            spectorPlayer.SetActive(true);
            SetLocalOnly(spectorPlayer.transform, isLocalPlayer);
        }
    }

    private void SetLocalOnly(Transform t, bool isLocal)
    {
        for(int c = 0; c < t.childCount; ++c)
        {
            if(t.GetChild(c).CompareTag("LocalOnly"))
            {
                t.GetChild(c).gameObject.SetActive(isLocal);
            }
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

        float forward = -Input.GetAxis("Vertical");
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
        Vector3 angles = spectorPlayer.transform.rotation.eulerAngles;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angles.y -= rotateSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angles.y += rotateSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            angles.x -= rotateSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            angles.x += rotateSpeed * Time.deltaTime;
        }
        spectorPlayer.transform.rotation = Quaternion.Euler(angles);
    }

    public Mode GetMode()
    {
        return mode;
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.CompareTag("Bullet"))
    //    {
    //        Debug.Log("HIT");
    //        healthComponent.Damage(1);
    //        Debug.Log("current heal;th: " + healthComponent.health);
    //    }
    //}
}
