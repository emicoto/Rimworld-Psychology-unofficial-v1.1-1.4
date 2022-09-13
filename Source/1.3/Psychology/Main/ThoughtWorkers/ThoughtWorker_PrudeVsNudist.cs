﻿using System;
public class ThoughtWorker_PrudeVsNudist : ThoughtWorker
    {
        if (p?.story?.traits?.HasTrait(TraitDefOfPsychology.Prude) != true)
        {
            return false;
        }
        if (other?.story?.traits?.HasTrait(TraitDefOf.Nudist) != true)
        {
            return false;
        }
        if (!RelationsUtility.PawnsKnowEachOther(p, other))
        {
            return false;
        }
        return true;
    }