using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using System.Net.Mime;
using System.Diagnostics;
public class FlowControl : MonoBehaviour
{
    private GameObject Gparticle;
    private ParticleSystem particle;
    private double Re = 0;
    private bool flag = false;

    private void Awake()
    {
        Gparticle = gameObject;
        particle = gameObject.GetComponent<ParticleSystem>();
    }
    void Start()
    {
        var sh = particle.shape;
        sh.enabled = true;
        var main = particle.main;
        var sizeoverlifetime = particle.sizeOverLifetime;
        sizeoverlifetime.enabled = true;
        var emission = particle.emission;
        emission.enabled = true;
        var colorOverLifetime = particle.colorOverLifetime;
        colorOverLifetime.enabled = true;

        Gparticle.transform.localScale = new Vector3(1f, 1f, 1f);
        main.startLifetime = 0.24f;
        main.startColor = new Color(255, 0, 0, 255);
        main.startSize = 0.008f;
        main.simulationSpeed = 1f;
        emission.rateOverTime = 4100;
        sh.angle = 0;
        sh.shapeType = ParticleSystemShapeType.Cone;
        sh.radius = 0.0001f;
        sh.arc = 360;
        sh.radiusThickness = 1;
        sh.arcMode = ParticleSystemShapeMultiModeValue.Random;
        sizeoverlifetime.size = new ParticleSystem.MinMaxCurve(1f, 1f);
    }

    public void Flow(double re)
    {
        Re = re;
        flag = true;
    }
    void Update()
    {
        if(flag)
        {
            var sh = particle.shape;
            sh.enabled = true;
            var main = particle.main;
            var sizeoverlifetime = particle.sizeOverLifetime;
            sizeoverlifetime.enabled = true;
            var emission = particle.emission;
            emission.enabled = true;
            var colorOverLifetime = particle.colorOverLifetime;
            colorOverLifetime.enabled = true;

            if ((Re >= 0) && (Re < 2000))
            {
                Gparticle.transform.localScale = new Vector3(1f, 1f, 1f);
                main.startLifetime = 0.24f;
                main.startColor = new Color(255, 0, 0, 255);
                main.startSize = 0.008f;
                main.simulationSpeed = 1f;
                emission.rateOverTime = 4100;
                sh.angle = 0;
                sh.shapeType = ParticleSystemShapeType.Cone;
                sh.radius = 0.0001f;
                sh.arc = 360;
                sh.radiusThickness = 1;
                sh.arcMode = ParticleSystemShapeMultiModeValue.Random;
                sizeoverlifetime.size = new ParticleSystem.MinMaxCurve(1f, 1f);
            }
            if ((Re >= 2000) && (Re < 2200))
            {
                sh.radius = 0.002f;
                main.startSize = 0.016f;
                sh.arcSpeed = 8f;
                sizeoverlifetime.size = new ParticleSystem.MinMaxCurve(0.5f, 0.5f);
                main.simulationSpeed = 20f;
                emission.rateOverTime = 4100;
            }
            else if ((Re >= 2200) && (Re < 2400))
            {
                sizeoverlifetime.size = new ParticleSystem.MinMaxCurve(1f, 1f);
                Color color = new Color32(255, 0, 0, 255);
                main.startColor = color;
                sh.radius = 0.003f;
                main.startSize = 0.008f;
                main.simulationSpeed = 25f;
                emission.rateOverTime = 2000;
                sh.angle = 0.1f;
                sh.radius = 0.0001f;
                sh.arcMode = ParticleSystemShapeMultiModeValue.BurstSpread;
                Gradient gradient = new Gradient();
                gradient.SetKeys(
                    new GradientColorKey[] { new GradientColorKey(new Color(255, 0, 0, 255), 0.115f),
                                         new GradientColorKey(new Color(226, 63, 63, 255), 0.376f),
                                         new GradientColorKey(new Color(236, 177, 177, 255), 0.65f),
                                         new GradientColorKey(new Color(236, 178, 178, 255), 1f)
                                            },
                    new GradientAlphaKey[] { new GradientAlphaKey(255f, 0.0f),
                                         new GradientAlphaKey(136f, 1.0f)
                                            }
                );
                colorOverLifetime.color = new ParticleSystem.MinMaxGradient(gradient);
            }
            else if ((Re >= 2400) && (Re < 2600))
            {
                main.simulationSpeed = 0.2f;
                sh.angle = 0.2f;
                emission.rateOverTime = 1900;
            }
            else if ((Re >= 2600) && (Re < 2800))
            {
                sh.angle = 0.3f;
                emission.rateOverTime = 1800;
            }
            else if ((Re >= 2800) && (Re < 3000))
            {
                sh.angle = 0.4f;
                emission.rateOverTime = 1700;
            }
            else if ((Re >= 3000) && (Re < 3200))
            {
                sh.angle = 0.5f;
                emission.rateOverTime = 1600;
            }
            else if ((Re >= 3200) && (Re < 3400))
            {
                sh.angle = 0.6f;
                emission.rateOverTime = 1500;
            }
            else if ((Re >= 3400) && (Re < 3600))
            {
                sh.angle = 0.7f;
                emission.rateOverTime = 1400;
            }
            else if ((Re >= 3600) && (Re < 3800))
            {
                sh.angle = 0.8f;
                emission.rateOverTime = 1300;
            }
            else if ((Re >= 3800) && (Re < 4000))
            {
                sh.angle = 0.8f;
                emission.rateOverTime = 1200;
            }
            else if ((Re >= 4000) && (Re < 4600))
            {

                sh.radius = 0.01f;
                main.startLifetime = 0.25f;
                main.startSize = 0.013f;
                main.simulationSpeed = 0.4f;
                Color color = new Color32(243, 10, 10, 255);

                main.startColor = color;
                sh.radiusThickness = 0f;
                emission.rateOverTime = 4000;
                sh.angle = 0f;
                sh.arc = 300;


                sh.arcMode = ParticleSystemShapeMultiModeValue.Random;
                Gradient gradient = new Gradient();
                gradient.SetKeys(
                    new GradientColorKey[] { new GradientColorKey(new Color(255, 255, 255, 255), 0f),
                                         new GradientColorKey(new Color(255, 255, 255, 255), 1f),
                                            },
                    new GradientAlphaKey[] { new GradientAlphaKey(255f, 0.0f),
                                         new GradientAlphaKey(0f, 1.0f)
                                            }
                                );
                colorOverLifetime.color = new ParticleSystem.MinMaxGradient(gradient);
                AnimationCurve ourCurve;
                ourCurve = new AnimationCurve();
                ourCurve.AddKey(0.0f, 0.0f);
                ourCurve.AddKey(0.25f, 0.43f);
                ourCurve.AddKey(0.5f, 0.75f);
                ourCurve.AddKey(0.75f, 0.93f);
                ourCurve.AddKey(1.0f, 1.0f);
                sizeoverlifetime.size = new ParticleSystem.MinMaxCurve(1f, ourCurve);
                var rotationOverLifetime = particle.rotationOverLifetime;
                rotationOverLifetime.enabled = true;

            }
            else if ((Re >= 4600) && (Re < 5200))
            {
                main.startSize = 0.014f;
                emission.rateOverTime = 4000;
                main.simulationSpeed = 0.31f;
            }
            else if ((Re >= 5200) && (Re < 5800))
            {
                main.startSize = 0.015f;
                emission.rateOverTime = 4000;
                main.simulationSpeed = 0.32f;
            }
            else if ((Re >= 5800) && (Re < 6400))
            {
                main.startSize = 0.016f;
                emission.rateOverTime = 4000;
                main.simulationSpeed = 0.33f;
            }
            else if ((Re >= 6400) && (Re < 7000))
            {
                main.startSize = 0.017f;
                emission.rateOverTime = 3500;
                main.simulationSpeed = 0.34f;
            }
            else if ((Re >= 7000) && (Re < 7600))
            {
                main.startSize = 0.018f;
                emission.rateOverTime = 3500;
                main.simulationSpeed = 0.35f;
            }
            else if ((Re >= 7600) && (Re < 8200))
            {
                main.startSize = 0.019f;
                emission.rateOverTime = 3500;
                main.simulationSpeed = 0.36f;
            }
            else if ((Re >= 8200) && (Re < 8800))
            {
                main.startSize = 0.020f;
                emission.rateOverTime = 3500;
                main.simulationSpeed = 0.37f;
            }
            else if ((Re >= 8800) && (Re < 9400))
            {
                sh.radius = 0.01f;
                main.startSize = 0.021f;
                emission.rateOverTime = 3000;
                main.simulationSpeed = 0.38f;
            }
            else if ((Re >= 9400) && (Re < 10000))
            {
                emission.rateOverTime = 3000;
                main.startSize = 0.022f;
                sh.radius = 0.01f;
                main.simulationSpeed = 0.39f;
            }
            else if ((Re >= 10000) && (Re < 11000))
            {
                main.startLifetime = 0.235f;
                main.startSize = 0.035f;
                emission.rateOverTime = 400;
                Color color = new Color32(250, 0, 0, 230);
                main.startColor = color;
                sh.shapeType = ParticleSystemShapeType.Mesh;
                main.simulationSpeed = 10f;
                AnimationCurve ourCurve;
                ourCurve = new AnimationCurve();
                ourCurve.AddKey(0f, 1.0f);
                ourCurve.AddKey(1.0f, 1.0f);
                sizeoverlifetime.size = new ParticleSystem.MinMaxCurve(1f, ourCurve);
                Gradient gradient = new Gradient();
                gradient.SetKeys(
                    new GradientColorKey[] { new GradientColorKey(new Color(255, 255, 255, 255), 0f),
                                         new GradientColorKey(new Color(255, 255, 255, 255), 1f),
                                            },
                    new GradientAlphaKey[] { new GradientAlphaKey(255f, 0.0f),
                                         new GradientAlphaKey(255f, 1.0f)
                                            }
                                );
                colorOverLifetime.color = new ParticleSystem.MinMaxGradient(gradient);
            }
            else if ((Re >= 11000))
            {
                Color color = new Color32(255, 0, 0, 255);
                main.startColor = color;
            }

            flag = false;
        }
    }
        
}
