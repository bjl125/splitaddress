using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressSplitForExcel;
using AddressSplitForExcel.Entity;
using AddressSplitForExcel.Extension;

namespace AddressSplit.UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestAddSender()
        {
            SenderInfo sender = new SenderInfo();
            sender.Sender = "客户名称";
            sender.Mobile = "123212313";
            sender.Provience = "北京市";
            sender.City = "北京市";
            sender.Region = "朝阳区";
            sender.Address = "望京东东大街";

            List<SenderInfo> list = new List<SenderInfo>();
            list.Add(sender);

            DataManager dm = new DataManager();

            dm.SaveSenders(list);

        }

        [TestMethod]
        public void TestGetSender()
        {
            DataManager dm = new DataManager();

            var list = dm.GetSenders();

            var dt = list.ToTable<SenderInfo>();

        }
    }
}
