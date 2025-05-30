﻿
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using NPOI.OpenXmlFormats.Shared;
using System.Xml.Schema;
using System.IO;
using NPOI.OpenXml4Net.Util;
using System.Collections;

namespace NPOI.OpenXmlFormats.Wordprocessing
{

    [Serializable]
    [XmlType(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main")]
    public class CT_HdrFtr
    {

        private ArrayList itemsField;

        private List<ItemsChoiceType8> itemsElementNameField;

        public CT_HdrFtr()
        {
            this.itemsElementNameField = new List<ItemsChoiceType8>();
            this.itemsField = new ArrayList();
        }
        public static CT_HdrFtr Parse(CT_HdrFtr ctObj,XmlNode node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.LocalName == "customXmlInsRangeStart")
                {
                    ctObj.Items.Add(CT_TrackChange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.customXmlInsRangeStart);
                }
                else if (childNode.LocalName == "customXmlMoveFromRangeStart")
                {
                    ctObj.Items.Add(CT_TrackChange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.customXmlMoveFromRangeStart);
                }
                else if (childNode.LocalName == "customXmlMoveToRangeEnd")
                {
                    ctObj.Items.Add(CT_Markup.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.customXmlMoveToRangeEnd);
                }
                else if (childNode.LocalName == "customXmlMoveToRangeStart")
                {
                    ctObj.Items.Add(CT_TrackChange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.customXmlMoveToRangeStart);
                }
                else if (childNode.LocalName == "del")
                {
                    ctObj.Items.Add(CT_RunTrackChange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.del);
                }
                else if (childNode.LocalName == "ins")
                {
                    ctObj.Items.Add(CT_RunTrackChange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.ins);
                }
                else if (childNode.LocalName == "moveFrom")
                {
                    ctObj.Items.Add(CT_RunTrackChange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.moveFrom);
                }
                else if (childNode.LocalName == "moveFromRangeEnd")
                {
                    ctObj.Items.Add(CT_MarkupRange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.moveFromRangeEnd);
                }
                else if (childNode.LocalName == "moveFromRangeStart")
                {
                    ctObj.Items.Add(CT_MoveBookmark.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.moveFromRangeStart);
                }
                else if (childNode.LocalName == "moveTo")
                {
                    ctObj.Items.Add(CT_RunTrackChange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.moveTo);
                }
                else if (childNode.LocalName == "moveToRangeEnd")
                {
                    ctObj.Items.Add(CT_MarkupRange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.moveToRangeEnd);
                }
                else if (childNode.LocalName == "moveToRangeStart")
                {
                    ctObj.Items.Add(CT_MoveBookmark.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.moveToRangeStart);
                }
                else if (childNode.LocalName == "p")
                {
                    ctObj.Items.Add(CT_P.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.p);
                }
                else if (childNode.LocalName == "permEnd")
                {
                    ctObj.Items.Add(CT_Perm.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.permEnd);
                }
                else if (childNode.LocalName == "permStart")
                {
                    ctObj.Items.Add(CT_PermStart.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.permStart);
                }
                else if (childNode.LocalName == "proofErr")
                {
                    ctObj.Items.Add(CT_ProofErr.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.proofErr);
                }
                else if (childNode.LocalName == "sdt")
                {
                    ctObj.Items.Add(CT_SdtBlock.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.sdt);
                }
                else if (childNode.LocalName == "tbl")
                {
                    ctObj.Items.Add(CT_Tbl.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.tbl);
                }
                else if (childNode.LocalName == "customXmlMoveFromRangeEnd")
                {
                    ctObj.Items.Add(CT_Markup.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.customXmlMoveFromRangeEnd);
                }
                else if (childNode.LocalName == "oMath")
                {
                    ctObj.Items.Add(CT_OMath.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.oMath);
                }
                else if (childNode.LocalName == "oMathPara")
                {
                    ctObj.Items.Add(CT_OMathPara.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.oMathPara);
                }
                else if (childNode.LocalName == "altChunk")
                {
                    ctObj.Items.Add(CT_AltChunk.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.altChunk);
                }
                else if (childNode.LocalName == "bookmarkEnd")
                {
                    ctObj.Items.Add(CT_MarkupRange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.bookmarkEnd);
                }
                else if (childNode.LocalName == "bookmarkStart")
                {
                    ctObj.Items.Add(CT_Bookmark.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.bookmarkStart);
                }
                else if (childNode.LocalName == "commentRangeEnd")
                {
                    ctObj.Items.Add(CT_MarkupRange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.commentRangeEnd);
                }
                else if (childNode.LocalName == "commentRangeStart")
                {
                    ctObj.Items.Add(CT_MarkupRange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.commentRangeStart);
                }
                else if (childNode.LocalName == "customXml")
                {
                    ctObj.Items.Add(CT_CustomXmlBlock.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.customXml);
                }
                else if (childNode.LocalName == "customXmlDelRangeEnd")
                {
                    ctObj.Items.Add(CT_Markup.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.customXmlDelRangeEnd);
                }
                else if (childNode.LocalName == "customXmlDelRangeStart")
                {
                    ctObj.Items.Add(CT_TrackChange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.customXmlDelRangeStart);
                }
                else if (childNode.LocalName == "customXmlInsRangeEnd")
                {
                    ctObj.Items.Add(CT_Markup.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType8.customXmlInsRangeEnd);
                }
            }
            return ctObj;
        }

        internal void Write(StreamWriter sw, string nodeName)
        {
            sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            sw.Write(string.Format("<w:{0} ", nodeName));
            sw.Write("xmlns:wpc=\"http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas\" xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\" ");
            sw.Write("xmlns:cx=\"http://schemas.microsoft.com/office/drawing/2014/chartex\" xmlns:cx1=\"http://schemas.microsoft.com/office/drawing/2015/9/8/chartex\" xmlns:cx2=\"http://schemas.microsoft.com/office/drawing/2015/10/21/chartex\" xmlns:cx3=\"http://schemas.microsoft.com/office/drawing/2016/5/9/chartex\" xmlns:cx4=\"http://schemas.microsoft.com/office/drawing/2016/5/10/chartex\" xmlns:cx5=\"http://schemas.microsoft.com/office/drawing/2016/5/11/chartex\" xmlns:cx6=\"http://schemas.microsoft.com/office/drawing/2016/5/12/chartex\" xmlns:cx7=\"http://schemas.microsoft.com/office/drawing/2016/5/13/chartex\" xmlns:cx8=\"http://schemas.microsoft.com/office/drawing/2016/5/14/chartex\" ");
            sw.Write("xmlns:aink=\"http://schemas.microsoft.com/office/drawing/2016/ink\" xmlns:am3d=\"http://schemas.microsoft.com/office/drawing/2017/model3d\" ");
            //sw.Write("xmlns:ve=\"http://schemas.openxmlformats.org/markup-compatibility/2006\" ");
            sw.Write("xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:oel=\"http://schemas.microsoft.com/office/2019/extlst\" ");
            sw.Write("xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\" ");
            sw.Write("xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:wp14=\"http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing\" xmlns:wp=\"http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing\" ");
            sw.Write("xmlns:w10=\"urn:schemas-microsoft-com:office:word\" xmlns:w=\"http://schemas.openxmlformats.org/wordprocessingml/2006/main\" ");
            sw.Write("xmlns:w14=\"http://schemas.microsoft.com/office/word/2010/wordml\" xmlns:w15=\"http://schemas.microsoft.com/office/word/2012/wordml\" ");
            sw.Write("xmlns:w16cex=\"http://schemas.microsoft.com/office/word/2018/wordml/cex\" xmlns:w16cid=\"http://schemas.microsoft.com/office/word/2016/wordml/cid\" xmlns:w16=\"http://schemas.microsoft.com/office/word/2018/wordml\" xmlns:w16du=\"http://schemas.microsoft.com/office/word/2023/wordml/word16du\" xmlns:w16sdtdh=\"http://schemas.microsoft.com/office/word/2020/wordml/sdtdatahash\" xmlns:w16se=\"http://schemas.microsoft.com/office/word/2015/wordml/symex\" ");
            sw.Write("xmlns:wpg=\"http://schemas.microsoft.com/office/word/2010/wordprocessingGroup\" xmlns:wpi=\"http://schemas.microsoft.com/office/word/2010/wordprocessingInk\" xmlns:wne=\"http://schemas.microsoft.com/office/word/2006/wordml\" xmlns:wps=\"http://schemas.microsoft.com/office/word/2010/wordprocessingShape\" ");
            sw.Write("mc:Ignorable=\"w14 w15 w16se w16cid w16 w16cex w16sdtdh wp14\">");
            foreach (object o in this.Items)
            {
                if (o is CT_TrackChange change)
                    change.Write(sw, "customXmlInsRangeStart");
                else if (o is CT_TrackChange trackChange)
                    trackChange.Write(sw, "customXmlMoveFromRangeStart");
                else if (o is CT_Markup markup)
                    markup.Write(sw, "customXmlMoveToRangeEnd");
                else if (o is CT_TrackChange ctTrackChange)
                    ctTrackChange.Write(sw, "customXmlMoveToRangeStart");
                else if (o is CT_RunTrackChange runTrackChange)
                    runTrackChange.Write(sw, "del");
                else if (o is CT_RunTrackChange ctRunTrackChange)
                    ctRunTrackChange.Write(sw, "ins");
                else if (o is CT_RunTrackChange change1)
                    change1.Write(sw, "moveFrom");
                else if (o is CT_MarkupRange range)
                    range.Write(sw, "moveFromRangeEnd");
                else if (o is CT_MoveBookmark bookmark)
                    bookmark.Write(sw, "moveFromRangeStart");
                else if (o is CT_RunTrackChange trackChange1)
                    trackChange1.Write(sw, "moveTo");
                else if (o is CT_MarkupRange markupRange)
                    markupRange.Write(sw, "moveToRangeEnd");
                else if (o is CT_MoveBookmark moveBookmark)
                    moveBookmark.Write(sw, "moveToRangeStart");
                else if (o is CT_P p)
                    p.Write(sw, "p");
                else if (o is CT_Perm perm)
                    perm.Write(sw, "permEnd");
                else if (o is CT_PermStart start)
                    start.Write(sw, "permStart");
                else if (o is CT_ProofErr err)
                    err.Write(sw, "proofErr");
                else if (o is CT_SdtBlock block)
                    block.Write(sw, "sdt");
                else if (o is CT_Tbl tbl)
                    tbl.Write(sw, "tbl");
                else if (o is CT_Markup ctMarkup)
                    ctMarkup.Write(sw, "customXmlMoveFromRangeEnd");
                else if (o is CT_OMath math)
                    math.Write(sw, "oMath");
                else if (o is CT_OMathPara para)
                    para.Write(sw, "oMathPara");
                else if (o is CT_AltChunk chunk)
                    chunk.Write(sw, "altChunk");
                else if (o is CT_MarkupRange ctMarkupRange)
                    ctMarkupRange.Write(sw, "bookmarkEnd");
                else if (o is CT_Bookmark ctBookmark)
                    ctBookmark.Write(sw, "bookmarkStart");
                else if (o is CT_MarkupRange range1)
                    range1.Write(sw, "commentRangeEnd");
                else if (o is CT_MarkupRange markupRange1)
                    markupRange1.Write(sw, "commentRangeStart");
                else if (o is CT_CustomXmlBlock xmlBlock)
                    xmlBlock.Write(sw, "customXml");
                else if (o is CT_Markup markup1)
                    markup1.Write(sw, "customXmlDelRangeEnd");
                else if (o is CT_TrackChange ctTrackChange1)
                    ctTrackChange1.Write(sw, "customXmlDelRangeStart");
                else if (o is CT_Markup ctMarkup1)
                    ctMarkup1.Write(sw, "customXmlInsRangeEnd");
            }
            sw.WriteEndW(nodeName);
        }

        public ArrayList Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField =value;
            }
        }

        [XmlElement("ItemsElementName", Order = 1)]
        [XmlIgnore]
        public List<ItemsChoiceType8> ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                    this.itemsElementNameField = value;
            }
        }

        public CT_Tbl GetTblArray(int i)
        {
            return GetObjectArray<CT_Tbl>(i, ItemsChoiceType8.tbl);
        }

        public IList<CT_Tbl> GetTblList()
        {
            return GetObjectList<CT_Tbl>(ItemsChoiceType8.tbl);
        }

        public CT_P AddNewP()
        {
            return AddNewObject<CT_P>(ItemsChoiceType8.p);
        }

        public CT_Tbl AddNewTbl()
        {
            return AddNewObject<CT_Tbl>(ItemsChoiceType8.tbl);
        }

        public void SetPArray(int i, CT_P cT_P)
        {
            SetObject<CT_P>(ItemsChoiceType8.p, i, cT_P);
        }
        #region Generic methods for object operation

        private List<T> GetObjectList<T>(ItemsChoiceType8 type) where T : class
        {
            lock (this)
            {
                List<T> list = new List<T>();
                for (int i = 0; i < itemsElementNameField.Count; i++)
                {
                    if (itemsElementNameField[i] == type)
                        list.Add(itemsField[i] as T);
                }
                return list;
            }
        }
        private int SizeOfArray(ItemsChoiceType8 type)
        {
            lock (this)
            {
                int size = 0;
                for (int i = 0; i < itemsElementNameField.Count; i++)
                {
                    if (itemsElementNameField[i] == type)
                        size++;
                }
                return size;
            }
        }
        private T GetObjectArray<T>(int p, ItemsChoiceType8 type) where T : class
        {
            lock (this)
            {
                int pos = GetObjectIndex(type, p);
                if (pos < 0 || pos >= this.itemsField.Count)
                    return null;
                return itemsField[pos] as T;
            }
        }
        private T AddNewObject<T>(ItemsChoiceType8 type) where T : class, new()
        {
            T t = new T();
            lock (this)
            {
                this.itemsElementNameField.Add(type);
                this.itemsField.Add(t);
            }
            return t;
        }
        private void SetObject<T>(ItemsChoiceType8 type, int p, T obj) where T : class
        {
            lock (this)
            {
                int pos = GetObjectIndex(type, p);
                if (pos < 0 || pos >= this.itemsField.Count)
                    return;
                if (this.itemsField[pos] is T)
                    this.itemsField[pos] = obj;
                else
                    throw new Exception(string.Format(@"object types are difference, itemsField[{0}] is {1}, and parameter obj is {2}",
                        pos, this.itemsField[pos].GetType().Name, typeof(T).Name));
            }
        }
        private int GetObjectIndex(ItemsChoiceType8 type, int p)
        {
            int index = -1;
            int pos = 0;
            for (int i = 0; i < itemsElementNameField.Count; i++)
            {
                if (itemsElementNameField[i] == type)
                {
                    if (pos == p)
                    {
                        //return itemsField[p] as T;
                        index = i;
                        break;
                    }
                    else
                        pos++;
                }
            }
            return index;
        }
        private void RemoveObject(ItemsChoiceType8 type, int p)
        {
            lock (this)
            {
                int pos = GetObjectIndex(type, p);
                if (pos < 0 || pos >= this.itemsField.Count)
                    return;
                itemsElementNameField.RemoveAt(pos);
                itemsField.RemoveAt(pos);
            }
        }
        #endregion

    }
    [XmlRoot("ftr", Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main", IsNullable = false)]
    public class CT_Ftr : CT_HdrFtr
    {
        public static CT_Ftr Parse(XmlNode node, XmlNamespaceManager namespaceManager)
        {
            CT_Ftr ctObj= new CT_Ftr();
            return (CT_Ftr)CT_HdrFtr.Parse(ctObj, node, namespaceManager);
        }
        internal void Write(StreamWriter sw)
        {
            base.Write(sw, "ftr");
        }
    }
    [XmlRoot("hdr", Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main", IsNullable = false)]
    public class CT_Hdr : CT_HdrFtr
    {
        public static CT_Hdr Parse(XmlNode node, XmlNamespaceManager namespaceManager)
        {
            CT_Hdr ctObj = new CT_Hdr();
            return (CT_Hdr)CT_HdrFtr.Parse(ctObj, node, namespaceManager);
        }
        internal void Write(StreamWriter sw)
        {
            base.Write(sw, "hdr");
        }
    }
    [Serializable]
    [XmlType(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main", IncludeInSchema = false)]
    public enum ItemsChoiceType8
    {


        [XmlEnum("http://schemas.openxmlformats.org/officeDocument/2006/math:oMath")]
        oMath,


        [XmlEnum("http://schemas.openxmlformats.org/officeDocument/2006/math:oMathPara")]
        oMathPara,


        altChunk,


        bookmarkEnd,


        bookmarkStart,


        commentRangeEnd,


        commentRangeStart,


        customXml,


        customXmlDelRangeEnd,


        customXmlDelRangeStart,


        customXmlInsRangeEnd,


        customXmlInsRangeStart,


        customXmlMoveFromRangeEnd,


        customXmlMoveFromRangeStart,


        customXmlMoveToRangeEnd,


        customXmlMoveToRangeStart,


        del,


        ins,


        moveFrom,


        moveFromRangeEnd,


        moveFromRangeStart,


        moveTo,


        moveToRangeEnd,


        moveToRangeStart,


        p,


        permEnd,


        permStart,


        proofErr,


        sdt,


        tbl,
    }

    [Serializable]

    [XmlType(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main")]
    [XmlRoot(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main", IsNullable = true)]
    public class CT_HdrFtrRef : CT_Rel
    {
        public static new CT_HdrFtrRef Parse(XmlNode node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_HdrFtrRef ctObj = new CT_HdrFtrRef();
            if (node.Attributes["w:type"] != null)
            {
                try
                {
                    ctObj.type = (ST_HdrFtr)Enum.Parse(typeof(ST_HdrFtr), node.Attributes["w:type"].Value);
                }
                catch (ArgumentException)
                {
                    ctObj.type = ST_HdrFtr.@default;
                }
            }
            ctObj.id = XmlHelper.ReadString(node.Attributes["r:id"]);
            return ctObj;
        }



        internal new void Write(StreamWriter sw, string nodeName)
        {
            sw.Write(string.Format("<w:{0}", nodeName));
            XmlHelper.WriteAttribute(sw, "w:type", this.type.ToString());
            XmlHelper.WriteAttribute(sw, "r:id", this.id);
            sw.Write("/>");
        }

        private ST_HdrFtr typeField;

        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public ST_HdrFtr type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }


    [Serializable]
    [XmlType(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main")]
    public enum ST_HdrFtr
    {


        [XmlEnum("even")]
        even,

        [XmlEnum("default")]
        @default,

        [XmlEnum("first")]
        first,
    }


    [XmlInclude(typeof(CT_FtnDocProps))]

    [Serializable]

    [XmlType(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main")]
    [XmlRoot(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main", IsNullable = true)]
    public class CT_FtnProps
    {

        private CT_FtnPos posField;

        private CT_NumFmt numFmtField;

        private CT_DecimalNumber numStartField;

        private CT_NumRestart numRestartField;

        public CT_FtnProps()
        {
            //this.numRestartField = new CT_NumRestart();
            //this.numStartField = new CT_DecimalNumber();
            //this.numFmtField = new CT_NumFmt();
            //this.posField = new CT_FtnPos();
        }
        public static CT_FtnProps Parse(XmlNode node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_FtnProps ctObj = new CT_FtnProps();
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.LocalName == "pos")
                    ctObj.pos = CT_FtnPos.Parse(childNode, namespaceManager);
                else if (childNode.LocalName == "numFmt")
                    ctObj.numFmt = CT_NumFmt.Parse(childNode, namespaceManager);
                else if (childNode.LocalName == "numStart")
                    ctObj.numStart = CT_DecimalNumber.Parse(childNode, namespaceManager);
                else if (childNode.LocalName == "numRestart")
                    ctObj.numRestart = CT_NumRestart.Parse(childNode, namespaceManager);
            }
            return ctObj;
        }



        internal void Write(StreamWriter sw, string nodeName)
        {
            sw.Write(string.Format("<w:{0}", nodeName));
            sw.Write(">");
            if (this.pos != null)
                this.pos.Write(sw, "pos");
            if (this.numFmt != null)
                this.numFmt.Write(sw, "numFmt");
            if (this.numStart != null)
                this.numStart.Write(sw, "numStart");
            if (this.numRestart != null)
                this.numRestart.Write(sw, "numRestart");
            sw.WriteEndW(nodeName);
        }

        [XmlElement(Order = 0)]
        public CT_FtnPos pos
        {
            get
            {
                return this.posField;
            }
            set
            {
                this.posField = value;
            }
        }

        [XmlElement(Order = 1)]
        public CT_NumFmt numFmt
        {
            get
            {
                return this.numFmtField;
            }
            set
            {
                this.numFmtField = value;
            }
        }

        [XmlElement(Order = 2)]
        public CT_DecimalNumber numStart
        {
            get
            {
                return this.numStartField;
            }
            set
            {
                this.numStartField = value;
            }
        }

        [XmlElement(Order = 3)]
        public CT_NumRestart numRestart
        {
            get
            {
                return this.numRestartField;
            }
            set
            {
                this.numRestartField = value;
            }
        }
    }


    [Serializable]

    [XmlType(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main")]
    [XmlRoot(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main", IsNullable = true)]
    public class CT_FtnPos
    {
        public static CT_FtnPos Parse(XmlNode node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_FtnPos ctObj = new CT_FtnPos();
            if (node.Attributes["w:val"] != null)
                ctObj.val = (ST_FtnPos)Enum.Parse(typeof(ST_FtnPos), node.Attributes["w:val"].Value);
            return ctObj;
        }



        internal void Write(StreamWriter sw, string nodeName)
        {
            sw.Write(string.Format("<w:{0}", nodeName));
            XmlHelper.WriteAttribute(sw, "w:val", this.val.ToString());
            sw.Write(">");
            sw.WriteEndW(nodeName);
        }

        private ST_FtnPos valField;

        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public ST_FtnPos val
        {
            get
            {
                return this.valField;
            }
            set
            {
                this.valField = value;
            }
        }
    }


    [Serializable]
    [XmlType(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main")]
    public enum ST_FtnPos
    {


        pageBottom,


        beneathText,


        sectEnd,


        docEnd,
    }

    public class CT_Footnotes
    {

        private List<CT_FtnEdn> footnoteField;

        public CT_Footnotes()
        {
            //this.footnoteField = new List<CT_FtnEdn>();
        }
        public static CT_Footnotes Parse(XmlNode node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_Footnotes ctObj = new CT_Footnotes();
            ctObj.footnote = new List<CT_FtnEdn>();
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.LocalName == "footnote")
                    ctObj.footnote.Add(CT_FtnEdn.Parse(childNode, namespaceManager));
            }
            return ctObj;
        }

        internal void Write(StreamWriter sw)
        {
            sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            sw.Write("<w:footnotes xmlns:wpc=\"http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas\" xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\" ");
            //sw.Write("xmlns:ve=\"http://schemas.openxmlformats.org/markup-compatibility/2006\" ");
            sw.Write("xmlns:o=\"urn:schemas-microsoft-com:office:office\" ");
            sw.Write("xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\" ");
            sw.Write("xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:wp14=\"http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing\" ");
            sw.Write("xmlns:wp=\"http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing\" xmlns:w=\"http://schemas.openxmlformats.org/wordprocessingml/2006/main\" ");
            sw.Write("xmlns:w14=\"http://schemas.microsoft.com/office/word/2010/wordml\" xmlns:w15=\"http://schemas.microsoft.com/office/word/2012/wordml\" xmlns:w10=\"urn:schemas-microsoft-com:office:word\" ");
            sw.Write("xmlns:wpg=\"http://schemas.microsoft.com/office/word/2010/wordprocessingGroup\" xmlns:wpi=\"http://schemas.microsoft.com/office/word/2010/wordprocessingInk\" ");
            sw.Write("xmlns:wne=\"http://schemas.microsoft.com/office/word/2006/wordml\" xmlns:wps=\"http://schemas.microsoft.com/office/word/2010/wordprocessingShape\" ");
            sw.Write("mc:Ignorable=\"w14 w15 wp14\">");
            if (this.footnote != null)
            {
                foreach (CT_FtnEdn x in this.footnote)
                {
                    x.Write(sw, "footnote");
                }
            }
            sw.Write("</w:footnotes>");
        }

        [XmlElement("footnote", Order = 0)]
        public List<CT_FtnEdn> footnote
        {
            get
            {
                return this.footnoteField;
            }
            set
            {
                this.footnoteField = value;
            }
        }
        public CT_FtnEdn AddNewFootnote()
        {
            CT_FtnEdn f = new CT_FtnEdn();
            if (footnoteField == null)
                footnoteField = new List<CT_FtnEdn>();
            footnoteField.Add(f);
            return f;
        }
        public void RemoveFootnote(int pos)
        {
            this.footnoteField.RemoveAt(pos);
        }
        public int SizeOfFootnoteArray
        {
            get
            {
                return this.footnoteField.Count;
            }
        }
    }


    [Serializable]
    [XmlType(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main")]
    [XmlRoot("endnote", Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main", IsNullable = true)]
    public class CT_FtnEdn
    {

        private ArrayList itemsField = new ArrayList();

        private List<ItemsChoiceType7> itemsElementNameField = new List<ItemsChoiceType7>();

        private ST_FtnEdn typeField;

        private bool typeFieldSpecified;

        private int idField = -1;

        public static CT_FtnEdn Parse(XmlNode node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_FtnEdn ctObj = new CT_FtnEdn();
            if (node.Attributes["w:type"] != null)
                ctObj.type = (ST_FtnEdn)Enum.Parse(typeof(ST_FtnEdn), node.Attributes["w:type"].Value);
            ctObj.id = XmlHelper.ReadInt(node.Attributes["w:id"]);

            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.LocalName == "customXmlDelRangeStart")
                {
                    ctObj.Items.Add(CT_TrackChange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.customXmlDelRangeStart);
                }
                else if (childNode.LocalName == "moveToRangeEnd")
                {
                    ctObj.Items.Add(CT_MarkupRange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.moveToRangeEnd);
                }
                else if (childNode.LocalName == "customXmlMoveFromRangeEnd")
                {
                    ctObj.Items.Add(CT_Markup.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.customXmlMoveFromRangeEnd);
                }
                else if (childNode.LocalName == "ins")
                {
                    ctObj.Items.Add(CT_RunTrackChange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.ins);
                }
                else if (childNode.LocalName == "customXmlDelRangeEnd")
                {
                    ctObj.Items.Add(CT_Markup.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.customXmlDelRangeEnd);
                }
                else if (childNode.LocalName == "customXmlInsRangeEnd")
                {
                    ctObj.Items.Add(CT_Markup.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.customXmlInsRangeEnd);
                }
                else if (childNode.LocalName == "customXmlInsRangeStart")
                {
                    ctObj.Items.Add(CT_TrackChange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.customXmlInsRangeStart);
                }
                else if (childNode.LocalName == "moveTo")
                {
                    ctObj.Items.Add(CT_RunTrackChange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.moveTo);
                }
                else if (childNode.LocalName == "moveToRangeStart")
                {
                    ctObj.Items.Add(CT_MoveBookmark.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.moveToRangeStart);
                }
                else if (childNode.LocalName == "customXmlMoveFromRangeStart")
                {
                    ctObj.Items.Add(CT_TrackChange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.customXmlMoveFromRangeStart);
                }
                else if (childNode.LocalName == "customXmlMoveToRangeEnd")
                {
                    ctObj.Items.Add(CT_Markup.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.customXmlMoveToRangeEnd);
                }
                else if (childNode.LocalName == "customXmlMoveToRangeStart")
                {
                    ctObj.Items.Add(CT_TrackChange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.customXmlMoveToRangeStart);
                }
                else if (childNode.LocalName == "del")
                {
                    ctObj.Items.Add(CT_RunTrackChange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.del);
                }
                else if (childNode.LocalName == "p")
                {
                    ctObj.Items.Add(CT_P.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.p);
                }
                else if (childNode.LocalName == "permEnd")
                {
                    ctObj.Items.Add(CT_Perm.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.permEnd);
                }
                else if (childNode.LocalName == "permStart")
                {
                    ctObj.Items.Add(CT_PermStart.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.permStart);
                }
                else if (childNode.LocalName == "proofErr")
                {
                    ctObj.Items.Add(CT_ProofErr.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.proofErr);
                }
                else if (childNode.LocalName == "sdt")
                {
                    ctObj.Items.Add(CT_SdtBlock.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.sdt);
                }
                else if (childNode.LocalName == "moveFrom")
                {
                    ctObj.Items.Add(CT_RunTrackChange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.moveFrom);
                }
                else if (childNode.LocalName == "moveFromRangeEnd")
                {
                    ctObj.Items.Add(CT_MarkupRange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.moveFromRangeEnd);
                }
                else if (childNode.LocalName == "tbl")
                {
                    ctObj.Items.Add(CT_Tbl.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.tbl);
                }
                else if (childNode.LocalName == "moveFromRangeStart")
                {
                    ctObj.Items.Add(CT_MoveBookmark.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.moveFromRangeStart);
                }
                else if (childNode.LocalName == "oMath")
                {
                    ctObj.Items.Add(CT_OMath.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.oMath);
                }
                else if (childNode.LocalName == "oMathPara")
                {
                    ctObj.Items.Add(CT_OMathPara.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.oMathPara);
                }
                else if (childNode.LocalName == "altChunk")
                {
                    ctObj.Items.Add(CT_AltChunk.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.altChunk);
                }
                else if (childNode.LocalName == "bookmarkEnd")
                {
                    ctObj.Items.Add(CT_MarkupRange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.bookmarkEnd);
                }
                else if (childNode.LocalName == "bookmarkStart")
                {
                    ctObj.Items.Add(CT_Bookmark.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.bookmarkStart);
                }
                else if (childNode.LocalName == "commentRangeEnd")
                {
                    ctObj.Items.Add(CT_MarkupRange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.commentRangeEnd);
                }
                else if (childNode.LocalName == "commentRangeStart")
                {
                    ctObj.Items.Add(CT_MarkupRange.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.commentRangeStart);
                }
                else if (childNode.LocalName == "customXml")
                {
                    ctObj.Items.Add(CT_CustomXmlBlock.Parse(childNode, namespaceManager));
                    ctObj.ItemsElementName.Add(ItemsChoiceType7.customXml);
                }
            }
            return ctObj;
        }

        internal void Write(StreamWriter sw, string nodeName)
        {
            sw.Write(string.Format("<w:{0}", nodeName));
            XmlHelper.WriteAttribute(sw, "w:type", this.type.ToString());
            XmlHelper.WriteAttribute(sw, "w:id", this.id, true);
            sw.Write(">");
            int i = 0;
            foreach (object o in this.Items)
            {
                if (o is CT_TrackChange change&& this.itemsElementNameField[i]== ItemsChoiceType7.customXmlDelRangeStart)
                    change.Write(sw, "customXmlDelRangeStart");
                else if (o is CT_MarkupRange range && this.itemsElementNameField[i] == ItemsChoiceType7.moveToRangeEnd)
                    range.Write(sw, "moveToRangeEnd");
                else if (o is CT_Markup markup && this.itemsElementNameField[i] == ItemsChoiceType7.customXmlMoveFromRangeEnd)
                    markup.Write(sw, "customXmlMoveFromRangeEnd");
                else if (o is CT_RunTrackChange trackChange && this.itemsElementNameField[i] == ItemsChoiceType7.ins)
                    trackChange.Write(sw, "ins");
                else if (o is CT_Markup ctMarkup && this.itemsElementNameField[i] == ItemsChoiceType7.customXmlDelRangeEnd)
                    ctMarkup.Write(sw, "customXmlDelRangeEnd");
                else if (o is CT_Markup markup1 && this.itemsElementNameField[i] == ItemsChoiceType7.customXmlInsRangeEnd)
                    markup1.Write(sw, "customXmlInsRangeEnd");
                else if (o is CT_TrackChange ctTrackChange && this.itemsElementNameField[i] == ItemsChoiceType7.customXmlInsRangeStart)
                    ctTrackChange.Write(sw, "customXmlInsRangeStart");
                else if (o is CT_RunTrackChange runTrackChange && this.itemsElementNameField[i] == ItemsChoiceType7.moveTo)
                    runTrackChange.Write(sw, "moveTo");
                else if (o is CT_MoveBookmark bookmark && this.itemsElementNameField[i] == ItemsChoiceType7.moveToRangeStart)
                    bookmark.Write(sw, "moveToRangeStart");
                else if (o is CT_TrackChange change1 && this.itemsElementNameField[i] == ItemsChoiceType7.customXmlMoveFromRangeStart)
                    change1.Write(sw, "customXmlMoveFromRangeStart");
                else if (o is CT_Markup ctMarkup1 && this.itemsElementNameField[i] == ItemsChoiceType7.customXmlMoveToRangeEnd)
                    ctMarkup1.Write(sw, "customXmlMoveToRangeEnd");
                else if (o is CT_TrackChange trackChange1 && this.itemsElementNameField[i] == ItemsChoiceType7.customXmlMoveToRangeStart)
                    trackChange1.Write(sw, "customXmlMoveToRangeStart");
                else if (o is CT_RunTrackChange ctRunTrackChange && this.itemsElementNameField[i] == ItemsChoiceType7.del)
                    ctRunTrackChange.Write(sw, "del");
                else if (o is CT_P p)
                    p.Write(sw, "p");
                else if (o is CT_Perm perm)
                    perm.Write(sw, "permEnd");
                else if (o is CT_PermStart start)
                    start.Write(sw, "permStart");
                else if (o is CT_ProofErr err)
                    err.Write(sw, "proofErr");
                else if (o is CT_SdtBlock block)
                    block.Write(sw, "sdt");
                else if (o is CT_RunTrackChange runTrackChange1 && this.itemsElementNameField[i] == ItemsChoiceType7.moveFrom)
                    runTrackChange1.Write(sw, "moveFrom");
                else if (o is CT_MarkupRange markupRange && this.itemsElementNameField[i] == ItemsChoiceType7.moveFromRangeEnd)
                    markupRange.Write(sw, "moveFromRangeEnd");
                else if (o is CT_Tbl tbl)
                    tbl.Write(sw, "tbl");
                else if (o is CT_MoveBookmark moveBookmark && this.itemsElementNameField[i] == ItemsChoiceType7.moveFromRangeStart)
                    moveBookmark.Write(sw, "moveFromRangeStart");
                else if (o is CT_OMath math)
                    math.Write(sw, "oMath");
                else if (o is CT_OMathPara para)
                    para.Write(sw, "oMathPara");
                else if (o is CT_AltChunk chunk)
                    chunk.Write(sw, "altChunk");
                else if (o is CT_MarkupRange ctMarkupRange && this.itemsElementNameField[i] == ItemsChoiceType7.bookmarkEnd)
                    ctMarkupRange.Write(sw, "bookmarkEnd");
                else if (o is CT_Bookmark ctBookmark && this.itemsElementNameField[i] == ItemsChoiceType7.bookmarkStart)
                    ctBookmark.Write(sw, "bookmarkStart");
                else if (o is CT_MarkupRange range1 && this.itemsElementNameField[i] == ItemsChoiceType7.commentRangeEnd)
                    range1.Write(sw, "commentRangeEnd");
                else if (o is CT_MarkupRange markupRange1 && this.itemsElementNameField[i] == ItemsChoiceType7.commentRangeStart)
                    markupRange1.Write(sw, "commentRangeStart");
                else if (o is CT_CustomXmlBlock xmlBlock)
                    xmlBlock.Write(sw, "customXml");
                i++;
            }
            sw.WriteEndW(nodeName);
        }


        [XmlElement("oMath", typeof(CT_OMath), Namespace = "http://schemas.openxmlformats.org/officeDocument/2006/math", Order = 0)]
        [XmlElement("oMathPara", typeof(CT_OMathPara), Namespace = "http://schemas.openxmlformats.org/officeDocument/2006/math", Order = 0)]
        [XmlElement("altChunk", typeof(CT_AltChunk), Order = 0)]
        [XmlElement("bookmarkEnd", typeof(CT_MarkupRange), Order = 0)]
        [XmlElement("bookmarkStart", typeof(CT_Bookmark), Order = 0)]
        [XmlElement("commentRangeEnd", typeof(CT_MarkupRange), Order = 0)]
        [XmlElement("commentRangeStart", typeof(CT_MarkupRange), Order = 0)]
        [XmlElement("customXml", typeof(CT_CustomXmlBlock), Order = 0)]
        [XmlElement("customXmlDelRangeEnd", typeof(CT_Markup), Order = 0)]
        [XmlElement("customXmlDelRangeStart", typeof(CT_TrackChange), Order = 0)]
        [XmlElement("customXmlInsRangeEnd", typeof(CT_Markup), Order = 0)]
        [XmlElement("customXmlInsRangeStart", typeof(CT_TrackChange), Order = 0)]
        [XmlElement("customXmlMoveFromRangeEnd", typeof(CT_Markup), Order = 0)]
        [XmlElement("customXmlMoveFromRangeStart", typeof(CT_TrackChange), Order = 0)]
        [XmlElement("customXmlMoveToRangeEnd", typeof(CT_Markup), Order = 0)]
        [XmlElement("customXmlMoveToRangeStart", typeof(CT_TrackChange), Order = 0)]
        [XmlElement("del", typeof(CT_RunTrackChange), Order = 0)]
        [XmlElement("ins", typeof(CT_RunTrackChange), Order = 0)]
        [XmlElement("moveFrom", typeof(CT_RunTrackChange), Order = 0)]
        [XmlElement("moveFromRangeEnd", typeof(CT_MarkupRange), Order = 0)]
        [XmlElement("moveFromRangeStart", typeof(CT_MoveBookmark), Order = 0)]
        [XmlElement("moveTo", typeof(CT_RunTrackChange), Order = 0)]
        [XmlElement("moveToRangeEnd", typeof(CT_MarkupRange), Order = 0)]
        [XmlElement("moveToRangeStart", typeof(CT_MoveBookmark), Order = 0)]
        [XmlElement("p", typeof(CT_P), Order = 0)]
        [XmlElement("permEnd", typeof(CT_Perm), Order = 0)]
        [XmlElement("permStart", typeof(CT_PermStart), Order = 0)]
        [XmlElement("proofErr", typeof(CT_ProofErr), Order = 0)]
        [XmlElement("sdt", typeof(CT_SdtBlock), Order = 0)]
        [XmlElement("tbl", typeof(CT_Tbl), Order = 0)]
        [XmlChoiceIdentifier("ItemsElementName")]
        public ArrayList Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        [XmlElement("ItemsElementName", Order = 1)]
        [XmlIgnore]
        public List<ItemsChoiceType7> ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
               this.itemsElementNameField = value;
            }
        }

        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public ST_FtnEdn type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        [XmlIgnore]
        public bool typeSpecified
        {
            get
            {
                return this.typeFieldSpecified;
            }
            set
            {
                this.typeFieldSpecified = value;
            }
        }

        [XmlAttribute(Form = XmlSchemaForm.Qualified, DataType = "integer", Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main")]
        public int id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        public void Set(CT_FtnEdn note)
        {
            this.idField = note.idField;
            this.itemsElementNameField = note.itemsElementNameField;
            this.itemsField = note.itemsField;
            this.typeField = note.typeField;
        }
        private List<T> GetObjectList<T>(ItemsChoiceType7 type) where T : class
        {
            lock (this)
            {
                List<T> list = new List<T>();
                for (int i = 0; i < itemsElementNameField.Count; i++)
                {
                    if (itemsElementNameField[i] == type)
                        list.Add(itemsField[i] as T);
                }
                return list;
            }
        }
        private int SizeOfArray(ItemsChoiceType7 type)
        {
            lock (this)
            {
                int size = 0;
                for (int i = 0; i < itemsElementNameField.Count; i++)
                {
                    if (itemsElementNameField[i] == type)
                        size++;
                }
                return size;
            }
        }
        private T GetObjectArray<T>(int p, ItemsChoiceType7 type) where T : class
        {
            lock (this)
            {
                int pos = 0;
                for (int i = 0; i < itemsElementNameField.Count; i++)
                {
                    if (itemsElementNameField[i] == type)
                    {
                        if (pos == p)
                            return itemsField[i] as T;
                        else
                            pos++;
                    }
                }
                return null;
            }
        }
        private T AddNewObject<T>(ItemsChoiceType7 type) where T : class, new()
        {
            T t = new T();
            lock (this)
            {
                this.itemsElementNameField.Add(type);
                this.itemsField.Add(t);
            }
            return t;
        }
        private T AddNewObject<T>(ItemsChoiceType7 type, T t) where T : class, new()
        {
            lock (this)
            {
                this.itemsElementNameField.Add(type);
                this.itemsField.Add(t);
            }
            return t;
        }
        public IList<CT_P> GetPList()
        {
            return GetObjectList<CT_P>(ItemsChoiceType7.p);
        }

        public IList<CT_Tbl> GetTblList()
        {
            return GetObjectList<CT_Tbl>(ItemsChoiceType7.tbl);
        }

        public CT_Tbl GetTblArray(int i)
        {
            return GetObjectArray<CT_Tbl>(i, ItemsChoiceType7.tbl);
        }

        public CT_Tbl AddNewTbl()
        {
            return AddNewObject<CT_Tbl>(ItemsChoiceType7.tbl);
        }

        public CT_P AddNewP()
        {
            return AddNewObject<CT_P>(ItemsChoiceType7.p);
        }

        public CT_P AddNewP(CT_P paragraph)
        {
            return AddNewObject<CT_P>(ItemsChoiceType7.p, paragraph);
        }
    }


    [Serializable]
    [XmlType(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main", IncludeInSchema = false)]
    public enum ItemsChoiceType7
    {


        [XmlEnum("http://schemas.openxmlformats.org/officeDocument/2006/math:oMath")]
        oMath,


        [XmlEnum("http://schemas.openxmlformats.org/officeDocument/2006/math:oMathPara")]
        oMathPara,


        altChunk,


        bookmarkEnd,


        bookmarkStart,


        commentRangeEnd,


        commentRangeStart,


        customXml,


        customXmlDelRangeEnd,


        customXmlDelRangeStart,


        customXmlInsRangeEnd,


        customXmlInsRangeStart,


        customXmlMoveFromRangeEnd,


        customXmlMoveFromRangeStart,


        customXmlMoveToRangeEnd,


        customXmlMoveToRangeStart,


        del,


        ins,


        moveFrom,


        moveFromRangeEnd,


        moveFromRangeStart,


        moveTo,


        moveToRangeEnd,


        moveToRangeStart,


        p,


        permEnd,


        permStart,


        proofErr,


        sdt,


        tbl,
    }


    [Serializable]
    [XmlType(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main")]
    public enum ST_FtnEdn
    {


        normal,


        separator,


        continuationSeparator,


        continuationNotice,
    }


    public class CT_Endnotes
    {

        private List<CT_FtnEdn> endnoteField = new List<CT_FtnEdn>();
        public static CT_Endnotes Parse(XmlNode node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_Endnotes ctObj = new CT_Endnotes();
            ctObj.endnote = new List<CT_FtnEdn>();
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.LocalName == "endnote")
                    ctObj.endnote.Add(CT_FtnEdn.Parse(childNode, namespaceManager));
            }
            return ctObj;
        }

        internal void Write(StreamWriter sw)
        {
            sw.Write("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            sw.Write("<w:endnotes xmlns:ve=\"http://schemas.openxmlformats.org/markup-compatibility/2006\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" ");
            sw.Write("xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\" xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\" ");
            sw.Write("xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:wp=\"http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing\" ");
            sw.Write("xmlns:w10=\"urn:schemas-microsoft-com:office:word\" xmlns:w=\"http://schemas.openxmlformats.org/wordprocessingml/2006/main\" ");
            sw.Write("xmlns:wne=\"http://schemas.microsoft.com/office/word/2006/wordml\">");
            if (this.endnote != null)
            {
                foreach (CT_FtnEdn x in this.endnote)
                {
                    x.Write(sw, "endnote");
                }
            }
            sw.Write("</w:endnotes>");
        }

        [XmlElement("endnote", Order = 0)]
        public List<CT_FtnEdn> endnote
        {
            get
            {
                return this.endnoteField;
            }
            set
            {
                this.endnoteField = value;
            }
        }
    }

    [Serializable]

    [XmlType(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main")]
    [XmlRoot(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main", IsNullable = true)]
    public class CT_FtnDocProps : CT_FtnProps
    {

        private List<CT_FtnEdnSepRef> footnoteField;

        public CT_FtnDocProps()
        {
            //this.footnoteField = new List<CT_FtnEdnSepRef>();
        }
        public static new CT_FtnDocProps Parse(XmlNode node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_FtnDocProps ctObj = new CT_FtnDocProps();
            ctObj.footnote = new List<CT_FtnEdnSepRef>();
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.LocalName == "pos")
                    ctObj.pos = CT_FtnPos.Parse(childNode, namespaceManager);
                else if (childNode.LocalName == "numFmt")
                    ctObj.numFmt = CT_NumFmt.Parse(childNode, namespaceManager);
                else if (childNode.LocalName == "numStart")
                    ctObj.numStart = CT_DecimalNumber.Parse(childNode, namespaceManager);
                else if (childNode.LocalName == "numRestart")
                    ctObj.numRestart = CT_NumRestart.Parse(childNode, namespaceManager);
                else if (childNode.LocalName == "footnote")
                    ctObj.footnote.Add(CT_FtnEdnSepRef.Parse(childNode, namespaceManager));
            }
            return ctObj;
        }



        internal new void Write(StreamWriter sw, string nodeName)
        {
            sw.Write(string.Format("<w:{0}", nodeName));
            sw.Write(">");
            if (this.pos != null)
                this.pos.Write(sw, "pos");
            if (this.numFmt != null)
                this.numFmt.Write(sw, "numFmt");
            if (this.numStart != null)
                this.numStart.Write(sw, "numStart");
            if (this.numRestart != null)
                this.numRestart.Write(sw, "numRestart");
            if (this.footnote != null)
            {
                foreach (CT_FtnEdnSepRef x in this.footnote)
                {
                    x.Write(sw, "footnote");
                }
            }
            sw.WriteEndW(nodeName);
        }

        [XmlElement("footnote", Order = 0)]
        public List<CT_FtnEdnSepRef> footnote
        {
            get
            {
                return this.footnoteField;
            }
            set
            {
                this.footnoteField = value;
            }
        }
    }


    [Serializable]
    [XmlType(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main")]
    public class CT_FtnEdnSepRef
    {
        private string idField;
        public static CT_FtnEdnSepRef Parse(XmlNode node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_FtnEdnSepRef ctObj = new CT_FtnEdnSepRef();
            ctObj.id = XmlHelper.ReadString(node.Attributes["w:id"]);
            return ctObj;
        }



        internal void Write(StreamWriter sw, string nodeName)
        {
            sw.Write(string.Format("<w:{0}", nodeName));
            XmlHelper.WriteAttribute(sw, "w:id", this.id);
            sw.Write("/>");
        }

        //[XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, DataType = "integer")]
        [XmlAttribute(DataType = "integer")]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    [XmlInclude(typeof(CT_EdnDocProps))]

    [Serializable]

    [XmlType(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main")]
    public class CT_EdnProps
    {

        private CT_EdnPos posField;

        private CT_NumFmt numFmtField;

        private CT_DecimalNumber numStartField;

        private CT_NumRestart numRestartField;

        public CT_EdnProps()
        {
            //this.numRestartField = new CT_NumRestart();
            //this.numStartField = new CT_DecimalNumber();
            //this.numFmtField = new CT_NumFmt();
            //this.posField = new CT_EdnPos();
        }
        public static CT_EdnProps Parse(XmlNode node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_EdnProps ctObj = new CT_EdnProps();
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.LocalName == "pos")
                    ctObj.pos = CT_EdnPos.Parse(childNode, namespaceManager);
                else if (childNode.LocalName == "numFmt")
                    ctObj.numFmt = CT_NumFmt.Parse(childNode, namespaceManager);
                else if (childNode.LocalName == "numStart")
                    ctObj.numStart = CT_DecimalNumber.Parse(childNode, namespaceManager);
                else if (childNode.LocalName == "numRestart")
                    ctObj.numRestart = CT_NumRestart.Parse(childNode, namespaceManager);
            }
            return ctObj;
        }



        internal void Write(StreamWriter sw, string nodeName)
        {
            sw.Write(string.Format("<w:{0}", nodeName));
            sw.Write(">");
            if (this.pos != null)
                this.pos.Write(sw, "pos");
            if (this.numFmt != null)
                this.numFmt.Write(sw, "numFmt");
            if (this.numStart != null)
                this.numStart.Write(sw, "numStart");
            if (this.numRestart != null)
                this.numRestart.Write(sw, "numRestart");
            sw.WriteEndW(nodeName);
        }

        [XmlElement(Order = 0)]
        public CT_EdnPos pos
        {
            get
            {
                return this.posField;
            }
            set
            {
                this.posField = value;
            }
        }

        [XmlElement(Order = 1)]
        public CT_NumFmt numFmt
        {
            get
            {
                return this.numFmtField;
            }
            set
            {
                this.numFmtField = value;
            }
        }

        [XmlElement(Order = 2)]
        public CT_DecimalNumber numStart
        {
            get
            {
                return this.numStartField;
            }
            set
            {
                this.numStartField = value;
            }
        }

        [XmlElement(Order = 3)]
        public CT_NumRestart numRestart
        {
            get
            {
                return this.numRestartField;
            }
            set
            {
                this.numRestartField = value;
            }
        }
    }


    [Serializable]

    [XmlType(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main")]
    [XmlRoot(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main", IsNullable = true)]
    public class CT_EdnPos
    {
        public static CT_EdnPos Parse(XmlNode node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_EdnPos ctObj = new CT_EdnPos();
            if (node.Attributes["w:val"] != null)
                ctObj.val = (ST_EdnPos)Enum.Parse(typeof(ST_EdnPos), node.Attributes["w:val"].Value);
            return ctObj;
        }



        internal void Write(StreamWriter sw, string nodeName)
        {
            sw.Write(string.Format("<w:{0}", nodeName));
            XmlHelper.WriteAttribute(sw, "w:val", this.val.ToString());
            sw.Write(">");
            sw.WriteEndW(nodeName);
        }

        private ST_EdnPos valField;

        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public ST_EdnPos val
        {
            get
            {
                return this.valField;
            }
            set
            {
                this.valField = value;
            }
        }
    }


    [Serializable]
    [XmlType(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main")]
    public enum ST_EdnPos
    {


        sectEnd,


        docEnd,
    }


    [Serializable]

    [XmlType(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main")]
    [XmlRoot(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main", IsNullable = true)]
    public class CT_EdnDocProps : CT_EdnProps
    {
        public new static CT_EdnDocProps Parse(XmlNode node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_EdnDocProps ctObj = new CT_EdnDocProps();
            ctObj.endnote = new List<CT_FtnEdnSepRef>();
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.LocalName == "pos")
                    ctObj.pos = CT_EdnPos.Parse(childNode, namespaceManager);
                else if (childNode.LocalName == "numFmt")
                    ctObj.numFmt = CT_NumFmt.Parse(childNode, namespaceManager);
                else if (childNode.LocalName == "numStart")
                    ctObj.numStart = CT_DecimalNumber.Parse(childNode, namespaceManager);
                else if (childNode.LocalName == "numRestart")
                    ctObj.numRestart = CT_NumRestart.Parse(childNode, namespaceManager);
                else if (childNode.LocalName == "endnote")
                    ctObj.endnote.Add(CT_FtnEdnSepRef.Parse(childNode, namespaceManager));
            }
            return ctObj;
        }



        internal new void Write(StreamWriter sw, string nodeName)
        {
            sw.Write(string.Format("<w:{0}", nodeName));
            sw.Write(">");
            if (this.pos != null)
                this.pos.Write(sw, "pos");
            if (this.numFmt != null)
                this.numFmt.Write(sw, "numFmt");
            if (this.numStart != null)
                this.numStart.Write(sw, "numStart");
            if (this.numRestart != null)
                this.numRestart.Write(sw, "numRestart");
            if (this.endnote != null)
            {
                foreach (CT_FtnEdnSepRef x in this.endnote)
                {
                    x.Write(sw, "endnote");
                }
            }
            sw.WriteEndW(nodeName);
        }

        private List<CT_FtnEdnSepRef> endnoteField;

        public CT_EdnDocProps()
        {
            //this.endnoteField = new List<CT_FtnEdnSepRef>();
        }

        [XmlElement("endnote", Order = 0)]
        public List<CT_FtnEdnSepRef> endnote
        {
            get
            {
                return this.endnoteField;
            }
            set
            {
                this.endnoteField = value;
            }
        }
    }

    [Serializable]

    [XmlType(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main")]
    [XmlRoot(Namespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main", IsNullable = true)]
    public class CT_FtnEdnRef
    {
        public XmlNode DomNode
        {
            get;
            set;
        }
        private ST_OnOff customMarkFollowsField;

        private bool customMarkFollowsFieldSpecified;

        private string idField;
        public static CT_FtnEdnRef Parse(XmlNode node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_FtnEdnRef ctObj = new CT_FtnEdnRef();
            if (node.Attributes["w:customMarkFollows"] != null)
                ctObj.customMarkFollows = (ST_OnOff)Enum.Parse(typeof(ST_OnOff), node.Attributes["w:customMarkFollows"].Value,true);
            ctObj.id = XmlHelper.ReadString(node.Attributes["w:id"]);
            ctObj.DomNode = node;
            return ctObj;
        }



        internal void Write(StreamWriter sw, string nodeName)
        {
            sw.Write(string.Format("<w:{0}", nodeName));
            XmlHelper.WriteAttribute(sw, "w:customMarkFollows", this.customMarkFollows.ToString());
            XmlHelper.WriteAttribute(sw, "w:id", this.id);
            sw.Write(">");
            sw.WriteEndW(nodeName);
        }

        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
        public ST_OnOff customMarkFollows
        {
            get
            {
                return this.customMarkFollowsField;
            }
            set
            {
                this.customMarkFollowsField = value;
            }
        }

        [XmlIgnore]
        public bool customMarkFollowsSpecified
        {
            get
            {
                return this.customMarkFollowsFieldSpecified;
            }
            set
            {
                this.customMarkFollowsFieldSpecified = value;
            }
        }

        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.openxmlformats.org/officeDocument/2006/relationships")]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }
}
