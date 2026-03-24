using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class SettingUI : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    [SerializeField] Button _closeButton;
    [SerializeField] TMP_Dropdown _qualityDrop;
    [SerializeField] Toggle _vsyncToggle;
    [SerializeField] Toggle _fullScreenToggle;
    [SerializeField] Toggle _noShadowToggle;
    [SerializeField] Toggle _softShadowToggle;
    [SerializeField] Toggle _hardShadowToggle;
    [SerializeField] Slider _particlesResolutionSlider;



    #endregion

    #region Unity Callbacks

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _closeButton.onClick.AddListener(CloseSettings);
        _qualityDrop.onValueChanged.AddListener(SetQuality);
        _vsyncToggle.onValueChanged.AddListener(SetVSync);

        _particlesResolutionSlider.onValueChanged.AddListener(SetParticlesResolution);
        _noShadowToggle.onValueChanged.AddListener(SetNoShadows);
        _noShadowToggle.onValueChanged.AddListener(SetSoftShadows);

        InitializeDropDownQuality();

    }





    #endregion

    #region Private Methods

    private void InitializeDropDownQuality()
    {
        List<string> options = new List<string>(QualitySettings.names);
        _qualityDrop.ClearOptions();
        _qualityDrop.AddOptions(options);

        _qualityDrop.value = QualitySettings.GetQualityLevel();
        _qualityDrop.RefreshShownValue();

    }
    private void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index, true);
    }

    private void SetVSync(bool stateOn)
    {
        if (stateOn)
            QualitySettings.vSyncCount = 1;
        else
            QualitySettings.vSyncCount = 0;
    }
    private void SetParticlesResolution(float level)
    {
        QualitySettings.particleRaycastBudget = (int)level;
    }
    private void SetSoftShadows(bool stateOn)
    {
        if (stateOn)
            QualitySettings.shadows = ShadowQuality.Disable;
    }
    private void SetNoShadows(bool stateOn)
    {
        if (stateOn)
            QualitySettings.shadows = ShadowQuality.All;
        //QualitySettings.shadows = ShadowQuality.HardOnly;
    }

    private void CloseSettings()

    {

        gameObject.SetActive(false);

    }

    #endregion
}
