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
        if (starterAssetsInputs.aim)
        {
            aimCamera.gameObject.SetActive(true);
            thirdPersonController.updateSensitivity(ZoomAimSensitivity);
        }
        else
        {
            aimCamera.gameObject.SetActive(false);
            thirdPersonController.updateSensitivity(NormalAimSensitivity);
        }
    }
}
