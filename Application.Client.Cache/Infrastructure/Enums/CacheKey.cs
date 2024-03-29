﻿using System.Runtime.Serialization;

namespace Application.Client.Cache.Infrastructure.Enums
{
    public enum CacheKey
    {
        [EnumMember(Value = "DOC_INFO")]
        DocInfo = 1,

        [EnumMember(Value = "COLOR_DIALOG_SETTINGS")]
        ColorDialogSettings = 2,

        [EnumMember(Value = "FONT_DIALOG_SETTINGS")]
        FontDialogSettings = 3,

        [EnumMember(Value = "FIND_NEXT_AND_REPLACE_CONDITIONS")]
        FindNextAndReplaceConditions = 4,
    }
}
