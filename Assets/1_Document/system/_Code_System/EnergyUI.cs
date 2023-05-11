using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering;

public class EnergyUI : MonoBehaviour
{
    public Image icon;
    public Text textEnergy;
    public float speed = 5f;

    int maxEnergy;

    [SerializeField] int currentTarget;
    [SerializeField] float current;
    public void Init(int maxEnergy)
    {
        this.maxEnergy = maxEnergy; 
        textEnergy.text = "0/" + maxEnergy;  
    }

    private void Update()
    {
        SetText();
    }

    void SetText()
    {
        
        if (current == currentTarget) return;

        if( current < currentTarget)
        {
            current += (speed * Time.deltaTime);

        }
        else
        {
            current -= (speed * Time.deltaTime);
        }

        current = Mathf.Clamp(current, 0, currentTarget);
        textEnergy.text = (int)current + "/" + maxEnergy;
    }

    public void SetEnergy(int currentEnergy)
    {
        currentTarget = currentEnergy;
        //textEnergy.text = currentEnergy + "/" + maxEnergy;
    }
}
