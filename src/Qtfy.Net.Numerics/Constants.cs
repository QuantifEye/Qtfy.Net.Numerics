// <copyright file="Constants.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics
{
    /// <summary>
    /// A static class containing various mathematical constants.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The mathematical constant PI.
        /// </summary>
        public const double Pi = 3.14159265358979323846d;

        /// <summary>
        /// The mathematical constant Pi, multiplied by two.
        /// </summary>
        public const double TwoPi = Pi * 2d;

        public const double SqrtTwoPi =
            2.506628274631000502415765284811045253006986740609938316629923576342293654607841974946595838378057266;

        public const double SqrtTwo =
            1.4142135623730950488016887242096980785696718753769480731766797379907324784621;

        /// <summary>
        /// The natural logarithm of two.
        /// </summary>
        public const double LnTwo = 0.69314718055994530941723212145818;

        /// <summary>
        /// The natural logarithm of two multiplied by two.
        /// </summary>
        public const double TwoLnTwo = LnTwo * 2d;

        public const double OneOverSqrtTwoPi =
            3.989422804014326779399460599343818684758586311649346576659258296706579258993018385012523339073069364e-1;
    }
}
