using System;
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
    [SerializeField]
    [FlagFields(
        flagName0: "A1",
        flagName1: "B1",
        flagName2: "C1",
        flagName3: "D1",
        flagName6: "G1",
        flagName7: "H1")]
    private SByteFlags sbyteFlags;

    [Header("ByteFlags")]
    [SerializeField]
    [FlagFields(
        flagName0: "A2",
        flagName1: "B2",
        flagName4: "E2",
        flagName5: "F2",
        flagName6: "G2",
        flagName7: "H2")]
    private ByteFlags byteFlags;

    [SerializeField]
    [FlagFields(
    flagName0: "A3",
    flagName2: "C3",
    flagName4: "E3",
    flagName6: "G3")]
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
