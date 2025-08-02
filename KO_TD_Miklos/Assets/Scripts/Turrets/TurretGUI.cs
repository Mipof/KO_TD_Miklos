using UnityEngine;

public class TurretGUI : MonoBehaviour
{
    private TurretBase[] turretBases;

    [SerializeField] private GameObject _sellTurret;
    [SerializeField] private GameObject _upgradeTuret;
    [SerializeField] private GameObject _carrousel;
    [SerializeField] private GameObject _closeBtn;

    private TurretCarrousel turretCarrousel;
    private TurretBase currentBase;

    private void Start()
    {
        turretBases = FindObjectsOfType<TurretBase>();
        foreach (TurretBase turretBase in turretBases)
        {
            turretBase.OnClick.AddListener(OpenGUIData);
        }

        turretCarrousel = FindObjectOfType<TurretCarrousel>();
        CloseGui();

    }

    public void CloseGui()
    {
        _sellTurret.SetActive(false);
        _upgradeTuret.SetActive(false);
        _carrousel.SetActive(false);
        _closeBtn.SetActive(false);
    }

    private void OpenGUIData(TurretBase turretBase)
    {
        currentBase = turretBase;
        CloseGui();
        if (turretBase.GetTurretData() == null)
        {
            _carrousel.SetActive(true);
            turretCarrousel.onTurretBuy.AddListener(TurretBuyed);
            _closeBtn.SetActive(true);
        }
        else
        {
            if (turretBase.GetTurretData().turret.canBeUpgraded)
            {
                _upgradeTuret.SetActive(true);
            }
            _closeBtn.SetActive(true);
            _sellTurret.SetActive(true);
        }
    }

    private void TurretBuyed(TurretDataSO turret)
    {
        currentBase.SetTurret(turret);
        CloseGui();
    }

    public void UpgradeTurret()
    {
        if (!currentBase.GetTurretData().turret.upgradedTurret) { return;}
        currentBase.SetTurret(currentBase.GetTurretData().turret.upgradedTurret);
        CloseGui();
    }

    public void SellTurret()
    {
        currentBase.SetTurret(null);
        CloseGui();
    }

}
