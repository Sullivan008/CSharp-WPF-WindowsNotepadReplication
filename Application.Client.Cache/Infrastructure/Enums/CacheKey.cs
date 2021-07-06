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
        FontDialogSettings = 3
    }
}
