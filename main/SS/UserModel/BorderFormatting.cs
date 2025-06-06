/*
 *  ====================================================================
 *    Licensed to the Apache Software Foundation (ASF) under one or more
 *    contributor license agreements.  See the NOTICE file distributed with
 *    this work for Additional information regarding copyright ownership.
 *    The ASF licenses this file to You under the Apache License, Version 2.0
 *    (the "License"); you may not use this file except in compliance with
 *    the License.  You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 * ====================================================================
 */

namespace NPOI.SS.UserModel
{
    /// <summary>
    /// High level representation for Border Formatting component
    /// of Conditional Formatting settings
    /// </summary>
    public interface IBorderFormatting
    {
        BorderStyle BorderBottom { get; set; }

        BorderStyle BorderDiagonal { get; set; }

        BorderStyle BorderLeft { get; set; }

        BorderStyle BorderRight { get; set; }

        BorderStyle BorderTop { get; set; }

        /// <summary>
        /// Only valid for range borders, such as table styles
        /// </summary>
        BorderStyle BorderVertical { get; set; }
        /// <summary>
        /// Only valid for range borders, such as table styles
        /// </summary>
        BorderStyle BorderHorizontal { get; set; }
        short BottomBorderColor { get; set; }

        short DiagonalBorderColor { get; set; }

        short LeftBorderColor { get; set; }

        short RightBorderColor { get; set; }

        short TopBorderColor { get; set; }

        IColor BottomBorderColorColor { get; set; }

        IColor DiagonalBorderColorColor { get; set; }

        IColor LeftBorderColorColor { get; set; }

        IColor RightBorderColorColor { get; set; }
        IColor TopBorderColorColor { get; set; }
        /// <summary>
        /// Range internal borders. Only relevant for range styles, such as table formatting
        /// </summary>
        short VerticalBorderColor { get; set; }
        /// <summary>
        /// Range internal borders. Only relevant for range styles, such as table formatting
        /// </summary>
        IColor VerticalBorderColorColor { get; set; }

        /// <summary>
        /// Range internal borders. Only relevant for range styles, such as table formatting
        /// </summary>
        short HorizontalBorderColor { get; set; }
        /// <summary>
        /// Range internal borders. Only relevant for range styles, such as table formatting
        /// </summary>
        IColor HorizontalBorderColorColor {  get; set; }
    }
}