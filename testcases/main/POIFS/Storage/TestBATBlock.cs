﻿/* ====================================================================
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

/* ================================================================
 * About NPOI
 * Author: Tony Qu 
 * Author's email: tonyqus (at) gmail.com 
 * Author's Blog: tonyqus.wordpress.com.cn (wp.tonyqus.cn)
 * HomePage: http://www.codeplex.com/npoi
 * Contributors:
 * 
 * ==============================================================*/
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

using NUnit.Framework;using NUnit.Framework.Legacy;

using NPOI.POIFS.Storage;
using NPOI.POIFS.Common;
using NPOI.Util;

namespace TestCases.POIFS.Storage
{
    /// <summary>
    /// Summary description for TestBATBlock
    /// </summary>
    [TestFixture]
    public class TestBATBlock
    {
        [Test]
        public void TestCreateBATBlocks()
        {

            // Test 0 Length array (basic sanity)
            BATBlock[] rvalue = BATBlock.CreateBATBlocks(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, CreateTestArray(0));

            ClassicAssert.AreEqual(0, rvalue.Length);

            // Test array of Length 1
            rvalue = BATBlock.CreateBATBlocks(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, CreateTestArray(1));
            ClassicAssert.AreEqual(1, rvalue.Length);
            VerifyContents(rvalue, 1);

            // Test array of Length 127
            rvalue = BATBlock.CreateBATBlocks(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, CreateTestArray(127));
            ClassicAssert.AreEqual(1, rvalue.Length);
            VerifyContents(rvalue, 127);

            // Test array of Length 128
            rvalue = BATBlock.CreateBATBlocks(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, CreateTestArray(128));
            ClassicAssert.AreEqual(1, rvalue.Length);
            VerifyContents(rvalue, 128);

            // Test array of Length 129
            rvalue = BATBlock.CreateBATBlocks(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, CreateTestArray(129));
            ClassicAssert.AreEqual(2, rvalue.Length);
            VerifyContents(rvalue, 129);
        }

        private int[] CreateTestArray(int count)
        {
            int[] rvalue = new int[count];

            for (int j = 0; j < count; j++)
            {
                rvalue[j] = j;
            }
            return rvalue;
        }

        private void VerifyContents(BATBlock[] blocks, int entries)
        {
            byte[] expected = new byte[512 * blocks.Length];
            for (int i = 0; i < expected.Length; i++)
            {
                expected[i] = (byte)0xFF;
            }
            int offset = 0;

            for (int j = 0; j < entries; j++)
            {
                expected[offset++] = (byte)j;
                expected[offset++] = 0;
                expected[offset++] = 0;
                expected[offset++] = 0;
            }
            MemoryStream stream = new MemoryStream(512
                                               * blocks.Length);

            for (int j = 0; j < blocks.Length; j++)
            {
                blocks[j].WriteBlocks(stream);
            }
            byte[] actual = stream.ToArray();

            ClassicAssert.AreEqual(expected.Length, actual.Length);
            for (int j = 0; j < expected.Length; j++)
            {
                ClassicAssert.AreEqual(expected[j], actual[j]);
            }
        }

        /**
         * Test CreateXBATBlocks
         *
         * @exception IOException
         */
        [Test]
        public void TestCreateXBATBlocks()
        {

            // Test 0 Length array (basic sanity)
            BATBlock[] rvalue = BATBlock.CreateXBATBlocks(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, CreateTestArray(0), 1);

            ClassicAssert.AreEqual(0, rvalue.Length);

            // Test array of Length 1
            rvalue = BATBlock.CreateXBATBlocks(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, CreateTestArray(1), 1);
            ClassicAssert.AreEqual(1, rvalue.Length);
            verifyXBATContents(rvalue, 1, 1);

            // Test array of Length 127
            rvalue = BATBlock.CreateXBATBlocks(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, CreateTestArray(127), 1);
            ClassicAssert.AreEqual(1, rvalue.Length);
            verifyXBATContents(rvalue, 127, 1);

            // Test array of Length 128
            rvalue = BATBlock.CreateXBATBlocks(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, CreateTestArray(128), 1);
            ClassicAssert.AreEqual(2, rvalue.Length);
            verifyXBATContents(rvalue, 128, 1);

            // Test array of Length 254
            rvalue = BATBlock.CreateXBATBlocks(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, CreateTestArray(254), 1);
            ClassicAssert.AreEqual(2, rvalue.Length);
            verifyXBATContents(rvalue, 254, 1);

            // Test array of Length 255
            rvalue = BATBlock.CreateXBATBlocks(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, CreateTestArray(255), 1);
            ClassicAssert.AreEqual(3, rvalue.Length);
            verifyXBATContents(rvalue, 255, 1);
        }

        private void verifyXBATContents(BATBlock[] blocks, int entries,
                                        int start_block)
        {
            byte[] expected = new byte[512 * blocks.Length];
            for (int i = 0; i < expected.Length; i++)
            {
                expected[i] = (byte)0xFF;
            }
            int offset = 0;

            for (int j = 0; j < entries; j++)
            {
                if ((j % 127) == 0)
                {
                    if (j != 0)
                    {
                        offset += 4;
                    }
                }
                expected[offset++] = (byte)j;
                expected[offset++] = 0;
                expected[offset++] = 0;
                expected[offset++] = 0;
            }
            for (int j = 0; j < (blocks.Length - 1); j++)
            {
                offset = 508 + (j * 512);
                expected[offset++] = (byte)(start_block + j + 1);
                expected[offset++] = 0;
                expected[offset++] = 0;
                expected[offset++] = 0;
            }
            offset = (blocks.Length * 512) - 4;
            expected[offset++] = unchecked((byte)-2);
            expected[offset++] = unchecked((byte)-1);
            expected[offset++] = unchecked((byte)-1);
            expected[offset++] = unchecked((byte)-1);
            MemoryStream stream = new MemoryStream(512
                                               * blocks.Length);

            for (int j = 0; j < blocks.Length; j++)
            {
                blocks[j].WriteBlocks(stream);
            }
            byte[] actual = stream.ToArray();

            ClassicAssert.AreEqual(expected.Length, actual.Length);
            for (int j = 0; j < expected.Length; j++)
            {
                ClassicAssert.AreEqual(expected[j], actual[j], "offset " + j);
            }
        }

        /**
         * Test calculateXBATStorageRequirements
         */
        [Test]
        public void TestCalculateXBATStorageRequirements()
        {
            int[] blockCounts =
            {
                0, 1, 127, 128
            };
            int[] requirements =
            {
                0, 1, 1, 2
            };

            for (int j = 0; j < blockCounts.Length; j++)
            {
                ClassicAssert.AreEqual(
                     requirements[j],
                    BATBlock.CalculateXBATStorageRequirements(blockCounts[j]),
                    "requirement for " + blockCounts[j]);
            }
        }

        /**
         * Test entriesPerBlock
         */
        [Test]
        public void TestEntriesPerBlock()
        {
            ClassicAssert.AreEqual(128, BATBlock.EntriesPerBlock);
        }

        /**
         * Test entriesPerXBATBlock
         */
        [Test]
        public void TestEntriesPerXBATBlock()
        {
            ClassicAssert.AreEqual(127, BATBlock.EntriesPerXBATBlock);
        }

        /**
         * Test getXBATChainOffset
         */
        [Test]
        public void TestGetXBATChainOffset()
        {
            ClassicAssert.AreEqual(508, BATBlock.XBATChainOffset);
        }
        [Test]
        public void TestCalculateMaximumSize()
        {
            // Zero fat blocks isn't technically valid, but it'd be header only
            ClassicAssert.AreEqual(
                  512,
                  BATBlock.CalculateMaximumSize(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, 0)
            );
            ClassicAssert.AreEqual(
                  4096,
                  BATBlock.CalculateMaximumSize(POIFSConstants.LARGER_BIG_BLOCK_SIZE_DETAILS, 0)
            );

            // A single FAT block can address 128/1024 blocks
            ClassicAssert.AreEqual(
                  512 + 512 * 128,
                  BATBlock.CalculateMaximumSize(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, 1)
            );
            ClassicAssert.AreEqual(
                  4096 + 4096 * 1024,
                  BATBlock.CalculateMaximumSize(POIFSConstants.LARGER_BIG_BLOCK_SIZE_DETAILS, 1)
            );

            ClassicAssert.AreEqual(
                  512 + 4 * 512 * 128,
                  BATBlock.CalculateMaximumSize(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, 4)
            );
            ClassicAssert.AreEqual(
                  4096 + 4 * 4096 * 1024,
                  BATBlock.CalculateMaximumSize(POIFSConstants.LARGER_BIG_BLOCK_SIZE_DETAILS, 4)
            );

            // One XBAT block holds 127/1023 individual BAT blocks, so they can address
            //  a fairly hefty amount of space themselves
            // However, the BATs continue as before
            ClassicAssert.AreEqual(
                  512 + 109 * 512 * 128,
                  BATBlock.CalculateMaximumSize(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, 109)
            );
            ClassicAssert.AreEqual(
                  4096 + 109 * 4096 * 1024,
                  BATBlock.CalculateMaximumSize(POIFSConstants.LARGER_BIG_BLOCK_SIZE_DETAILS, 109)
            );

            ClassicAssert.AreEqual(
                  512 + 110 * 512 * 128,
                  BATBlock.CalculateMaximumSize(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, 110)
            );
            ClassicAssert.AreEqual(
                  4096 + 110 * 4096 * 1024,
                  BATBlock.CalculateMaximumSize(POIFSConstants.LARGER_BIG_BLOCK_SIZE_DETAILS, 110)
            );

            ClassicAssert.AreEqual(
                  512 + 112 * 512 * 128,
                  BATBlock.CalculateMaximumSize(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, 112)
            );
            ClassicAssert.AreEqual(
                  4096 + 112 * 4096 * 1024,
                  BATBlock.CalculateMaximumSize(POIFSConstants.LARGER_BIG_BLOCK_SIZE_DETAILS, 112)
            );

            // Check for >2gb, which we only support via a File
            ClassicAssert.AreEqual(
                    512 + 8030L * 512 * 128,
                    BATBlock.CalculateMaximumSize(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS, 8030)
            );
            ClassicAssert.AreEqual(
                    4096 + 8030L * 4096 * 1024,
                    BATBlock.CalculateMaximumSize(POIFSConstants.LARGER_BIG_BLOCK_SIZE_DETAILS, 8030)
            );
        }

        [Test]
        public void TestUsedSectors()
        {
            POIFSBigBlockSize b512 = POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS;
            POIFSBigBlockSize b4096 = POIFSConstants.LARGER_BIG_BLOCK_SIZE_DETAILS;

            // Try first with 512 block sizes, which can hold 128 entries
            BATBlock block512 = BATBlock.CreateEmptyBATBlock(b512, false);
            ClassicAssert.AreEqual(true, block512.HasFreeSectors);
            ClassicAssert.AreEqual(0, block512.GetUsedSectors(false));
            // Allocate a few
            block512.SetValueAt(0, 42);
            block512.SetValueAt(10, 42);
            block512.SetValueAt(20, 42);
            ClassicAssert.AreEqual(true, block512.HasFreeSectors);
            ClassicAssert.AreEqual(3, block512.GetUsedSectors(false));

            // Allocate all
            for (int i = 0; i < b512.GetBATEntriesPerBlock(); i++) {
                block512.SetValueAt(i, 82);
            }
            // Check
            ClassicAssert.AreEqual(false, block512.HasFreeSectors);
            ClassicAssert.AreEqual(128, block512.GetUsedSectors(false));
            ClassicAssert.AreEqual(127, block512.GetUsedSectors(true));

            // Release one
            block512.SetValueAt(10, POIFSConstants.UNUSED_BLOCK);
            ClassicAssert.AreEqual(true, block512.HasFreeSectors);
            ClassicAssert.AreEqual(127, block512.GetUsedSectors(false));
            ClassicAssert.AreEqual(126, block512.GetUsedSectors(true));


            // Now repeat with 4096 block sizes
            BATBlock block4096 = BATBlock.CreateEmptyBATBlock(b4096, false);
            ClassicAssert.AreEqual(true, block4096.HasFreeSectors);
            ClassicAssert.AreEqual(0, block4096.GetUsedSectors(false));

            block4096.SetValueAt(0, 42);
            block4096.SetValueAt(10, 42);
            block4096.SetValueAt(20, 42);
            ClassicAssert.AreEqual(true, block4096.HasFreeSectors);
            ClassicAssert.AreEqual(3, block4096.GetUsedSectors(false));

            // Allocate all
            for (int i = 0; i < b4096.GetBATEntriesPerBlock(); i++) {
                block4096.SetValueAt(i, 82);
            }
            // Check
            ClassicAssert.AreEqual(false, block4096.HasFreeSectors);
            ClassicAssert.AreEqual(1024, block4096.GetUsedSectors(false));
            ClassicAssert.AreEqual(1023, block4096.GetUsedSectors(true));
        }
        [Test]
        public void TestGetBATBlockAndIndex()
        {
            HeaderBlock header = new HeaderBlock(POIFSConstants.SMALLER_BIG_BLOCK_SIZE_DETAILS);
            List<BATBlock> blocks = new List<BATBlock>();
            int offset;


            // First, try a one BAT block file
            header.BATCount = (1);
            blocks.Add(
                  BATBlock.CreateBATBlock(header.BigBlockSize, new ByteBuffer(512, 512))
            );

            offset = 0;
            ClassicAssert.AreEqual(0, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(0, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));

            offset = 1;
            ClassicAssert.AreEqual(1, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(0, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));

            offset = 127;
            ClassicAssert.AreEqual(127, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(0, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));


            // Now go for one with multiple BAT blocks
            header.BATCount = (2);
            blocks.Add(
                  BATBlock.CreateBATBlock(header.BigBlockSize, new ByteBuffer(512, 512))
            );

            offset = 0;
            ClassicAssert.AreEqual(0, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(0, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));

            offset = 127;
            ClassicAssert.AreEqual(127, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(0, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));

            offset = 128;
            ClassicAssert.AreEqual(0, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(1, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));

            offset = 129;
            ClassicAssert.AreEqual(1, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(1, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));


            // The XBAT count makes no difference, as we flatten in memory
            header.BATCount = (1);
            header.XBATCount = (1);
            offset = 0;
            ClassicAssert.AreEqual(0, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(0, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));

            offset = 126;
            ClassicAssert.AreEqual(126, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(0, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));

            offset = 127;
            ClassicAssert.AreEqual(127, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(0, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));

            offset = 128;
            ClassicAssert.AreEqual(0, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(1, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));

            offset = 129;
            ClassicAssert.AreEqual(1, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(1, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));


            // Check with the bigger block size too
            header = new HeaderBlock(POIFSConstants.LARGER_BIG_BLOCK_SIZE_DETAILS);

            offset = 0;
            ClassicAssert.AreEqual(0, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(0, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));

            offset = 1022;
            ClassicAssert.AreEqual(1022, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(0, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));

            offset = 1023;
            ClassicAssert.AreEqual(1023, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(0, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));

            offset = 1024;
            ClassicAssert.AreEqual(0, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(1, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));

            // Biggr block size, back to real BATs
            header.BATCount = (2);

            offset = 0;
            ClassicAssert.AreEqual(0, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(0, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));

            offset = 1022;
            ClassicAssert.AreEqual(1022, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(0, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));

            offset = 1023;
            ClassicAssert.AreEqual(1023, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(0, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));

            offset = 1024;
            ClassicAssert.AreEqual(0, BATBlock.GetBATBlockAndIndex(offset, header, blocks).Index);
            ClassicAssert.AreEqual(1, blocks.IndexOf(BATBlock.GetBATBlockAndIndex(offset, header, blocks).Block));
        }
    }
}
