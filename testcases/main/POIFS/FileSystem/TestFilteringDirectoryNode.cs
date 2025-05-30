﻿
/* ====================================================================
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.POIFS.FileSystem;
using NPOI.Util;
using NUnit.Framework;using NUnit.Framework.Legacy;
using System.IO;

namespace TestCases.POIFS.FileSystem
{
    [TestFixture]
    public class TestFilteringDirectoryNode
    {
        private POIFSFileSystem fs;
        private DirectoryEntry dirA;
        private DirectoryEntry dirAA;
        private DirectoryEntry dirB;
        private DocumentEntry eRoot;
        private DocumentEntry eA;
        private DocumentEntry eAA;
        [SetUp]
        protected void setUp()
        {
            fs = new POIFSFileSystem();
            dirA = fs.CreateDirectory("DirA");
            dirB = fs.CreateDirectory("DirB");
            dirAA = dirA.CreateDirectory("DirAA");
            eRoot = fs.Root.CreateDocument("Root", new ByteArrayInputStream(new byte[] { }));
            eA = dirA.CreateDocument("NA", new ByteArrayInputStream(new byte[] { }));
            eAA = dirAA.CreateDocument("NAA", new ByteArrayInputStream(new byte[] { }));
        }
        [Test]
        public void TestNoFiltering()
        {
            FilteringDirectoryNode d = new FilteringDirectoryNode(fs.Root, new HashSet<String>());
            ClassicAssert.AreEqual(3, d.EntryCount);
            ClassicAssert.AreEqual(dirA.Name, d.GetEntry(dirA.Name).Name);

            ClassicAssert.AreEqual(true, d.GetEntry(dirA.Name).IsDirectoryEntry);
            ClassicAssert.AreEqual(false, d.GetEntry(dirA.Name).IsDocumentEntry);

            ClassicAssert.AreEqual(true, d.GetEntry(dirB.Name).IsDirectoryEntry);
            ClassicAssert.AreEqual(false, d.GetEntry(dirB.Name).IsDocumentEntry);

            ClassicAssert.AreEqual(false, d.GetEntry(eRoot.Name).IsDirectoryEntry);
            ClassicAssert.AreEqual(true, d.GetEntry(eRoot.Name).IsDocumentEntry);

            IEnumerator<Entry> i = d.Entries;
            i.MoveNext();
            ClassicAssert.AreEqual(dirA, i.Current);
            i.MoveNext();
            ClassicAssert.AreEqual(dirB, i.Current);
            i.MoveNext();
            ClassicAssert.AreEqual(eRoot, i.Current);
            i.MoveNext();
            ClassicAssert.AreEqual(null, i.Current);
        }
        [Test]
        public void TestChildFiltering()
        {
            List<String> excl = new List<string>(new String[] { "NotThere", "AlsoNotThere", eRoot.Name });
            FilteringDirectoryNode d = new FilteringDirectoryNode(fs.Root, excl);

            ClassicAssert.AreEqual(2, d.EntryCount);
            ClassicAssert.AreEqual(true, d.HasEntry(dirA.Name));
            ClassicAssert.AreEqual(true, d.HasEntry(dirB.Name));
            ClassicAssert.AreEqual(false, d.HasEntry(eRoot.Name));

            ClassicAssert.AreEqual(dirA, d.GetEntry(dirA.Name));
            ClassicAssert.AreEqual(dirB, d.GetEntry(dirB.Name));
            try
            {
                d.GetEntry(eRoot.Name);
                Assert.Fail("Should be filtered");
            }
            catch (FileNotFoundException) { }

            IEnumerator<Entry> i = d.Entries;
            i.MoveNext();
            ClassicAssert.AreEqual(dirA, i.Current);
            i.MoveNext();
            ClassicAssert.AreEqual(dirB, i.Current);
            i.MoveNext();
            ClassicAssert.AreEqual(null, i.Current);


            // Filter more
            excl = new List<string>(new String[] { "NotThere", "AlsoNotThere", eRoot.Name, dirA.Name });
            d = new FilteringDirectoryNode(fs.Root, excl);

            ClassicAssert.AreEqual(1, d.EntryCount);
            ClassicAssert.AreEqual(false, d.HasEntry(dirA.Name));
            ClassicAssert.AreEqual(true, d.HasEntry(dirB.Name));
            ClassicAssert.AreEqual(false, d.HasEntry(eRoot.Name));

            try
            {
                d.GetEntry(dirA.Name);
                Assert.Fail("Should be filtered");
            }
            catch (FileNotFoundException) { }
            ClassicAssert.AreEqual(dirB, d.GetEntry(dirB.Name));
            try
            {
                d.GetEntry(eRoot.Name);
                Assert.Fail("Should be filtered");
            }
            catch (FileNotFoundException) { }

            i = d.Entries;
            i.MoveNext();
            ClassicAssert.AreEqual(dirB, i.Current);
            i.MoveNext();
            ClassicAssert.AreEqual(null, i.Current);


            // Filter everything
            excl = new List<string>(new String[] { "NotThere", eRoot.Name, dirA.Name, dirB.Name });
            d = new FilteringDirectoryNode(fs.Root, excl);

            ClassicAssert.AreEqual(0, d.EntryCount);
            ClassicAssert.AreEqual(false, d.HasEntry(dirA.Name));
            ClassicAssert.AreEqual(false, d.HasEntry(dirB.Name));
            ClassicAssert.AreEqual(false, d.HasEntry(eRoot.Name));

            try
            {
                d.GetEntry(dirA.Name);
                Assert.Fail("Should be filtered");
            }
            catch (FileNotFoundException) { }
            try
            {
                d.GetEntry(dirB.Name);
                Assert.Fail("Should be filtered");
            }
            catch (FileNotFoundException) { }
            try
            {
                d.GetEntry(eRoot.Name);
                Assert.Fail("Should be filtered");
            }
            catch (FileNotFoundException) { }

            i = d.Entries;
            i.MoveNext();
            ClassicAssert.AreEqual(null, i.Current);
        }
        [Test]
        public void TestNestedFiltering()
        {
            List<String> excl = new List<string>(new String[] {
             dirA.Name+"/"+"MadeUp",
             dirA.Name+"/"+eA.Name,
             dirA.Name+"/"+dirAA.Name+"/Test",
             eRoot.Name
       });
            FilteringDirectoryNode d = new FilteringDirectoryNode(fs.Root, excl);

            // Check main
            ClassicAssert.AreEqual(2, d.EntryCount);
            ClassicAssert.AreEqual(true, d.HasEntry(dirA.Name));
            ClassicAssert.AreEqual(true, d.HasEntry(dirB.Name));
            ClassicAssert.AreEqual(false, d.HasEntry(eRoot.Name));

            // Check filtering down
            ClassicAssert.AreEqual(true, d.GetEntry(dirA.Name) is FilteringDirectoryNode);
            ClassicAssert.AreEqual(false, d.GetEntry(dirB.Name) is FilteringDirectoryNode);

            DirectoryEntry fdA = (DirectoryEntry)d.GetEntry(dirA.Name);
            ClassicAssert.AreEqual(false, fdA.HasEntry(eA.Name));
            ClassicAssert.AreEqual(true, fdA.HasEntry(dirAA.Name));

            DirectoryEntry fdAA = (DirectoryEntry)fdA.GetEntry(dirAA.Name);
            ClassicAssert.AreEqual(true, fdAA.HasEntry(eAA.Name));
        }
    }
}
