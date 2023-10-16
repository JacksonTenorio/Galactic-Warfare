using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Observer
{
    public static Action<float> OnVidaPlayer;

    public static void AtualizaVidaPlayer(float vida)
    {
        OnVidaPlayer?.Invoke(vida);
    }

    public static Action<string> OnTextoDaVidaPlayer;

    public static void AtualizarTextoDaVidaPlayer(string textVidaPlayer)
    {
        OnTextoDaVidaPlayer?.Invoke(textVidaPlayer);
    }

    public static Action<int> OnPontosPlayer;

    public static void AtualizarPontuacao(int pontos)
    {
        OnPontosPlayer?.Invoke(pontos);
    }
}
