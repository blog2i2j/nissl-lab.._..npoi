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

namespace NPOI.SS.Formula
{
    using System;
    using System.Text;

    public class NameIdentifier
    {
        private readonly String _name;
        private readonly bool _isQuoted;

        public NameIdentifier(String name, bool isQuoted)
        {
            _name = name;
            _isQuoted = isQuoted;
        }
        public String Name
        {
            get
            {
                return _name;
            }
        }
        public bool IsQuoted
        {
            get
            {
                return _isQuoted;
            }
        }
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder(64);
            sb.Append(this.GetType().Name);
            sb.Append(" [");
            if (_isQuoted)
            {
                sb.Append("'").Append(_name).Append("'");
            }
            else
            {
                sb.Append(_name);
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}