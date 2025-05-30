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

using NUnit.Framework;using NUnit.Framework.Legacy;
using NPOI.OpenXmlFormats.Wordprocessing;
using System;
using System.Collections.Generic;
using NPOI.XWPF.UserModel;

namespace TestCases.XWPF.UserModel
{
    [TestFixture]
    public class TestXWPFTableCell
    {
        [Test]
        public void TestSetGetVertAlignment()
        {
            // instantiate the following classes so they'll Get picked up by
            // the XmlBean process and Added to the jar file. they are required
            // for the following XWPFTableCell methods.
            CT_Shd ctShd = new CT_Shd();
            ClassicAssert.IsNotNull(ctShd);
            CT_VerticalJc ctVjc = new CT_VerticalJc();
            ClassicAssert.IsNotNull(ctVjc);
            ST_Shd stShd = ST_Shd.nil;
            ClassicAssert.IsNotNull(stShd);
            ST_VerticalJc stVjc = ST_VerticalJc.top;
            ClassicAssert.IsNotNull(stVjc);

            // create a table
            XWPFDocument doc = new XWPFDocument();
            CT_Tbl ctTable = new CT_Tbl();
            XWPFTable table = new XWPFTable(ctTable, doc);
            // table has a single row by default; grab it
            XWPFTableRow tr = table.GetRow(0);
            ClassicAssert.IsNotNull(tr);
            // row has a single cell by default; grab it
            XWPFTableCell cell = tr.GetCell(0);

            cell.SetVerticalAlignment(XWPFTableCell.XWPFVertAlign.BOTH);
            XWPFTableCell.XWPFVertAlign al = cell.GetVerticalAlignment().Value;
            ClassicAssert.AreEqual(XWPFTableCell.XWPFVertAlign.BOTH, al);
        }

        [Test]
        public void TestSetGetColor()
        {
            // create a table
            XWPFDocument doc = new XWPFDocument();
            CT_Tbl ctTable = new CT_Tbl();
            XWPFTable table = new XWPFTable(ctTable, doc);
            // table has a single row by default; grab it
            XWPFTableRow tr = table.GetRow(0);
            ClassicAssert.IsNotNull(tr);
            // row has a single cell by default; grab it
            XWPFTableCell cell = tr.GetCell(0);

            cell.SetColor("F0000F");
            String clr = cell.GetColor();
            ClassicAssert.AreEqual("F0000F", clr);
        }

        /**
         * ensure that CTHMerge and CTTcBorders go in poi-ooxml.jar
         */
        [Test]
        public void Test54099()
        {
            XWPFDocument doc = new XWPFDocument();
            CT_Tbl ctTable = new CT_Tbl();
            XWPFTable table = new XWPFTable(ctTable, doc);
            XWPFTableRow tr = table.GetRow(0);
            XWPFTableCell cell = tr.GetCell(0);

            CT_Tc ctTc = cell.GetCTTc();
            CT_TcPr tcPr = ctTc.AddNewTcPr();
            CT_HMerge hMerge = tcPr.AddNewHMerge();
            hMerge.val = (ST_Merge.restart);

            CT_TcBorders tblBorders = tcPr.AddNewTcBorders();
            CT_VMerge vMerge = tcPr.AddNewVMerge();
        }

        [Test]
        public void TestCellVerticalAlign()
        {
            XWPFDocument docx = XWPFTestDataSamples.OpenSampleDocument("59030.docx");
            IList<XWPFTable> tables = docx.Tables;
            ClassicAssert.AreEqual(1, tables.Count);
            XWPFTable table = tables[0];
            List<XWPFTableRow> tableRows = table.Rows;
            ClassicAssert.AreEqual(2, tableRows.Count);
            ClassicAssert.IsNull(tableRows[0].GetCell(0).GetVerticalAlignment());
            ClassicAssert.AreEqual(XWPFTableCell.XWPFVertAlign.BOTTOM, tableRows[0].GetCell(1).GetVerticalAlignment());
            ClassicAssert.AreEqual(XWPFTableCell.XWPFVertAlign.CENTER, tableRows[1].GetCell(0).GetVerticalAlignment());
            ClassicAssert.IsNull(tableRows[1].GetCell(1).GetVerticalAlignment()); // should return null since alignment isn't set
        }

        [Ignore("This is not a very useful test as written. It is not worth the execution time for a unit test")]
        [Test]
        public void TestCellVerticalAlignShouldNotThrowNPE()
        {
            XWPFDocument docx = XWPFTestDataSamples.OpenSampleDocument("TestTableCellAlign.docx");
            IList<XWPFTable> tables = docx.Tables;
            foreach (XWPFTable table in tables)
            {
                List<XWPFTableRow> tableRows = table.Rows;
                foreach (XWPFTableRow tableRow in tableRows)
                {
                    List<XWPFTableCell> tableCells = tableRow.GetTableCells();
                    foreach (XWPFTableCell tableCell in tableCells)
                    {
                        // getVerticalAlignment should return either an XWPFVertAlign enum or null if not set
                        tableCell.GetVerticalAlignment();
                    }
                }
            }
        }
    }
}
