#region Header
// //-----------------------------------------------------------------------
// // <copyright file="ScanActivity.cs" company="INVENTIO AG">
// //     Copyright � 2020 INVENTIO AG
// //     All rights reserved.
// //     INVENTIO AG, Seestrasse 55, CH-6052 Hergiswil, owns and retains all copyrights and other intellectual property rights in this
// //     document. Any reproduction, translation, copying or storing in data processing units in any form or by any means without prior
// //     permission of INVENTIO AG is regarded as infringement and will be prosecuted.
// //
// //     'CONFIDENTIAL'
// //     This document contains confidential information that is proprietary to the Schindler Group. Neither this document nor the
// //     information contained herein shall be disclosed to third parties nor used for manufacturing or any other application without
// //     written consent of INVENTIO AG.
// // </copyright>
// //-----------------------------------------------------------------------
#endregion

using Card.IO;

namespace Com.Verygoodsecurity.Api.Cardio
{
    public partial class ScanActivity
    {
        public const string ScanConfiguration = "vgs_scan_settings";
        public const string ExtraGuideColor = CardIOActivity.ExtraGuideColor;
        public const string ExtraLanguageOrLocale = CardIOActivity.ExtraLanguageOrLocale;
        public const string ExtraScanInstructions = CardIOActivity.ExtraScanInstructions;
    
        public const int CardNumber = 0x71;
        public const int CardCvc = 0x72;
        public const int CardHolder = 0x73;
        public const int CardExpDate = 0x74;
        public const int PostalCode = 0x75;
    }
}