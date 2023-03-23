using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class CameraToggle : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimCamera;
    [SerializeField] private float ZoomAimSensitivity;
    [SerializeField] private float NormalAimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] Transform debugTransform;
    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 screenmid = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenmid);
        Vector3 mouse3DPosition = Vector3.zero;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouse3DPosition = raycastHit.point;
        }
       
        if (starterAssetsInputs.aim)
        {
            aimCamera.gameObject.SetActive(true);
            thirdPersonController.updateSensitivity(ZoomAimSensitivity);
            //Current Mouse Position
            Vector3 aimTarget = mouse3DPosition;
            aimTarget.y = transform.position.y;
            //Calculating Rotation --> (target - player pos) --> unit vector
            Vector3 aimDirection = (aimTarget - transform.position).normalized;
            //Rotating the rigid body of the player
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
            thirdPersonController.setRotateOnMove(false);
        }
        else
        {
            aimCamera.gameObject.SetActive(false);
            thirdPersonController.updateSensitivity(NormalAimSensitivity);
            thirdPersonController.setRotateOnMove(true);
        }

      
    }
}
