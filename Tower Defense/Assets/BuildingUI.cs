using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class BuildingUI : MonoBehaviour
{
    public GameObject ui;
    public TurretPlatform platform;

    public TurretBlueprint StandardTurret;
    public TurretBlueprint MissileTurret;
    public TurretBlueprint LaserTurret;
    BuildManager buildManager;
    private Vector3 positionOffset = new Vector3(6.3f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetTarget(TurretPlatform plat)
    {
        platform = plat;
        transform.position = platform.transform.position + positionOffset;
        ui.SetActive(true);
    }
    public void BuildTurret1()
    {
        BuildTurret(StandardTurret);
    }
    public void BuildTurret2()
    {
        BuildTurret(MissileTurret);
    }
    public void BuildTurret3()
    {
        BuildTurret(LaserTurret);
    }

    private void BuildTurret(TurretBlueprint tb)
    {
        buildManager.setTurretToBuild(tb);
        buildManager.BuildTurret(platform);

    }
    public void Hide()
    {
        ui.SetActive(false);
    }
}
