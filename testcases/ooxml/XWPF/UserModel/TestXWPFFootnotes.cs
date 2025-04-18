/* ====================================================================
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for Additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
==================================================================== */

namespace TestCases.XWPF.UserModel
{

    using NPOI.OpenXmlFormats.Wordprocessing;
    using NPOI.XWPF.UserModel;
    using NUnit.Framework;using NUnit.Framework.Legacy;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class TestXWPFFootnotes
    {
        [Test]
        public void TestCreateFootnotes()
        {
            XWPFDocument docOut = new XWPFDocument();
            XWPFFootnotes footnotes = docOut.CreateFootnotes();
            ClassicAssert.IsNotNull(footnotes);
            XWPFFootnotes secondFootnotes = docOut.CreateFootnotes();
            ClassicAssert.AreSame(footnotes, secondFootnotes);
            docOut.Close();
        }
        [Test]
        public void TestAddFootnotesToDocument()
        {
            XWPFDocument docOut = new XWPFDocument();

            // NOTE: XWPFDocument.createFootnote() delegates directly
            //       to XWPFFootnotes.createFootnote() so this tests
            //       both creation of new XWPFFootnotes in document
            //       and XWPFFootnotes.createFootnote();
            XWPFFootnote footnote = docOut.CreateFootnote();
            int noteId = footnote.Id;

            XWPFDocument docIn = XWPFTestDataSamples.WriteOutAndReadBack(docOut);

            XWPFFootnote note = docIn.GetFootnoteByID(noteId);
            ClassicAssert.IsNotNull(note);
            ClassicAssert.AreEqual(note.GetCTFtnEdn().type, ST_FtnEdn.normal);
        }

        /**
        * Bug 55066 - avoid double loading the footnotes
        */
        [Test]
        public void TestLoadFootnotesOnce()
        {
            XWPFDocument doc = XWPFTestDataSamples.OpenSampleDocument("Bug54849.docx");
            IList<XWPFFootnote> footnotes = doc.GetFootnotes();
            int hits = 0;
            foreach (XWPFFootnote fn in footnotes)
            {
                foreach (IBodyElement e in fn.BodyElements)
                {
                    if (e is XWPFParagraph)
                    {
                        String txt = ((XWPFParagraph)e).Text;
                        if (txt.IndexOf("Footnote_sdt") > -1)
                        {
                            hits++;
                        }
                    }
                }
            }
            ClassicAssert.AreEqual(1, hits, "Load footnotes once");
        }
    }

}
