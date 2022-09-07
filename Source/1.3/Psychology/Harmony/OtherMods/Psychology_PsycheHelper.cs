﻿using UnityEngine;
public class Psychology_PsycheHelper_ManualPatches
    {
        if(!Pawnmorph.FormerHumanUtilities.IsHumanlike(pawn))
        {
            __result = false;
            return false;
        }
        if (PsychologySettings.speciesDict.ContainsKey(pawn.def.defName))
        {
            return true;
        }
        PsychologySettings.speciesDict.Add(pawn.def.defName, new SpeciesSettings());
        SpeciesHelper.RegisterPsycheEnabledDef(pawn.def);
        return true;
    }