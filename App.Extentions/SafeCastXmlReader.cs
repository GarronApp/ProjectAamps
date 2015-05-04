using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace App.Extentions
{
    [DebuggerStepThrough]
    public class SafeCastXmlReader : XmlTextReader
    {
        #region Constructors

        public SafeCastXmlReader(Stream stream)
            : base(stream)
        {
        }

        #endregion

        #region Virtual Methods

        public override bool ReadContentAsBoolean()
        {
            try
            {
                return base.ReadContentAsBoolean();
            }
            catch
            {
                return default(bool);
            }
        }

        public override DateTime ReadContentAsDateTime()
        {
            try
            {
                return base.ReadContentAsDateTime();
            }
            catch
            {
                return default(DateTime);
            }
        }

        public override decimal ReadContentAsDecimal()
        {
            try
            {
                return base.ReadContentAsDecimal();
            }
            catch
            {
                return default(decimal);
            }
        }


        public override int ReadContentAsInt()
        {
            try
            {
                return base.ReadContentAsInt();
            }
            catch
            {
                return default(int);
            }
        }

        #endregion
    }
}
