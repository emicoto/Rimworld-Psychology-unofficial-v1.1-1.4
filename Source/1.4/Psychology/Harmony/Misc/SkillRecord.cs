﻿using System;

namespace Psychology.Harmony;
[HarmonyPatch(typeof(SkillRecord), nameof(SkillRecord.Learn))]
        {
            yield return codeList[i];
            if (i < 3)
            {
                continue;
            }
            bool bool0 = codeList[i - 3].LoadsField(levelInt);
            //bool bool1 = codeList[i - 2].opcode == OpCodes.Ldc_I4_1;
            bool bool2 = codeList[i - 1].opcode == OpCodes.Add || codeList[i - 1].opcode == OpCodes.Sub;
            bool bool3 = codeList[i - 0].StoresField(levelInt);
            if (bool0 && bool2 && bool3)
            {
                count++;
                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return CodeInstruction.LoadField(typeof(SkillRecord), "pawn");
                yield return CodeInstruction.Call(typeof(SkillRecord_Learn_Patch), nameof(SkillRecord_Learn_Patch.RecalcAdjustedRatings), new Type[] { typeof(Pawn) });
            }
        }
        if (count == 2)
        {
            Log.Message("Psychology: SkillRecord.Learn patch successful");
            yield break;
        }
        Log.Error("Psychology: SkillRecord.Learn patch unsuccessful");
    }

    public static void RecalcAdjustedRatings(Pawn pawn)
    {
        Log.Message("SkillRecord_Learn_Patch, AdjustRatings fired for pawn " + pawn);
        if (PsycheHelper.PsychologyEnabled(pawn) != true)
        {
            return;
        }
        PsycheHelper.Comp(pawn).Psyche.CalculateAdjustedRatings();
    }
}