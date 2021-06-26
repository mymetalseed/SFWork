using System.Collections;
using System.Collections.Generic;
using UnityChan.ImageEffects;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Solavrg/Image Effects/SolvargInkFade")]
public class Solvarg_InkFade : PostEffectsBase
{
    public Shader inkFadeShader;
    public Material inkFadeMaterial;

    public override bool CheckResources()
    {
        CheckSupport(true);
        return true;

    }

    [ImageEffectAllowedInSceneView]
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Debuger.LogError("在blit呢");
        if (CheckResources() == false)
        {
            Graphics.Blit(source, destination);
            return;
        }

        inkFadeMaterial.SetFloat("_Blend", fadeRate);
        Graphics.Blit(source, destination, inkFadeMaterial);
    }

}
