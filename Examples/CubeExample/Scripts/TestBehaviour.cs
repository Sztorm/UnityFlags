﻿using System;
using UnityEngine;
using Sztorm.Unity.Flags;
using Sztorm.Extensions.Enum;

public class TestBehaviour : MonoBehaviour
{
    [Flags]
    public enum ByteFlags : byte
    {
        None = 0,
        A = 1,
        B = 2,
        C = 4,
        D = 8,
        E = 16,
        F = 32,
        G = 64,
        H = 128,
        All = A | B | C | D | E | F | G | H,
    };

    [Flags]
    public enum SByteFlags : sbyte
    {
        None = 0,
        A = 1,
        B = 2,
        C = 4,
        D = 8,
        E = 16,
        F = 32,
        G = 64,
        H = -128,
        All = A | B | C | D | E | F | G | H,
    };

    [Header("SByteFlags")]
    [FlagTooltips(
        tooltip0: "This is A1.",
        tooltip1: "This is B1.",
        tooltip2: "This is C1.",
        tooltip3: "This is D1.",
        tooltip6: "This is G1.",
        tooltip7: "This is H1.")]
    [FlagFields(
        flagName0: "A1",
        flagName1: "B1",
        flagName2: "C1",
        flagName3: "D1",
        flagName6: "G1",
        flagName7: "H1")]
    [SerializeField]
    private SByteFlags sbyteFlags;

    [Header("ByteFlags")]
    [FlagFields(
        flagName0: "A2",
        flagName1: "B2",
        flagName4: "E2",
        flagName5: "F2",
        flagName6: "G2",
        flagName7: "H2")]
    [SerializeField]
    private ByteFlags byteFlags;

    [FlagFields(
        flagName0: "A3",
        flagName2: "C3",
        flagName4: "E3",
        flagName6: "G3")]
    [SerializeField]
    private ByteFlags flags;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Before toggling of 'private' bit fields");
            Debug.Log($"SByteFlags: {sbyteFlags} (E and F)");
            Debug.Log($"ByteFlags: {byteFlags} (C and D)");

            sbyteFlags = sbyteFlags.WithFlagsToggled(SByteFlags.E | SByteFlags.F);
            byteFlags = byteFlags.WithFlagsToggled(ByteFlags.C | ByteFlags.D);

            Debug.Log("After toggling of 'private' bit fields");
            Debug.Log($"SByteFlags: {sbyteFlags}");
            Debug.Log($"ByteFlags: {byteFlags}");
        }
    }
}
