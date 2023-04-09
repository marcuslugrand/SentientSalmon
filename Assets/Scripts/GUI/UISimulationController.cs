/// Author: Samuel Arzt
/// Date: March 2017


#region Includes
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;
#endregion

/// <summary>
/// Class for controlling the various ui elements of the simulation
/// </summary>
public class UISimulationController : MonoBehaviour
{
    #region Members
    private CarController target;
    /// <summary>
    /// The Car to fill the GUI data with.
    /// </summary>
    public CarController Target
    {
        get { return target; }
        set
        {
            if (target != value)
            {
                target = value;

                //if (target != null) NeuralNetPanel.Display(target.Agent.FNN);
            }
        }
    }

    // GUI element references to be set in Unity Editor.
    [SerializeField]
    private TextMeshProUGUI[] InputTexts;
    [SerializeField]
    private TextMeshProUGUI Evaluation;
    [SerializeField]
    private TextMeshProUGUI GenerationCount;

    // track average distance of total track a fish is traveling
    private float averageDistance;
    private uint generationCount;
    //[SerializeField]
    //private UINeuralNetworkPanel NeuralNetPanel;
    #endregion

    #region Constructors
    void Awake()
    {
        averageDistance = 0;
        Evaluation.text = "";
        generationCount = 1;
    }
    #endregion

    #region Methods
    void Update()
    {
        if (Target != null)
        {
            //Display controls
            if (Target.CurrentControlInputs != null)
            {
                for (int i = 0; i < InputTexts.Length; i++)
                    InputTexts[i].text = Target.CurrentControlInputs[i].ToString();
            }

            if (generationCount < EvolutionManager.Instance.GenerationCount)
            {
                averageDistance += EvolutionManager.Instance.averageEvaluation;
                Evaluation.text = ((averageDistance / generationCount) * 100).ToString("N2"); // only show 10^2 precision
                generationCount = EvolutionManager.Instance.GenerationCount;
            }
            
            GenerationCount.text = EvolutionManager.Instance.GenerationCount.ToString() + "/" + EvolutionManager.Instance.totalGenerationCount.ToString();
        }
    }

    /// <summary>
    /// Starts to display the gui elements.
    /// </summary>
    public void Show()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Stops displaying the gui elements.
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    #endregion
}
