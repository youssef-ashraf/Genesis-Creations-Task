using UnityEngine;
using Image = UnityEngine.UI.Image;

public class Sleeping : MonoBehaviour
{
    public ATMBalance aTMBalance;
    float time, opacity;
    public void OnEnable()
    {
        time = 0;
        opacity = 0.01f;
        aTMBalance.atmBalance += (int)(aTMBalance.atmBalance * 0.1);
    }
    private void Update()
    {
        Image backgroud = GetComponent<Image>();
        if (time > 1.5f)
            opacity = -0.01f;
        backgroud.color = new Color(backgroud.color.r, backgroud.color.g, backgroud.color.b, backgroud.color.a + opacity);
        time += Time.deltaTime;

        if (time > 3)
        {
            backgroud.color = new Color(backgroud.color.r, backgroud.color.g, backgroud.color.b, 0);
            gameObject.SetActive(false);
        }
    }
}
